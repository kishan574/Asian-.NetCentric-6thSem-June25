using CsvFileExample;
using Unit1LanguagePreliminaries2;

namespace Unit1_LanguagePreliminary2
{

    // Base class
    class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    // Derived class
    class Employee : Person
    {
        public JobRole Role { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int age, JobRole role, double salary) : base(name, age) // Using base keyword to call parent constructor
        {
            Role = role;
            Salary = salary;
        }

        // Polymorphism - Method Overloading
        public double CalculateSalary(double bonus)
        {
            return Salary + bonus;
        }

        public double CalculateSalary(double bonus, double tax)
        {
            return (Salary + bonus) - tax;
        }

        // Polymorphism - Method Overriding
        public override void DisplayDetails()
        {
            base.DisplayDetails(); // Call base method
            Console.WriteLine($"Role: {Role}, Salary: {Salary}");
        }
    }

    // Sealed class
    sealed class Manager : Employee
    {
        public Manager(string name, int age, JobRole role, double salary)
            : base(name, age, role, salary) { }

        public void AssignTask()
        {
            Console.WriteLine($"{Name} is assigning tasks.");
        }
    }

    // Delegate and Event
    class BonusManager
    {
        public delegate void BonusAddedEventHandler(string message);

        public event BonusAddedEventHandler BonusAdded;

        public void AddBonus(Employee employee, double bonus)
        {
            employee.Salary += bonus;
            BonusAdded?.Invoke($"Bonus of {bonus} added to {employee.Name}'s salary.");
        }
    }

    class Program
    {
        // Async LINQ expression
        public static async Task<List<Employee>> GetHighSalaryEmployeesAsync(List<Employee> employees, double threshold)
        {
            return await Task.Run(() =>
                employees.Where(e => e.Salary > threshold).ToList()
            );
        }

        static async Task Main(string[] args)
        {
            try
            {
                // Create employees
                var employees = new List<Employee>
                {
                    new Employee("Alice", 30, JobRole.Developer, 80000),
                    new Employee("Bob", 35, JobRole.Tester, 60000),
                    new Employee("Charlie", 40, JobRole.Manager, 100000)
                };

                // Display employee details
                Console.WriteLine("All Employees:");
                foreach (var employee in employees)
                {
                    employee.DisplayDetails();
                    Console.WriteLine();
                }

                // Async LINQ Expression
                Console.WriteLine("Fetching employees with salary > 70000 asynchronously...");
                var highSalaryEmployees = await GetHighSalaryEmployeesAsync(employees, 70000);
                Console.WriteLine($"Vlue receved: {highSalaryEmployees}"); 
                Console.WriteLine("High Salary Employees:");
                foreach (var emp in highSalaryEmployees)
                {
                    Console.WriteLine(emp.Name);
                }

                // Try-Catch-Finally
                try
                {
                    Console.WriteLine("\nCalculating salary...");
                    double newSalary = employees[0].CalculateSalary(5000, -2000); // Intentional negative tax
                    Console.WriteLine($"New Salary: {newSalary}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in salary calculation: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Salary calculation attempt complete.");
                }

                // Delegate and Event
                BonusManager bonusManager = new BonusManager();
                bonusManager.BonusAdded += message => Console.WriteLine(message);

                bonusManager.AddBonus(employees[1], 3000);

                // Sealed Class
                Manager manager = new Manager("Diana", 45, JobRole.Manager, 120000);
                manager.AssignTask();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled Exception: {ex.Message}");
            }


            //File IO
            List<string> content = new List<string> { "Hello World", "Welcome to Paradise", "Done \n\t not DOne " };

            FileReaders fileReaders = new FileReaders("Asian.txt",
                "C:\\Users\\kishu\\OneDrive\\Desktop\\.Net Centric\\Asian-.NetCentric-6thSem-dec24\\Unit 1\\Unit1LanguagePreliminaries2\\Content\\",
                    content);

            bool check = await fileReaders.CreateTXTFile();
            Console.WriteLine($"File Created status: {check}");

            var listStrings = await fileReaders.ReadTxtFile();
            Console.WriteLine(listStrings.Length);


            var employeesList = new List<Employees>
            {
                new Employees { Id = 1, Name = "Alice", Department = "IT", Salary = 75000 },
                new Employees { Id = 2, Name = "Bob", Department = "HR", Salary = 60000 },
                new Employees { Id = 3, Name = "Charlie", Department = "Finance", Salary = 90000 },
            };


            // File path
            string filePath = "C:\\Users\\kishu\\OneDrive\\Desktop\\.Net Centric\\Asian-.NetCentric-6thSem-dec24\\Unit 1\\Unit1LanguagePreliminaries2\\Content\\employees.csv";

            // Write data to CSV
            Console.WriteLine("Writing data to CSV...");
            CsvOperations.WriteToCsv(filePath, employeesList);

            // Read data from CSV
            Console.WriteLine("Reading data from CSV...");
            var employeesFromCsv = CsvOperations.ReadFromCsv(filePath);

            // Display data
            Console.WriteLine("\nEmployees from CSV:");
            foreach (var employee in employeesFromCsv)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}");
            }
        }
    }
}
