public class Dijkstra
{
	public Dictionary<Node, int>? Distances { get; private set; }
	public Dictionary<Node, Node>? Predecessors { get; private set; }

	public void Execute(Node _source, HashSet<Node> _allNodes)
	{
		Distances = _allNodes.ToDictionary(_node => _node, _node => int.MaxValue);
		Predecessors = _allNodes.ToDictionary(_node => _node, _node => (Node)null);
		Distances[_source] = 0;

		PriorityQueue<Node, int> _queue = new();
		foreach (Node _node in _allNodes)
		{
			_queue.Enqueue(_node, Distances[_node]);
		}

		while (_queue.Count > 0)
		{
			Node _currentNode = _queue.Dequeue();
			foreach (Edge _edge in _currentNode.Neighbors)
			{
				int _alt = Distances[_currentNode] + _edge.Distance;
				if (_alt < Distances[_edge.Neighbor])
				{
					Distances[_edge.Neighbor] = _alt;
					Predecessors[_edge.Neighbor] = _currentNode;
					_queue.Enqueue(_edge.Neighbor, _alt);
				}
			}
		}
	}

	public List<Node>? GetShortestPath(Node destination)
	{
		if (Predecessors[destination] == null) { return null; }

		List<Node> path = new List<Node>();
		Node current = destination;

		while (current != null)
		{
			path.Add(current);
			current = Predecessors[current];
		}

		path.Reverse();
		return path;
	}
}