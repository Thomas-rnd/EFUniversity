namespace EFUniversity.Models;
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
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
        return $"Nom : {Title}, Crédits : {Credits} \n" + res;
    }
}