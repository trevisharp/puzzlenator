namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle gravity effects.
/// </summary>
public class GravityRule : IRule
{
    public LegalMove? GetLegalMove(Stage stage, Tile currentTile)
    {
        int x = currentTile.X,
            y = currentTile.Y;
        
        var under = stage[x, y + 1];
        if (under is null)
            return null;
        
        if (under.Archetype.HasProperty(TileProperty.Wall))
            return null;
        
        return new LegalMove(under, [ Move.Left, Move.Right, Move.None ]);
    }
}