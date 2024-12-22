namespace FirstCoreMVCWebApplication.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAllStudents();
    }
}
