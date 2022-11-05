using Microsoft.EntityFrameworkCore;

using (var context = new UniversityContext())
{
    SeedData.Init();

    Console.WriteLine("----- Courses sorted alphabetically -----");
    var courses = context.Courses.OrderBy(c => c.Title).ToList();
    foreach (Course c in courses)
        Console.WriteLine(c);

    Console.WriteLine("----- Students sorted by decreasing id -----");
    var students = context.Students.OrderByDescending(s => s.Id).ToList();
    foreach (Student s in students)
        Console.WriteLine(s);

    Console.WriteLine("----- Details about Alexander Carson -----");
    var carson = context.Students
        .Where(s => s.FirstName == "Alexander" && s.LastName == "Carson")
        .Include(s => s.Enrollments) // Needed to navigate enrollments
        .Single();
    Console.WriteLine(carson);
    foreach (Enrollment e in carson.Enrollments)
        Console.WriteLine(e);

    Console.WriteLine("----- Grades obtained by A. Anand -----");
    var anandGradesQuery = from s in context.Students
                           from e in s.Enrollments
                           where s.FirstName == "Arturo" && s.LastName == "Anand"
                           select e.Grade;
    foreach (Grade? grade in anandGradesQuery)
        Console.WriteLine($"Grade: {grade}");

    Console.WriteLine("----- Students enrolled in Chemistry course -----");
    var chemStudentsQuery = from s in context.Students
                            from e in s.Enrollments.Where(e => e.Course.Title == "Chemistry")
                            select s;
    var chemStudents = chemStudentsQuery.ToList();
    foreach (Student s in chemStudents)
        Console.WriteLine(s);

    Console.WriteLine("----- Enrolling A. Alonso in Chemistry -----");
    var alonso = context.Students
        .Where(s => s.FirstName == "Arturo" && s.LastName == "Anand")
        .Single();
    var chemistry = context.Courses
        .Where(c => c.Title == "Chemistry")
        .Single();
    alonso.Enrollments.Add(new Enrollment { Student = alonso, Course = chemistry, Grade = Grade.D });
    context.SaveChanges();

    Console.WriteLine("----- Setting A. Anand's grade in Chemistry -----");
    var anandChemEnrollQuery = from s in context.Students
                               from e in s.Enrollments.Where(e => e.Course.Title == "Chemistry")
                               where s.FirstName == "Arturo" && s.LastName == "Anand"
                               select e;
    Enrollment anandChemEnroll = anandChemEnrollQuery.First();
    anandChemEnroll.Grade = Grade.A;
    context.SaveChanges();

    Console.WriteLine("----- Deleting student G. Barzdukas -----");
    var barzdukas = context.Students
        .Where(s => s.FirstName == "Gytis" && s.LastName == "Barzdukas")
        .Single();
    context.Students.Remove(barzdukas);
    context.SaveChanges();

    Console.WriteLine("----- Deleting A. Carson's enrollment in Chemistry -----");
    var carsonChemEnrollQuery = from e in context.Enrollments
        .Where(e => e.Student.FirstName == "Alexander" && e.Student.LastName == "Carson")
        .Where(e => e.Course.Title == "Chemistry")
                                select e;
    Enrollment carsonChemEnroll = carsonChemEnrollQuery.First();
    context.Enrollments.Remove(carsonChemEnroll);
    context.SaveChanges();
}
