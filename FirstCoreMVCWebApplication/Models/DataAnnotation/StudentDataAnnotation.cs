using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCoreMVCWebApplication.Models.DataAnnotation
{
    [Table("Students")]
    [Index(nameof(Email), Name = "Student_Email")]
    [Keyless]  // no primary key
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     //  generates a new value when a row is inserted
        //   [DatabaseGenerated(DatabaseGeneratedOption.Computed)]    generates or recomputes the value on insert and/or update
        //  [DatabaseGenerated(DatabaseGeneratedOption.None)]         database does not generate the value
        public int Id { get; set; }

        [Key]  // the primary key of the entity
        public int StudentId { get; set; }

        [Column("FirstName", Order = 1, TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lenght must be 2 and 50")]
        public string LastName { get; set; } = null!;

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string FullName => string.IsNullOrEmpty(LastName) ? FirstName : $"{FirstName} {LastName}";

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Precision(18, 2)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GPA { get; set; }

        [DataType(DataType.Currency)]
        [Range(30000, 200000, ErrorMessage = "Salary must be between 30,000 and 200,000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$|^\d{6}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        [ConcurrencyCheck] // a record was modified by another process between the time you read it
        public string RowVersion { get; set; } = string.Empty;
        [Timestamp]  // optimistic concurrency control
        public byte[] RowVersion1 { get; set; } = Array.Empty<byte>();


        [NotMapped]  //not create a column for that property
        public string TemporaryData { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")] // specify the foreign key property 
        public Teacher Teacher { get; set; }



        [InverseProperty("OnlineTeacher")]  //multiple navigation properties
        public ICollection<Teacher>? OnlineTeachers { get; set; }

        [InverseProperty("OfflineTeacher")]
        public ICollection<Teacher>? OfflineTeachers { get; set; }
    }



    public class Teacher
    {

    }


    [PrimaryKey(nameof(StudentId), nameof(CourseId))]  // a composite primary key
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
