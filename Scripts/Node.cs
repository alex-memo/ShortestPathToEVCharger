using System.Text;

public class Node
{
	public string Name { get; set; }
	public bool IsCharger { get; set; }
	public List<Edge> Neighbors { get; set; }
	public Node(string name, bool isCharger)
	{
		Name = name;
		IsCharger = isCharger;
		Neighbors = new List<Edge>();
	}
	public void AddNeighbor(Node _neighbor, int _distance)
	{
		Neighbors.Add(new Edge(_neighbor, _distance));
	}
	public override string ToString()
	{
		StringBuilder _sb = new();
		_sb.Append($"Node {Name}\n");
		_sb.Append(IsCharger ? "Charger\n" : "Not Charger\n");
		foreach (var neighbor in Neighbors)
		{
			_sb.Append($"\t{neighbor.Neighbor.Name}({neighbor.Distance})\n");
		}

		return _sb.ToString();
	}
}
public class Edge
{
	public Node Neighbor { get; set; }
	public int Distance { get; set; }
	public Edge(Node _neighbor, int _distance)
	{
		Neighbor = _neighbor;
		Distance = _distance;
	}
}