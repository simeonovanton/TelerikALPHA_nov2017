using FurnitureManufacturer.Interfaces;
using Bytes2you.Validation;
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
    }
}
