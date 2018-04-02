namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public Manufacturer()
        {
        }
    }
}
