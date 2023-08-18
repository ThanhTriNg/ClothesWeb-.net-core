using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class Category
    {
        public Category()
        {
            Clothes = new HashSet<Clothe>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }

        public virtual ICollection<Clothe> Clothes { get; set; }
    }
}
