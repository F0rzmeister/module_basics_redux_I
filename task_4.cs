public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public Node Parent { get; set; }

    // Additional properties might include costs used in A* (G, H, and F costs)
}

// ... other necessary implementations for A* ...

public Node AStar(Node start, Node goal)
{
    var openSet = new PriorityQueue<Node>();
    var closedSet = new HashSet<Node>();

    openSet.Enqueue(start, 0);

    while (openSet.Count > 0)
    {
        var current = openSet.Dequeue();

        if (current.Equals(goal))
        {
            return current; // Path has been found
        }

        closedSet.Add(current);

        foreach (var neighbor in GetWalkableNeighbors(current))
        {
            if (closedSet.Contains(neighbor))
                continue;

            if (!openSet.Contains(neighbor))
            {
                neighbor.Parent = current;
                neighbor.Cost = current.Cost + 1; // Assuming each move has a cost of 1
                openSet.Enqueue(neighbor, neighbor.Cost + Heuristic(neighbor, goal));
            }
        }
    }

    return null; // No path found
}

// You would call AStar like this:
Node start = new Node { X = startX, Y = startY };
Node goal = new Node { X = goalX, Y = goalY };
Node result = AStar(start, goal);

// If result is not null, you would then need to backtrack from the goal node to the start node
// to build your path, and then translate that into a sequence of `Move()` and `Turn()` calls.
