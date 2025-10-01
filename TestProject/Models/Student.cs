namespace TestProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<Student_Course>? Student_Courses { get; set; } = new List<Student_Course>();

    }
}
