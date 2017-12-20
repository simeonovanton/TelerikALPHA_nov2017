using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Furnitures;
using System;

namespace FurnitureManufacturer.Engine.Factories
{
    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public IFurniture CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            var material = GetMaterialType(materialType).ToString();

            return new Table( model,  material,  price,  height,  length,  width);
        }

        public IFurniture CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType).ToString();

            return new Chair(model, material, price, height, numberOfLegs);
        }

        public IFurniture CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType).ToString();

            return new AdjustableChair( model,  material,  price,  height,  numberOfLegs);
        }

        public IFurniture CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            var material = GetMaterialType(materialType).ToString();
            return new ConvertibleChair( model,  material,  price,  height,  numberOfLegs);
        }

        private static MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }

    }
}
