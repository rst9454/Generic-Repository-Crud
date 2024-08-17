using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Using_GenericRepository_CrudOperation.Models
{
    public class tblEmployee
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(30)")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = default!;
        [Column(TypeName ="varchar(30)")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string Gender { get; set; } = default!;
        //[Column(TypeName = "date")]
        [Display(Name = "Birth Date")]
        public DateOnly DOB { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; } = default!;
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; } = default!;
    }
}
