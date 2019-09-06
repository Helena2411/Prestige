using Prestige.RoyalRent.Common.Enums;

namespace Prestige.RoyalRent.Client.Business.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        public EnumBrand Brand { get; set; }

        public EnumModel Model { get; set; }

        public EnumCarcase Carcase { get; set; }

        public string Motor { get; set; }

        public string Color { get; set; }

        public int CustomerId { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} {Carcase} {Motor} {Color}";
        }
    }
}
