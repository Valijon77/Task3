using ConsoleTableExt;
using Task3.Helpers;

// using Program;

namespace Task3.Table;

public class HelpTable
{
    const string HeaderText = "User v \\ Computer >";
    static List<List<object>> SampleListData = [];

    public static void ConfigureTable(Moves moves)
    {
        var firstRow = moves.ToList<object>();

        firstRow.Insert(0, HeaderText);
        SampleListData.Add(firstRow);

        for (int i = 0; i < moves.Count; i++)
        {
            List<object> row =
                new(Enumerable.Repeat("Lose", moves.Count + 1))
                {
                    [0] = moves[i],
                    [i + 1] = "Draw"
                };

            var winnerIndexes = moves.GetWinnerIndexes(i);
            foreach (var index in winnerIndexes)
            {
                row[index + 1] = "Win";
            }

            SampleListData.Add(row);
        }
    }

    public static void DisplayTable()
    {
        ConsoleTableBuilder
            .From(SampleListData)
            .WithMetadataRow(
                MetaRowPositions.Top,
                b =>
                    string.Format(
                        "Here you can see the which move wins over another one. The table is constructued from user perspective."
                    )
            )
            .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
            .WithTitle("HELP TABLE")
            .ExportAndWriteLine(TableAligntment.Center);
    }
}
