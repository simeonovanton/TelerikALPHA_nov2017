using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal heightBeforeConvertion = 0;
        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.heightBeforeConvertion = height;
            this.Height = 0.10m;
            this.isConverted = true;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
            set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !(this.isConverted);
            if (IsConverted)
            {
                this.Height = 0.1m;
            }
            if (!IsConverted)
            {
                this.Height = this.heightBeforeConvertion;
            }
        }
    }
}
