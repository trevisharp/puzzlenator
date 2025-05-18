using System.Collections.Generic;

namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle left movement.
/// </summary>
public class MoveLeftRule : IRule
{
    public bool CanHandle(Stage stage, Tile currentTile, Move move)
    {
        if (move != Move.Left)
            return false;
        
        int x = currentTile.X, 
            y = currentTile.Y;
        
        var left = stage[x - 1, y];
        if (left is null)
            return false;
        
        if (left.Archetype.HasProperty(TileProperty.Wall))
            return false;
        
        return true;
    }

    public Tile Handle(Stage stage, Tile currentTile, Move move)
    {
        int x = currentTile.X, 
            y = currentTile.Y;
        
        return stage[x - 1, y]!;
    }

    public IEnumerable<(Move move, Tile tile)> GetNeighbors(Stage stage, Tile currentTile)
    {
        if (!CanHandle(stage, currentTile, Move.Left))
            yield break;
        
        yield return (Move.Left, Handle(stage, currentTile, Move.Left));
    }
}