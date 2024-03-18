class Program
{

	private static string startingNode = "A";

	static void Main(string[] args)
	{
		var _nodes = setNodes();

		var _dijkstra = new Dijkstra();
		Node _startNode = _nodes.FirstOrDefault(_node => _node.Name == startingNode);
		if (_startNode == null)
		{
			Console.WriteLine("Start node not found.");
			return;
		}
		_dijkstra.Execute(_startNode, _nodes);
		var _chargers = _nodes.Where(n => n.IsCharger);
		Node? _closestCharger = null;
		int _shortestDistance = int.MaxValue;
		List<Node> _shortestPath = null;
		foreach (var _charger in _chargers)
		{
			List<Node> _path = _dijkstra.GetShortestPath(_charger);
			//Console.WriteLine($"Shortest path to charger {_charger.Name}: {string.Join(" -> ", path.Select(n => n.Name))}");
			int _pathDistance = _path.Sum(n => _dijkstra.Distances[n]);

			Console.WriteLine($"Path to charger {_charger.Name}: {string.Join(" -> ", _path.Select(n => n.Name))}, Total Distance: {_pathDistance}");

			if (_pathDistance < _shortestDistance)
			{
				_shortestDistance = _pathDistance;
				_closestCharger = _charger;
				_shortestPath = _path;
			}
		}
		Console.WriteLine("_________________________________________________________________________________________");
		if (_closestCharger != null)
		{
			Console.WriteLine($"Most efficient route to a charging station is to {_closestCharger.Name} with a total distance of {_shortestDistance}.");
			Console.WriteLine($"Path: {string.Join(" -> ", _shortestPath.Select(n => n.Name))}");
		}
		else
		{
			Console.WriteLine("No path to a charging station was found.");
		}
	}
	/// <summary>
	/// Sets all nodes and their neighbors and returns a hashset of nodes.
	/// </summary>
	/// <param name="_printNodes"></param>
	/// <returns></returns>
	private static HashSet<Node> setNodes(bool _printNodes = false)
	{
		HashSet<Node> _nodes = new();

		Node _nodeA = new("A", false);
		Node _nodeB = new("B", false);
		Node _nodeC = new("C", false);
		Node _nodeD = new("D", false);
		Node _nodeE = new("E", false);
		Node _nodeF = new("F", false);
		Node _nodeG = new("G", false);
		Node _nodeH = new("H", true);
		Node _nodeI = new("I", false);
		Node _nodeJ = new("J", false);
		Node _nodeK = new("K", true);
		Node _nodeL = new("L", false);
		Node _nodeM = new("M", false);
		Node _nodeN = new("N", false);
		Node _nodeO = new("O", false);
		Node _nodeP = new("P", false);
		Node _nodeQ = new("Q", true);
		Node _nodeR = new("R", false);
		Node _nodeS = new("S", false);
		Node _nodeT = new("T", true);
		Node _nodeU = new("U", false);
		Node _nodeV = new("V", false);
		Node _nodeW = new("W", false);

		_nodes.Add(_nodeA);
		_nodes.Add(_nodeB);
		_nodes.Add(_nodeC);
		_nodes.Add(_nodeD);
		_nodes.Add(_nodeE);
		_nodes.Add(_nodeF);
		_nodes.Add(_nodeG);
		_nodes.Add(_nodeH);
		_nodes.Add(_nodeI);
		_nodes.Add(_nodeJ);
		_nodes.Add(_nodeK);
		_nodes.Add(_nodeL);
		_nodes.Add(_nodeM);
		_nodes.Add(_nodeN);
		_nodes.Add(_nodeO);
		_nodes.Add(_nodeP);
		_nodes.Add(_nodeQ);
		_nodes.Add(_nodeR);
		_nodes.Add(_nodeS);
		_nodes.Add(_nodeT);
		_nodes.Add(_nodeU);
		_nodes.Add(_nodeV);
		_nodes.Add(_nodeW);

		_nodeA.AddNeighbor(_nodeB, 6);
		_nodeA.AddNeighbor(_nodeF, 5);

		_nodeB.AddNeighbor(_nodeA, 6);
		_nodeB.AddNeighbor(_nodeG, 6);
		_nodeB.AddNeighbor(_nodeC, 5);

		_nodeC.AddNeighbor(_nodeB, 5);
		_nodeC.AddNeighbor(_nodeH, 5);
		_nodeC.AddNeighbor(_nodeD, 7);

		_nodeD.AddNeighbor(_nodeC, 7);
		_nodeD.AddNeighbor(_nodeI, 8);
		_nodeD.AddNeighbor(_nodeE, 7);

		_nodeE.AddNeighbor(_nodeD, 7);
		_nodeE.AddNeighbor(_nodeI, 6);
		_nodeE.AddNeighbor(_nodeN, 15);

		_nodeF.AddNeighbor(_nodeA, 5);
		_nodeF.AddNeighbor(_nodeJ, 7);
		_nodeF.AddNeighbor(_nodeG, 8);

		_nodeG.AddNeighbor(_nodeB, 6);
		_nodeG.AddNeighbor(_nodeF, 8);
		_nodeG.AddNeighbor(_nodeH, 9);
		_nodeG.AddNeighbor(_nodeK, 8);

		_nodeH.AddNeighbor(_nodeG, 9);
		_nodeH.AddNeighbor(_nodeC, 5);
		_nodeH.AddNeighbor(_nodeI, 12);

		_nodeI.AddNeighbor(_nodeE, 6);
		_nodeI.AddNeighbor(_nodeM, 10);
		_nodeI.AddNeighbor(_nodeD, 8);
		_nodeI.AddNeighbor(_nodeH, 12);

		_nodeJ.AddNeighbor(_nodeF, 7);
		_nodeJ.AddNeighbor(_nodeO, 7);
		_nodeJ.AddNeighbor(_nodeK, 5);

		_nodeK.AddNeighbor(_nodeJ, 5);
		_nodeK.AddNeighbor(_nodeL, 7);
		_nodeK.AddNeighbor(_nodeG, 8);

		_nodeL.AddNeighbor(_nodeK, 7);
		_nodeL.AddNeighbor(_nodeM, 7);
		_nodeL.AddNeighbor(_nodeP, 7);

		_nodeM.AddNeighbor(_nodeI, 10);
		_nodeM.AddNeighbor(_nodeN, 9);
		_nodeM.AddNeighbor(_nodeL, 7);

		_nodeN.AddNeighbor(_nodeM, 9);
		_nodeN.AddNeighbor(_nodeR, 7);

		_nodeO.AddNeighbor(_nodeJ, 7);
		_nodeO.AddNeighbor(_nodeP, 13);
		_nodeO.AddNeighbor(_nodeS, 9);

		_nodeP.AddNeighbor(_nodeO, 13);
		_nodeP.AddNeighbor(_nodeL, 7);
		_nodeP.AddNeighbor(_nodeQ, 8);
		_nodeP.AddNeighbor(_nodeU, 11);

		_nodeQ.AddNeighbor(_nodeP, 8);
		_nodeQ.AddNeighbor(_nodeR, 9);

		_nodeR.AddNeighbor(_nodeN, 7);
		_nodeR.AddNeighbor(_nodeQ, 9);
		_nodeR.AddNeighbor(_nodeW, 10);

		_nodeS.AddNeighbor(_nodeO, 9);
		_nodeS.AddNeighbor(_nodeT, 9);

		_nodeT.AddNeighbor(_nodeS, 9);
		_nodeT.AddNeighbor(_nodeU, 8);

		_nodeU.AddNeighbor(_nodeT, 8);
		_nodeU.AddNeighbor(_nodeV, 8);
		_nodeU.AddNeighbor(_nodeP, 11);

		_nodeV.AddNeighbor(_nodeU, 8);
		_nodeV.AddNeighbor(_nodeW, 5);

		_nodeW.AddNeighbor(_nodeV, 5);
		_nodeW.AddNeighbor(_nodeR, 10);

		if (_printNodes)
		{
			foreach (var node in _nodes)
			{
				Console.WriteLine(node);
			}
		}

		return _nodes;
	}
}
