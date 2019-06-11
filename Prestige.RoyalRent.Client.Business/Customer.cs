using System;

namespace Prestige.RoyalRent.Client.Business
{
    public class Customer<T>
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public T Email { get; set; }

        public Customer(string name, T email)
        {
            Name = name;
            Email = email;
            Id = Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}
