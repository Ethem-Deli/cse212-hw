/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */
using Microsoft.VisualBasic.FileIO; 

public class Basketball
{
    public static void Run()
    {
        // Set the file path relative to the project directory (where the CSV file is located)
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "basketball.csv");

        // Check if the file exists at the provided path
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        var players = new Dictionary<string, int>();

        // Read the CSV file
        using var reader = new TextFieldParser(filePath);
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row

        // Process each row in the file
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0]; // Column 0: Player ID
            var points = int.Parse(fields[8]); // Column 8: Points scored that year

            // Update total points for the player
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        // Sort players by total points and take the top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .ToList();

        // Output the result
        Console.WriteLine("Top 10 Players by Career Points:");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{player.Key}: {player.Value}");
        }
    }
}