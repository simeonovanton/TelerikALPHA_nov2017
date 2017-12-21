using FurnitureManufacturer.Interfaces;
using Bytes2you.Validation;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Chair : Furniture, IFurniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            :base(model, materialType, price,  height)
        {
            Guard.WhenArgument(numberOfLegs, "Number Of Legs").IsEqual(0).IsLessThan(0).Throw();
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get { return this.numberOfLegs; } }

       
        protected override string AdditionalInfo()
        {
            return string.Format($", Legs: {this.NumberOfLegs}");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(AdditionalInfo());

            return sb.ToString();
        }
    }
}
