// Your program should start at this line.

while (!AtGoal())
{
    // If the path is clear ahead, move forward.
    if (Peek())
    {
        Move();
    }
    else
    {
        // If the path is not clear, turn right until it is clear.
        Turn();
        while (!Peek())
        {
            Turn();
        }
        Move();
    }

    // Always try to keep the wall on your right, so if there is an opening, take it.
    Turn();
    if (Peek())
    {
        Move();
    }
    else
    {
        // If there's no opening on the right, turn back to the original direction.
        Turn();
        Turn();
        Turn();
    }

    // Check if we've reached the goal after each move.
    if (AtGoal())
    {
        break;
    }
}
