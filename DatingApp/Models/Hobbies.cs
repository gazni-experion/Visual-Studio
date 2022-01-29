using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatingApp.Models
{
    public partial class Hobbies
    {
        public Hobbies()
        {
            Customers = new HashSet<Customers>();
        }

        public int HobbyId { get; set; }
        public string Hobby { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
