/// <summary>
/// This queue is circular. When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue. Thus,
/// each person stays in the queue and is given turns. When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given. If the turns is 0 or
/// less than they will stay in the queue forever. If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new(); // Using the PersonQueue defined previously.

    public int Length => _people.Length; // Expose the length of the queue.

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        // Create a new person with the provided name and turns, and add them to the queue.
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns. An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        // Ensure there are people in the queue before proceeding.
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person in line.
        Person person = _people.Dequeue();

        // If the person has infinite turns (turns <= 0), re-add them to the back of the queue.
        if (person.Turns == 0 || person.Turns < 0)
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // If they have more than 1 turn, decrement the turns and re-add them to the queue.
            person.Turns--;
            _people.Enqueue(person);
        }
        // If person.Turns == 1, they won't be added back to the queue.

        return person;
    }

    /// <summary>
    /// Returns the string representation of the queue.
    /// </summary>
    public override string ToString()
    {
        // Return the internal queue's string representation.
        return _people.ToString();
    }
}
