using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Table : Furniture, ITable, IFurniture
    {
        private readonly decimal length;
        private readonly decimal width;
        private decimal area;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            Guard.WhenArgument(length, "Table Length").IsEqual(0).IsLessThan(0).Throw();
            this.length = length;

            Guard.WhenArgument(width, "Table Width").IsEqual(0).IsLessThan(0).Throw();
            this.width = width;
        }


        public decimal Length
        {
            get
            { return this.length; }
        }

        public decimal Width
        {
            get
            { return this.width; }
        }

        public decimal Area
        {
            get { return this.area; }
            set { this.area = this.length * this.width; }
        }
    }
}
