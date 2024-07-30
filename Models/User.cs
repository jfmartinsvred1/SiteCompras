using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SiteCompras.Models
{
    public class User:IdentityUser
    {
        public virtual Cart Cart { get; set; }
        public User():base()
        {
            
        }

    }
}
