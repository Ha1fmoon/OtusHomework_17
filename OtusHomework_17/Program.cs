namespace OtusHomework_17;

internal class Program
{
    private static void Main()
    {
        var tree = new EmployeesTree();

        while (true)
        {
            tree.Clear();

            GenerateEmployeeDetails(tree);

            if (!PrintEmployeeList(tree)) continue;

            SearchEmployeeBySalary(tree);
        }
    }

    private static void InputEmployeeDetails(EmployeesTree tree)
    {
        Console.WriteLine("Enter employee information:");

        while (true)
        {
            Console.Write("Employee name (empty string to finish): ");
            var name = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name)) break;

            Console.Write("Employee salary: ");
            if (int.TryParse(Console.ReadLine(), out var salary))
                tree.Add(name, salary);
            else
                Console.WriteLine("Salary must be a number.");
        }
    }

    private static void GenerateEmployeeDetails(EmployeesTree tree)
    {
        var employees = new List<Employee>
        {
            new() { Name = "Joe", Salary = 50000 },
            new() { Name = "Bob", Salary = 60000 },
            new() { Name = "Jack", Salary = 33000 },
            new() { Name = "Mary", Salary = 59000 },
            new() { Name = "Peter", Salary = 45000 }
        };

        foreach (var employee in employees) tree.Add(employee.Name, employee.Salary);
    }

    private static bool PrintEmployeeList(EmployeesTree tree)
    {
        var sortedEmployees = tree.GetEmployeesSortedList();

        if (sortedEmployees.Count == 0)
        {
            Console.WriteLine("Employee list is empty. Please enter employee information.");
            Console.WriteLine();
            return false;
        }

        Console.WriteLine("List of employees: ");

        foreach (var employee in sortedEmployees) Console.WriteLine(employee);

        return true;
    }

    private static void SearchEmployeeBySalary(EmployeesTree tree)
    {
        var isSearchActive = true;

        while (isSearchActive)
        {
            var validInput = false;
            var salary = 0;

            while (!validInput)
            {
                Console.WriteLine();
                Console.Write("Enter salary amount to search for an employee: ");
                if (int.TryParse(Console.ReadLine(), out salary))
                    validInput = true;
                else
                    Console.WriteLine("Salary must be a number.");
            }

            var employee = tree.FindBySalary(salary);

            if (employee != null)
                Console.WriteLine($"Employee found: {employee}");
            else
                Console.WriteLine("Employee not found");

            isSearchActive = FinalAction();
        }
    }

    private static bool FinalAction()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Enter 0 to restart the program or 1 to search for another salary: ");
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    return false;
                case ConsoleKey.D1:
                    return true;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter 0 or 1.");
                    break;
            }
        }
    }
}