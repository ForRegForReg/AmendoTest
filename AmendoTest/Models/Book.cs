using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AmendoTest.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Required]
        [Display(Name = "Название книги")]
        public string BookName { get; set; }

        [ForeignKey("Author")]
        [Display(Name = "Автор книги")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}