namespace OtusHomework_17;

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Salary}";
    }
}