﻿using System.ComponentModel.DataAnnotations;

namespace SiteCompras.Models
{
    public class ProductSelected
    {
        [Key]
        public int ProductSelectedId { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
    }
}
