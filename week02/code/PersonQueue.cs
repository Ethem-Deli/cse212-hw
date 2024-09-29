using System.Collections.Generic;

/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    // Internal list to represent the queue. People are stored here.
    private readonly List<Person> _queue = new();

    // Property to get the number of people in the queue.
    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // Ensure the person being added is not null
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person), "Person cannot be null.");
        }

        // Insert the person at the beginning of the queue (FIFO behavior)
        _queue.Insert(0, person);
    }

    /// <summary>
    /// Remove and return the person from the back of the queue (FIFO)
    /// </summary>
    /// <returns>The person dequeued from the queue</returns>
    public Person Dequeue()
    {
        // Ensure there is at least one person in the queue
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty. Cannot dequeue.");
        }

        // Dequeue from the back to maintain FIFO order
        var person = _queue[^1]; 
        _queue.RemoveAt(_queue.Count - 1); // Remove the last person in the list
        return person;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    /// <returns>True if the queue is empty, false otherwise</returns>
    public bool IsEmpty()
    {
        // If Length is 0, the queue is empty
        return Length == 0;
    }

    /// <summary>
    /// Return the string representation of the queue
    /// </summary>
    /// <returns>Formatted string showing the queue contents</returns>
    public override string ToString()
    {
        // Format the list of people as a string
        return $"[{string.Join(", ", _queue)}]";
    }
}
//-------//