/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Check if moving left is possible (left direction is at index 0 in the array).
        if (_mazeMap[(_currX, _currY)][0])  // Left is at index 0
        {
            // If true, update the current X position (move left).
            _currX -= 1;
        }
        else
        {
            // Otherwise, throw an exception indicating a wall is present.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Check if moving right is possible (right direction is at index 1 in the array).
        if (_mazeMap[(_currX, _currY)][1])  // Right is at index 1
        {
            // If true, update the current X position (move right).
            _currX += 1;
        }
        else
        {
            // Otherwise, throw an exception indicating a wall is present.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Check if moving up is possible (up direction is at index 2 in the array).
        if (_mazeMap[(_currX, _currY)][2])  // Up is at index 2
        {
            // If true, update the current Y position (move up).
            _currY -= 1;
        }
        else
        {
            // Otherwise, throw an exception indicating a wall is present.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Check if moving down is possible (down direction is at index 3 in the array).
        if (_mazeMap[(_currX, _currY)][3])  // Down is at index 3
        {
            // If true, update the current Y position (move down).
            _currY += 1;
        }
        else
        {
            // Otherwise, throw an exception indicating a wall is present.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
