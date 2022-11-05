using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    [Display(Name = "Enrollment Date"), DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new();

    public override string ToString()
    {
        return $"Id: {Id}, Last name: {LastName}, First name: {FirstName}, Enrollement date: {EnrollmentDate}";
    }
}
