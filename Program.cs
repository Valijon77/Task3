using Task3.Game;
using Task3.Helpers;

public class Program
{
    public static void Main(string[] args)
    {
        Moves moves = Moves.Create(args);

        if (!GameRules.CheckBeforeGameStart(moves))
            return;

        GameProcedure procedure = new(moves);

        procedure.PlayTheGame();
    }
}
