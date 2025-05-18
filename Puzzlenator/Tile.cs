namespace Puzzlenator;

/// <summary>
/// Represents a single tile on game map.
/// </summary>
public record Tile(
    int X, int Y,
    TileArchetype Archetype
);