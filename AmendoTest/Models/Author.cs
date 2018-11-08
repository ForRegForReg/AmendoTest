using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmendoTest.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "Имя автора")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество автора")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Фамилия автора")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }
    }
}