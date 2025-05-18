using System.Collections.Generic;

namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle gravity effects.
/// </summary>
public class GravityRule : IRule
{
    public bool CanHandle(Stage stage, Tile currentTile, Move move)
    {
        int x = currentTile.X,
            y = currentTile.Y;
        
        var under = stage[x, y + 1];
        if (under is null)
            return false;
        
        if (under.Archetype.HasProperty(TileProperty.Wall))
            return false;
        
        return true;
    }

    public Tile Handle(Stage stage, Tile currentTile, Move move)
    {
        int x = currentTile.X, 
            y = currentTile.Y;
        
        return stage[x, y + 1]!;
    }

    public IEnumerable<(Move move, Tile tile)> GetNeighbors(Stage stage, Tile currentTile)
    {
        if (!CanHandle(stage, currentTile, Move.None))
            yield break;
        
        yield return (Move.None, Handle(stage, currentTile, Move.None));
    }
}