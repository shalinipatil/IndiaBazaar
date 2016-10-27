using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using Entities;
using System.Text;


namespace Pages
{
    public partial class Pages_OrdersDetailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIfAdministrator();
            lblTitle.Text = string.Format("<h2>Client: {0}<br />Date: {1}</h2>", Request.QueryString["client"], Request.QueryString["date"]);
        }

        protected void btnShip_Click(object sender, EventArgs e)
        {
            //Get variables from Url
            string client = Request.QueryString["client"];
            DateTime date = Convert.ToDateTime(Request.QueryString["date"]);

            //Get user info + user's placed orders
            User user = ConnectionClass.GetUserDetails(client);
            ArrayList orderList = ConnectionClass.GetDetailedOrders(client, date);

            //Update database and send confirmation e-mail. Afterwards send user back to 'Orders' Page
            ConnectionClass.UpdateOrders(client, date);
            SendEmail(user.Name, user.Email, orderList);
            Response.Redirect("~/Pages/Orders.aspx");
        }

        private void CheckIfAdministrator()
        {
            if ((string)Session["type"] != "Administrator")
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }
        }

        private void SendEmail(string client, string email, ArrayList orderList)
        {
            MailAddress to = new MailAddress(email);
			
			//TODO: Fill in your own e-mail here!
            MailAddress from = new MailAddress("shalini.p.patil@gmail.com");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
Dear {0},

We are happy to announce that your order placed on {1} has been completed and is ready for pickup.

Your ordered products:" , client,Request.QueryString["date"]);
            double total = 0;
            
            foreach (Order order in orderList)
            {
                sb.AppendFormat(@"
- {0} ($ {1})                        X {2}     = {3}",
                                             order.Product,order.Price,order.Amount, (order.Amount*order.Price));

                total += (order.Amount*order.Price);
            }
            sb.Append(@"
Total Amount = $" + total);
                sb.Append(@"
                
You can come collect your order at your earliest convienence.

Kind regards
Shalini");

            MailMessage mail = new MailMessage(from, to);
            mail.Body = sb.ToString();
            mail.Subject = "Your order has been completed";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
			
			//TODO: Fill in your own e-mail and password here!
            smtp.Credentials = new NetworkCredential("shalini.p.patil@gmail.com", "sha88yo94pra");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

        private string GenerateOrderedItems(ArrayList orderList)
        {
            string result = "";
            double totalAmount = 0;

            foreach (Order order in orderList)
            {
                result += string.Format(@"
- {0} (${1} )                              X {2}        = ${3} ",
                    order.Product, order.Price, order.Amount, (order.Amount * order.Price));
                totalAmount += (order.Amount * order.Price);
            }

            result += string.Format(@"

Total Amount: ${0} ", totalAmount);
            return result;
        }
    }
}