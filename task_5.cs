// Your program should start at this line.

// We assume the car starts by facing up, so we need to adjust it first.
Turn(); // Face right
if (Peek()) Move();
else
{
    Turn(); Turn(); Turn(); // Face left
    if (Peek()) Move();
    else
    {
        Turn(); Turn(); // Face down
        while (!Peek()) // Find the direction to start moving
        {
            Turn();
        }
        Move();
    }
}

// Begin the maze solving process
while (!AtGoal())
{
    // Check the right side first
    Turn();
    if (Peek())
    {
        Move();
        if (AtGoal()) break;
    }
    else
    {
        // If right side is blocked, check front
        Turn();
        Turn();
        Turn();
        if (Peek())
        {
            Move();
            if (AtGoal()) break;
        }
        else
        {
            // If front is blocked, turn left
            Turn();
            Turn();
            Turn();
            while (!Peek())
            {
                // Rotate until there's a path
                Turn();
            }
            Move();
        }
    }
}
