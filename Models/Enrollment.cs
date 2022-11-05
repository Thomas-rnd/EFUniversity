// Grade obtained in an enrollement
public enum Grade
{
    A, B, C, D, F
}

public class Enrollment
{
    public int Id { get; set; }

    public Grade? Grade { get; set; }

    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public override string ToString()
    {
        return $"Id: {Id}, Grade: {Grade}";
    }
}
