using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatingApp.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public int? FoodId { get; set; }
        public int? Food2Id { get; set; }
        public int? OccupationId { get; set; }
        public int? HobbyId { get; set; }
        public int? GenreId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Food2 Food2 { get; set; }
        public virtual MovieGenres Genre { get; set; }
        public virtual Hobbies Hobby { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
