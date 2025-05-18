using System.Collections.Generic;

namespace Puzzlenator;

using Tiles;

/// <summary>
/// Represents a Archetype for concrete tiles has a collection of properties.
/// </summary>
public class TileArchetype(params TileProperty[] props)
{
    readonly HashSet<TileProperty> properties = [ ..props ];

    public bool HasProp(TileProperty property)
        => properties.Contains(property);

    /// <summary>
    /// Create a new tile based on this archetype.
    /// </summary>
    public Tile Create(int x, int y)
        => new(x, y, this);

    public static readonly WallArchetype Wall = new();
    public static readonly PathArchetype Path = new();
    public static readonly GoalArchetype Goal = new();
}