using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatingApp.Models
{
    public partial class MovieGenres
    {
        public MovieGenres()
        {
            Customers = new HashSet<Customers>();
        }

        public int GenreId { get; set; }
        public string Genres { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
