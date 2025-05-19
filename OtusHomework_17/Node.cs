namespace OtusHomework_17;

public class Node
{
    public required int Salary { get; set; }
    public required string Name { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}