namespace Task3.Helpers;

public class Moves : List<string>
{
    // Determines how many moves positioned after this move will lose to this move.
    private int ShiftNumber { get; set; }

    private Moves(string[] moves)
    {
        ShiftNumber = (int)((float)moves.Length / 2);
        AddRange([.. moves]);
    }

    public static Moves Create(string[] moves)
    {
        return new Moves(moves);
    }

    // Function works purely with indexes in the array.
    public List<int> GetWinnerIndexes(int startIndex)
    {
        int lastIndex = Count - 1;
        List<int> result = [];

        for (int i = 1; i <= ShiftNumber; i++)
        {
            if (lastIndex >= startIndex + i)
            {
                result.Add(startIndex + i);
            }
            else
            {
                result.Add((startIndex + i) % lastIndex - 1);
            }
        }

        return result;
    }
}
