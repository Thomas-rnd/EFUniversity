namespace EFUniversity.Models;
public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public List<Enrollment> Enrollments { get; set; } = null!;//association 1 à plusieurs

    public override string ToString()
    {
        string res = "";
        /*
        // Par défaut la requête ne navigue pas l'assiciation il faut rajouter des include
        // dans la requête pour les inclure.
        foreach (Enrollment e in Enrollments)
        {
            res += e.ToString() + $"\n";
        }
        */
        return $"Nom : {LastName}, Prénom : {FirstName}, Date : {EnrollmentDate} \n" + res;
    }
}