// Your program should start at this line.

while (!AtGoal())
{
    // Try to move forward.
    if (Peek())
    {
        Move();
    }
    // If the path ahead is blocked, try turning right.
    else
    {
        Turn();
        if (!Peek())
        {
            // If the right is also blocked, turn left twice (180 degrees turn).
            Turn();
            Turn();
        }
    }

    // After moving forward or turning right, check the right-hand side for an opening.
    Turn();
    if (Peek())
    {
        Move();
    }
    else
    {
        // No opening on the right, turn left to face forward again.
        Turn();
        Turn();
        Turn();
    }

    // Check if we've reached the goal after each move.
    if (AtGoal())
    {
        // Celebrate! 🚗🏁
        break;
    }
}
