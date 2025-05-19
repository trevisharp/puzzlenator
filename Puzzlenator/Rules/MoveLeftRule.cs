namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle left movement.
/// </summary>
public class MoveLeftRule : IRule
{
    public LegalMove? GetLegalMove(Stage stage, Tile currentTile)
    {
        int x = currentTile.X,
            y = currentTile.Y;
        
        var under = stage[x, y + 1];
        var left = stage[x - 1, y];

        if (left is null || left.Archetype.HasProperty(TileProperty.Wall))
            return null;

        if (under is not null && !under.Archetype.HasProperty(TileProperty.Wall))
            return null;
        
        return new LegalMove(left, [ Move.Left ]);
    }
}