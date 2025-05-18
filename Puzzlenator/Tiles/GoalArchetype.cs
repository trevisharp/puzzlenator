namespace Puzzlenator.Tiles;

/// <summary>
/// Represents a simple goal tile archetype.
/// </summary>
public class GoalArchetype() : TileArchetype(
    TileProperty.Path,
    TileProperty.Goal
);