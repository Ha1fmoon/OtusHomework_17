namespace OtusHomework_17;

public class EmployeesTree
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

    public string? FindBySalary(int salary)
    {
        var employee = TryGetNodeBySalary(_root, salary);
        return employee?.Name;
    }

    public List<Employee> GetEmployeesSortedList()
    {
        var result = new List<Employee>();
        GetInOrder(_root, result);
        return result;
    }

    public void Clear()
    {
        _root = null;
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

    private Node? TryGetNodeBySalary(Node? rootNode, int salary)
    {
        if (rootNode == null) return null;

        if (rootNode.Salary == salary) return rootNode;

        return TryGetNodeBySalary(salary < rootNode.Salary ? rootNode.Left : rootNode.Right, salary);
    }

    private void GetInOrder(Node? node, List<Employee> result)
    {
        if (node == null) return;

        GetInOrder(node.Left, result);
        result.Add(new Employee { Name = node.Name, Salary = node.Salary });
        GetInOrder(node.Right, result);
    }
}