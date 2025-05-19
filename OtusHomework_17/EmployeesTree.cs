namespace OtusHomework_17;

public class EmployeeTree
{
    private Node? _root;

    public void Add(string name, int salary)
    {
        var node = new Node
        {
            Name = name, 
            Salary = salary
        };

        if (_root == null)
        {
            _root = node;
            return;
        }

        AddNode(_root, node);
    }

    private void AddNode(Node rootNode, Node newNode)
    {
        if (newNode.Salary < rootNode.Salary)
        {
            if (rootNode.Left == null)
                rootNode.Left = newNode;
            else
                AddNode(rootNode.Left, newNode);
        }
        else
        {
            if (rootNode.Right == null)
                rootNode.Right = newNode;
            else
                AddNode(rootNode.Right, newNode);
        }
    }

    public string? FindBySalary(int salary)
    {
        var employee = FindNodeBySalary(_root, salary);
        return employee?.Name;
    }

    private Node? FindNodeBySalary(Node? currentNode, int salary)
    {
        if (currentNode == null) return null;

        if (currentNode.Salary == salary) return currentNode;

        return FindNodeBySalary(salary < currentNode.Salary ? currentNode.Left : currentNode.Right, salary);
    }

    public List<(string Name, int Salary)> GetEmployeesSortedList()
    {
        var result = new List<(string Name, int Salary)>();
        InOrderTraversal(_root, result);
        return result;
    }

    private void InOrderTraversal(Node? node, List<(string Name, int Salary)> result)
    {
        if (node == null)
            return;

        InOrderTraversal(node.Left, result);
        result.Add((node.Name, node.Salary));
        InOrderTraversal(node.Right, result);
    }

    public void Clear()
    {
        _root = null;
    }
}