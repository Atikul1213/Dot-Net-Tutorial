using Serilog;

namespace FirstCoreMVCWebApplication.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(ILogger<StudentRepository> logger)
        {
            _logger = logger;
            Log.Information("Student Repository Object created for different DI life time Scoped.");
        }
        public List<Student> DataSources()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }
        public Student GetStudentById(int studentId)
        {

            return DataSources().Where(x => x.StudentId == studentId).FirstOrDefault() ?? new Student();
        }

        public List<Student> GetAllStudents()
        {
            return DataSources();
        }
    }
}
