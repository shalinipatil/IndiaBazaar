using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entities;


public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;
    private static System.Collections.Generic.IEnumerable<Order> Orders;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GroceryDBConnectionString"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }


    public static ArrayList GetProductByType(string productType)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM Product WHERE type LIKE '{0}'", productType);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);

                string image = reader.GetString(4);
                string description = reader.GetString(5);

                Product product = new Product(id, name, type, price, image, description);
                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static Product GetProductById(int id)
    {
        string query = String.Format("SELECT * FROM Product WHERE id =  '{0}'", id);
        Product product = null;

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string image = reader.GetString(4);
                string description = reader.GetString(5);

                product = new Product(name, type, price, image, description);
            }
        }
        finally
        {
            conn.Close();
        }

        return product;
    }

    public static void AddProduct(Product product)
    {
        string query = string.Format(
            @"INSERT INTO Product VALUES ('{0}', '{1}', @prices, '{2}', '{3}')", product.Name, product.Type, product.Image, product.Description);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@prices", product.Price));
        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static User LoginUser(string name, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM GroceryDB.dbo.users WHERE Name = '{0}'", name);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT Password FROM users WHERE Name = '{0}'", name);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = string.Format("SELECT Email, User_type,UserAdd,City,State,Zipcode,PhoneNumber FROM users WHERE Name = '{0}'", name);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);
                        string address = reader.GetString(2);
                        string city = reader.GetString(3);
                        string state = reader.GetString(4);
                        string zip = reader.GetString(5);
                        string number = reader.GetString(6);


                        user = new User(name, password, email, type, address, city, state, zip, number);
                    }
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {
            conn.Close();
        }
    }


      public static User GetUserDetails(string userName)
       {
           string query = string.Format("SELECT * FROM users WHERE Name = '{0}'", userName);
           command.CommandText = query;
           User user = null;

           try
           {
               conn.Open();
               SqlDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                   int id = reader.GetInt32(0);
                   string name = reader.GetString(1);
                   string password = reader.GetString(2);
                   string email = reader.GetString(3);
                   string userType = reader.GetString(4);
                   string address = reader.GetString(5);
                   string city = reader.GetString(6);
                   string state = reader.GetString(7);
                   string zip = reader.GetString(8);
                   string number = reader.GetString(9);

                   user = new User(id, name, password, email, userType,address,city,state,zip,number);
               }
           }
           catch (Exception ex)
           {
              MessageBox.Show(ex.ToString());
           }
           finally
           {
               conn.Close();
           }
           return user;
       }
   
      
    public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE name = '{0}'", user.Name);
        command.CommandText = query;
       
        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}')", user.Name, user.Password,user.Email, user.Type,user.Address,user.City,user.State,user.Zipcode,user.PhoneNumber);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "User registered!";
            }
            else
            {
                //User exists
                return "A user with this name already exists";
            }
        }
        finally
        {
            conn.Close();
        }
    }
  
    public static void AddOrders(ArrayList Orders)
    {
        try
        {
            //Insert command using SQL Parameters
            command.CommandText = "INSERT INTO Orders VALUES (@client, @product, @amount, @price, @date, @orderSent)";
            conn.Open();

            //Update values for each order in List
            foreach (Order order in Orders)
            {
                command.Parameters.Add(new SqlParameter("@client", order.Client));
                command.Parameters.Add(new SqlParameter("@product", order.Product));
                command.Parameters.Add(new SqlParameter("@amount", order.Amount));
                command.Parameters.Add(new SqlParameter("@price", order.Price));
                command.Parameters.Add(new SqlParameter("@date", order.Date));
                command.Parameters.Add(new SqlParameter("@orderSent", order.OrderShipped));

                //Execute query and clear parameters
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }


   public static void UpdateOrders(string client, DateTime date)
    {
        string query = string.Format(@"UPDATE [GroceryDB].[dbo].[Orders]
                                       SET OrderShipped = 1
                                       WHERE ClientName = @client
                                       AND PurchasedDate = @date");
        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date", date));
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
           MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    
    public static ArrayList GetGroupedOrders(DateTime currentDate, DateTime endDate, Boolean shipped)
    {
        const string query = @"SELECT ClientName, PurchasedDate, SUM(total) as total
                                FROM (
	                                    SELECT ClientName,PurchasedDate, (Amount * Price) AS total
	                                    FROM [GroceryDB].[dbo].[Orders]
	                                    WHERE PurchasedDate >= @date1
	                                    AND PurchasedDate <= @date2
                                        AND OrderShipped = @shipped
                                )as result
                                GROUP BY ClientName,PurchasedDate";
        ArrayList orderList = new ArrayList();
        int lastDay;

        //Check if current date.month == enddate.month
        if (currentDate.Month == endDate.Month && currentDate.Year == endDate.Year)
        {
            //Yes, Last day to be displayed is the selected date in txtOpenOrders2. (Orders page)
            lastDay = endDate.Day;
        }
        else
        {
            //No, Other months will be displayed after this one. Last day = Last day of the month.
            lastDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
        }

        DateTime date2 = new DateTime(currentDate.Year, currentDate.Month, lastDay);

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@date1", currentDate));
            command.Parameters.Add(new SqlParameter("@date2", date2));
            command.Parameters.Add(new SqlParameter("@shipped", shipped));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string client = reader.GetString(0);
                DateTime date = reader.GetDateTime(1);
                double total = reader.GetDouble(2);

                GroupedOrder groupedOrder = new GroupedOrder(client, date, total);
                orderList.Add(groupedOrder);
            }
        }
        catch (SqlException ex)
        {
          MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return orderList;
    }

    public static ArrayList GetDetailedOrders(string client, DateTime date)
    {
        const string query = @" SELECT Id, ProductOrdered, Amount, Price, OrderShipped
                                FROM Orders WHERE ClientName = @client AND PurchasedDate = @date";
        ArrayList orderList = new ArrayList();

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date", date));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string product = reader.GetString(1);
                int amount = reader.GetInt32(2);
                double price = reader.GetDouble(3);
                bool orderShipped = reader.GetBoolean(4);

                Order order = new Order(id, client, product, amount, price, date, orderShipped);
                orderList.Add(order);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
        return orderList;
    }
    public static void AddPaymentInfo(ArrayList PaymentInfo)
    {
        try
        {
            //Insert command using SQL Parameters
            command.CommandText = "INSERT INTO PaymentInfo VALUES (@userId, @ctype, @cName, @cNumber,@cvv, @cdate, @orderno)";
            conn.Open();

            //Update values for each order in List
            foreach (PaymentInfo paymentInfo in PaymentInfo)
            {
                command.Parameters.Add(new SqlParameter("@userId", paymentInfo.UserId));
                command.Parameters.Add(new SqlParameter("@ctype", paymentInfo.CardType));
                command.Parameters.Add(new SqlParameter("@cName", paymentInfo.HolderName));
                command.Parameters.Add(new SqlParameter("@cNumber", paymentInfo.CardNumber));
                command.Parameters.Add(new SqlParameter("@cvv", paymentInfo.Cvv));
                command.Parameters.Add(new SqlParameter("@cdate", paymentInfo.Date));
                command.Parameters.Add(new SqlParameter("@orderno", paymentInfo.OrderNo));

                //Execute query and clear parameters
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }
  
}
       
    
