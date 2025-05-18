namespace Puzzlenator.Tiles;

/// <summary>
/// Represents a simple wall tile archetype.
/// </summary>
public class WallArchetype() : TileArchetype(
    TileProperty.Get("WALL")
);