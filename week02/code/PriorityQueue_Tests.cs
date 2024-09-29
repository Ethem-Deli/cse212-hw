using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items to the queue with different priorities, and dequeue them in priority order.
    // Expected Result: Items are removed in the order of highest priority first.
    // Defect(s) Found: Initially, high-priority items weren't being dequeued properly.
    public void TestPriorityQueue_1()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        // Assert - Ensure that items are dequeued in the correct order of priority.
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same priority and test the FIFO order for those.
    // Expected Result: Items with the same priority should be dequeued in the order they were added.
    // Defect(s) Found: The FIFO order wasn't maintained when priorities were equal.
    public void TestPriorityQueue_2()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        // Assert - Ensure FIFO order for items with the same priority.
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: The exception was thrown correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();

        // Act & Assert - Expect an InvalidOperationException when attempting to dequeue from an empty queue.
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
