using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteCompras.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public List<ProductSelected> Products { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }


    }
}
