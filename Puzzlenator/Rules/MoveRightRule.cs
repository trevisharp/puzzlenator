using System.Collections.Generic;

namespace Puzzlenator.Rules;

/// <summary>
/// Represents a rule that handle right movement.
/// </summary>
public class MoveRightRule : IRule
{
    public bool CanHandle(Stage stage, Tile currentTile, Move move)
    {
        if (move != Move.Right)
            return false;
        
        int x = currentTile.X, 
            y = currentTile.Y;
        
        var right = stage[x + 1, y];
        if (right is null)
            return false;
        
        if (right.Archetype.HasProperty(TileProperty.Wall))
            return false;
        
        return true;
    }

    public Tile Handle(Stage stage, Tile currentTile, Move move)
    {
        int x = currentTile.X, 
            y = currentTile.Y;
        
        return stage[x + 1, y]!;
    }

    public IEnumerable<(Move move, Tile tile)> GetNeighbors(Stage stage, Tile currentTile)
    {
        if (!CanHandle(stage, currentTile, Move.Left))
            yield break;
        
        yield return (Move.Left, Handle(stage, currentTile, Move.Left));
    }
}