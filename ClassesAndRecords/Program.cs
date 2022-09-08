static void PrintCourse(Course course)
{
    Console.WriteLine(course.Name);
}

var pluralsightCourse = new Course();
pluralsightCourse.Name = "Working with C# Records";
pluralsightCourse.Author = "Roland Guijt";

PrintCourse(pluralsightCourse);

public class Course
{
    public string? Name { get; set; }
    public string? Author { get; set; }
}

public record CourseRecord(string Name, string Author);