namespace FirstCoreMVCWebApplication.SOLID.SRP
{
    public class Student
    {
        public string Name { get; set; }

        public Dictionary<string, double> CourseAndGrade = new Dictionary<string, double>();

        public void EnrollCourse(string course)
        {
            CourseAndGrade[course] = 0;
        }

        public void AssingCourse(string course, double grade)
        {
            if (CourseAndGrade.ContainsKey(course))
                CourseAndGrade[course] = grade;
        }

    }


    public class GPACalculater
    {
        public double CalculateGPA(Student student)
        {
            var totalGrades = 0.0;

            foreach (KeyValuePair<string, double> kvp in student.CourseAndGrade)
            {
                Console.WriteLine("Key: " + kvp.Key + " Values: " + kvp.Value);
                totalGrades += kvp.Value;
            }

            var totalCourse = student.CourseAndGrade.Count();
            totalGrades = totalGrades / totalCourse;

            return totalGrades;
        }
    }

    public class TranscripGenerator
    {
        private GPACalculater _gpaCalculator;
        public TranscripGenerator(GPACalculater gPACalculater)
        {
            _gpaCalculator = gPACalculater;
        }

        public void PrintTranscript(Student student)
        {
            Console.WriteLine($"Transcript for {student.Name}");
            foreach (KeyValuePair<string, double> kvp in student.CourseAndGrade)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
            var grades = _gpaCalculator.CalculateGPA(student);
            Console.WriteLine($"GPA: " + grades);
        }
    }
}
