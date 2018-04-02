namespace Cars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        private ICollection<City> cities;

        public int DealerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }

        public Dealer()
        {
            this.cities = new HashSet<City>();
        }
    }
}
