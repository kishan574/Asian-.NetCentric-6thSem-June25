namespace Unit1_LanguagePreliminaries
{
    public class Student
    {
        // Properties
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public int[] Marks { get; set; }

        //Default constructor
        public Student()
        {
            Console.WriteLine("Person Constructor called!!");
        }

        //Parametrised Constructor
        public Student(string name, int rollNo, int[] marks)
        {
            Name = name;
            RollNumber = rollNo;
            Marks = marks;

            Console.WriteLine($"Person Constructor called!! {Name} {RollNumber} {Marks.Length} ");
        }

        // Method to calculate average marks
        public double CalculateAverage()
        {
            int total = 0;
            foreach (var mark in Marks)
            {
                total += mark;
            }

            Console.WriteLine($"Total Marks is {total}");

            return (double)total / Marks.Length;
        }

        // Method to check if the student passed
        public bool HasPassed()
        {
            return CalculateAverage() >= 40;
        }

        public void ReadStudent()
        {
            try
            {
                // Input details for a student
                Console.WriteLine("Enter Student Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Roll Number:");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter number of subjects:");
                int subjectCount = int.Parse(Console.ReadLine());
                int[] marks = new int[subjectCount];

                for (int i = 0; i < subjectCount; i++)
                {
                    Console.Write($"Enter marks for subject {i + 1}: ");
                    marks[i] = int.Parse(Console.ReadLine());
                }

                // Create a Student object
                Student student = new Student(name, rollNumber, marks);

                // Display average marks and pass/fail status
                Console.WriteLine($"\nStudent Name: {student.Name}");
                Console.WriteLine($"Roll Number: {student.RollNumber}");
                Console.WriteLine($"Average Marks: {student.CalculateAverage():F2}");
                Console.WriteLine($"Result: {(student.HasPassed() ? "Passed" : "Failed")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Second lvl exception {ex.Message}");
                throw;
            }
        }

    }
}
