using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models
{

    //[Table("Post")]
    public class Article{
        [Key]
        public int Id { get; set; }
        [DisplayName("Tiêu đề")]
        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title {get;set;}

        [DisplayName("Ngày Tạo")]

        [DataType(DataType.Date)]
        [Required]
        public DateTime Create {get;set;}

        [Column(TypeName = "ntext")]
        public string Content {get;set;}
    }
}