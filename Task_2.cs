// Your program should start at this line.

void SolveMaze()
{
    if (AtGoal())
    {
        // The goal has been reached.
        return;
    }

    if (Peek())
    {
        // If the path ahead is clear, move forward.
        Move();
        
        // After moving, attempt to solve the maze from the new position.
        SolveMaze();

        if (AtGoal())
        {
            // If the goal is reached after moving, the maze is solved.
            return;
        }
        else
        {
            // If the goal is not reached, backtrack.
            Turn();
            Turn(); // Turn around (180 degrees).
            Move();
            Turn();
            Turn(); // Turn back to the original direction.
        }
    }

    // Turn right and try the next direction.
    Turn();
    SolveMaze();

    // If the goal wasn't reached, try turning again (turning left from original direction).
    if (!AtGoal())
    {
        Turn();
        Turn();
        Turn();
        SolveMaze();
    }

    // If the goal still wasn't reached, turn back to the original direction (right turn to correct the previous left).
    if (!AtGoal())
    {
        Turn();
    }
}

// Start solving the maze from the car's starting position.
SolveMaze();
