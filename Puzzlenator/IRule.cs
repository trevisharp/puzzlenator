namespace Puzzlenator;

using Rules;

/// <summary>
/// Represents a mobility game rule.
/// </summary>
public interface IRule
{
    /// <summary>
    /// Return a collection of pairs (Move, Tile) of
    /// possible moves.
    /// </summary>
    public LegalMove? GetLegalMove(Stage stage, Tile currentTile);

    public static readonly GravityRule Gravity = new();
    public static readonly MoveLeftRule Left = new();
    public static readonly MoveRightRule Right = new();
}