public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {   /// <summary>
        /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
        /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
        /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.

        /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
        /// </summary>

        // Step 1: Initialize an array to hold the multiples
        double[] multiples = new double[length];

        // Step 2: Fill the array with multiples of the number
        for (int i = 0; i < length; i++)
        {
            // Each element is the number multiplied by (i + 1)
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array
        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {   // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Calculate the effective rotation (handles cases where amount > data.Count)
        amount = amount % data.Count;

        // Step 2: Extract the last 'amount' elements
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);

        // Step 3: Remove the last 'amount' elements from the list
        data.RemoveRange(data.Count - amount, amount);

        // Step 4: Insert the extracted elements at the start of the list
        data.InsertRange(0, rotatedPart);
    }

}
