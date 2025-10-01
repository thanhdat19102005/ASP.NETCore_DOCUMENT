namespace TestProject.Models
{
    public class Student_Course
    {
        public int StudentId { get; set; } // Khóa ngoại đến Student  

        public Student? Student { get; set; } // Navigation property đến Student


        public int CourseId { get; set; } // Khóa ngoại đến Course
        public Course? Course { get; set; } // Navigation property đến Course

    }
}
