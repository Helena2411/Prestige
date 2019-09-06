using System.ComponentModel.DataAnnotations;

namespace Prestige.RoyalRent.Client.Business
{
    public class Customer<T>
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public T Password { get; set; }

        public Customer(string name, string email, T password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}
