using System.Collections.Generic;

namespace Puzzlenator;

using Rules;

/// <summary>
/// Represents a mobility game rule.
/// </summary>
public interface IRule
{
    /// <summary>
    /// Get it the current rule can handle a request.
    /// </summary>
    public bool CanHandle(
        Stage stage,
        Tile currentTile,
        Move move
    );

    /// <summary>
    /// Handle a request and return the next player tile.
    /// </summary>
    public Tile Handle(
        Stage stage,
        Tile currentTile,
        Move move
    );

    /// <summary>
    /// Return a collection of pairs (Move, Tile) of
    /// possible moves.
    /// </summary>
    public IEnumerable<(Move move, Tile tile)> GetNeighbors(
        Stage stage,
        Tile currentTile
    );

    public static readonly GravityRule Gravity = new();
    public static readonly MoveLeftRule Left = new();
    public static readonly MoveRightRule Right = new();
}