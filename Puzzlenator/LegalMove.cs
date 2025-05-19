using System.Collections.Generic;

namespace Puzzlenator;

/// <summary>
/// Represents a legal move.
/// </summary>
public class LegalMove(
    Tile target,
    HashSet<Move> moves
)
{
    readonly HashSet<Move> moves = moves;
    public readonly Tile Target = target;

    public bool WithMove(Move move)
        => moves.Contains(move);
}