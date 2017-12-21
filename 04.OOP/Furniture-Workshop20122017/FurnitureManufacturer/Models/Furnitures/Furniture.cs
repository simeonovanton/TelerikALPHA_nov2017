using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    // Finish the class
    public class Furniture : IFurniture
    {
        private readonly string model;
        private readonly string material;
        private readonly decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            Guard.WhenArgument(model, "Model").IsNull().IsEmpty().Throw();
            Guard.WhenArgument(model.Length, "Model length").IsLessThan(3).Throw();
            Guard.WhenArgument(materialType, "Material type").IsNull().Throw();
            Guard.WhenArgument(price, "Price cannot be less than zero").IsLessThan(0).IsEqual(0).Throw();
            Guard.WhenArgument(height, "Height cannot be less than zero").IsLessThan(0).IsEqual(0).Throw();
            this.model = model;
            this.material = materialType;
            this.price = price;
            this.height = height;
        }

        public string Model => this.model;

        public string Material => this.material;

        public decimal Price => this.price;

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
            Guard.WhenArgument(height, "Height cannot be less than zero").IsLessThan(0).IsEqual(0).Throw();
                this.height = value;
            }
        }

        // Do we need this? Can I delete it?
        protected virtual string AdditionalInfo()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format($"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height.ToString("0.00")}", this.AdditionalInfo()));
            return sb.ToString(); 
        }
    }
}
