using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        
        public void SetHeight(decimal height)
        {
            Guard.WhenArgument(height, "Adjusted Height").IsEqual(0).IsLessThan(0).Throw();
            this.Height = height;
        }

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
