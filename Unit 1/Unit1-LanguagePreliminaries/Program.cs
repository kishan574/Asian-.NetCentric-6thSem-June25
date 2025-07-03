using Unit1_LanguagePreliminaries;

var a = new[] { "a", "2" };

Student person = new();
person.Marks = new[] { 1, 2 };
person.Name = "xyz";

Student person1 = new Student("Kisn", 1, new[] { 10, 12, 14, 16 });

double avg = person1.CalculateAverage();

Console.WriteLine($"Avg marks is {avg}");

Console.WriteLine("END");

Console.WriteLine(person1.HasPassed());

try
{
    person.ReadStudent();
}
catch (Exception ex)
{
    Console.WriteLine($"Error Occured: {ex.Message} {ex.InnerException}");
}
finally
{
    person.ReadStudent();
}