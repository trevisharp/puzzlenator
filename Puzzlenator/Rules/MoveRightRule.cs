namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle right movement.
/// </summary>
public class MoveRightRule : IRule
{
    public LegalMove? GetLegalMove(Stage stage, Tile currentTile)
    {
        int x = currentTile.X,
            y = currentTile.Y;
        
        var under = stage[x, y + 1];
        var right = stage[x + 1, y];

        if (right is null || right.Archetype.HasProperty(TileProperty.Wall))
            return null;

        if (under is not null && !under.Archetype.HasProperty(TileProperty.Wall))
            return null;
        
        return new LegalMove(right, [ Move.Left ]);
    }
}