using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;

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
    }
}
