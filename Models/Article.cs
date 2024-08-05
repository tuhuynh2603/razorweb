using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models
{

    //[Table("Post")]
    public class Article{
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title {get;set;}

        [DataType(DataType.Date)]
        [Required]
        public DateTime Create {get;set;}

        [Column(TypeName = "ntext")]
        public string Content {get;set;}
    }
}