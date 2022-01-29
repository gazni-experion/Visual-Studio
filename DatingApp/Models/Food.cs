using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatingApp.Models
{
    public partial class Food
    {
        public Food()
        {
            Customers = new HashSet<Customers>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
