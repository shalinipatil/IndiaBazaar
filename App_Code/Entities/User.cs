
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zipcode { get; set; }
    public string PhoneNumber { get; set; }

    public User(int id, string name, string password, string email, string type, string address, string city, string state, string zip, string number)
    {
        Id = id;
        Name = name;
        Password = password;
        Email = email;
        Type = type;
        Address = address;
        City = city;
        State = state;
        Zipcode = zip;
        PhoneNumber = number;
    }

    public User(string name, string password, string email, string type, string address, string city, string state, string zip, string number)
    {
        Name = name;
        Password = password;
        Email = email;
        Type = type;
        Address = address;
        City = city;
        State = state;
        Zipcode = zip;
        PhoneNumber = number;
    }
}