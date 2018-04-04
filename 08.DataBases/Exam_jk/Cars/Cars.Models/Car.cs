namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int CarId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public Transmission Transmission { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public Car()
        {
        }
    }
}
