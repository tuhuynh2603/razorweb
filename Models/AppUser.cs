using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace razorweb.models
{
    public class AppUser : IdentityUser
    {
        // [Column(TypeName ="nvarchar")]
        // [StringLength(400)]
        // [AllowNull]
        // public string HomeAddress {set;get;}
    }
}