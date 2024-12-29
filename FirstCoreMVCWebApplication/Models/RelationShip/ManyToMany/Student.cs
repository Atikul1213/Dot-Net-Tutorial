namespace FirstCoreMVCWebApplication.Models.RelationShip.ManyToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; set; } // Navigation property to join entity
    }
}
