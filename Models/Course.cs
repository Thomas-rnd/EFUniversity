public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new();

    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}";
    }
}
