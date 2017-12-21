using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal heightBeforeConvertion;
        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.heightBeforeConvertion = height;
            //this.Height = 0.10m;
            //this.isConverted = true;
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
                this.Height = 0.10m;
            }
            if (!IsConverted)
            {
                this.Height = this.heightBeforeConvertion;
            }
        }

        protected override string AdditionalInfo()
        {
            return string.Format(", Legs: {0}, State: {1}", this.NumberOfLegs, (this.IsConverted) ? ("Converted") : ("Normal"));
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
