using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority. The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        // Create a new PriorityItem with the given value and priority.
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode); // Add new item to the back of the queue.
    }

    /// <summary>
    /// Removes and returns the value with the highest priority in the queue. If there
    /// are multiple items with the same priority, the first item added (FIFO) is removed.
    /// </summary>
    /// <returns>The value with the highest priority</returns>
    public string Dequeue()
    {
        // Check if the queue is empty before trying to dequeue.
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Start by assuming the first item has the highest priority.
        var highestPriorityIndex = 0;

        // Loop through the queue to find the highest priority item.
        for (int index = 1; index < _queue.Count; index++)
        {
            // Compare priorities and keep track of the highest priority index.
            if (_queue[index].Priority > _queue[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = index;
            }
        }

        // Retrieve the value of the highest priority item.
        var value = _queue[highestPriorityIndex].Value;
        // Remove the highest priority item from the queue.
        _queue.RemoveAt(highestPriorityIndex);

        return value; // Return the value of the removed item.
    }

    /// <summary>
    /// Returns the string representation of the priority queue, showing each item's value and priority.
    /// </summary>
    /// <returns>A string representing the priority queue</returns>
    public override string ToString()
    {
        // Format the internal queue as a string for display.
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    // Properties to store the value and priority of the item.
    internal string Value { get; set; }
    internal int Priority { get; set; }

    // Constructor to initialize the value and priority.
    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    /// <summary>
    /// Returns a string representation of the priority item, showing the value and priority.
    /// </summary>
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
