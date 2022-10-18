namespace EFUniversity.Models;
public enum Grade
{
    A,
    B,
    C,
    F
}

public class Enrollment
{
    public int Id { get; set; }
    public Grade? Grade { get; set; }
    public int StudentId { get; set; }//clef étrangère
    public int CourseId { get; set; }//clef étrangère
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public override string ToString()
    {
        if (Grade != null)
        {
            return $"Garde : {Grade}, Id Élève : {StudentId}, Id Cours : {CourseId}";
        }
        else
        {
            return $"Garde : NULL, Id Élève : {StudentId}, Id Cours : {CourseId}";
        }

    }
}