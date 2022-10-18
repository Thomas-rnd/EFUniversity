using EFUniversity.Data;
using EFUniversity.Models;

// Seed data into DB
SeedData.Init();


//Requêtage de données
using (var context = new UniversityContext())
{
    Console.WriteLine("---Liste de tous les cours, triés par ordre alphabétique---");
    var cours = context.Courses
        .OrderBy(c => c.Title)
        .ToList();
    foreach (Course c in cours)
    {
        Console.WriteLine(c);
    }

    Console.WriteLine("---Liste de tous les étudiants, triés par identifiant décroissant---");

    var eleve = context.Students
            .OrderBy(e => e.Id)
            .ToList();
    for (int i = cours.Count - 1; i >= 0; i--)
    {
        Console.WriteLine(eleve[i]);
    }

    Console.WriteLine("---Détails sur l’étudiant A. Carson.---");

    Student eleve1 = context.Students
            .Where(e => e.LastName == "Carson"
                     && e.FirstName == "Alexander").Single();
    Console.WriteLine(eleve1);

    /*
    Student eleve1 = context.Students
            .Single(e => e.LastName == "Carson"
                     && e.FirstName == "Alexander")
    Console.WriteLine(eleve1);
    */


    Console.WriteLine("---(Bonus) Notes obtenues par A. Anand dans l’ensemble de ses cours---");
    Console.WriteLine("---(Bonus) Liste des étudiants inscrits au cours Chemistry---");
}

//Mise à jour de données
using (var context = new UniversityContext())
{
    var eleve = context.Students
        .Where(e => e.LastName == "Alonso").Single();
    var cours = context.Courses
        .Where(c => c.Title == "Chemistry").Single();

    var inscription = context.Enrollments;
    inscription.Add(new Enrollment
    {
        Student = eleve,
        Course = cours,
        Grade = null,
    });
    context.SaveChanges();
}

//Supprssion de données
using (var context = new UniversityContext())
{
    var supressionEleve = context.Students
        .Where(e => e.LastName == "Barzdukas").Single();
    context.Remove(supressionEleve);

    var supressionEnrollment = context.Enrollments
        .Where(e => e.StudentId == supressionEleve.Id).Single();
    context.Remove(supressionEnrollment);

    context.SaveChanges();
}
