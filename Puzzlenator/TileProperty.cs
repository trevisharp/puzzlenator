using System;
using System.Threading;
using System.Collections.Generic;

namespace Puzzlenator;

/// <summary>
/// Represents a property about a tile archetype.
/// </summary>
public readonly struct TileProperty
{
    static readonly Dictionary<string, TileProperty> properties = [];
    static int lastId = 0;
    static int GetNextId()
        => Interlocked.Increment(ref lastId);

    /// <summary>
    /// Get a property or create if it does not already exist.
    /// </summary>
    public static TileProperty Get(string name)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        if (properties.TryGetValue(name, out var prop))
            return prop;
        
        prop = new TileProperty(GetNextId(), name);
        properties.Add(name, prop);
        return prop;
    }

    private TileProperty(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public readonly int Id;
    public readonly string Name;

    public override int GetHashCode()
        => Id;

    public override bool Equals(object? obj)
        => obj is TileProperty prop && prop.Name == Name;

    public static bool operator ==(TileProperty left, TileProperty right)
        => left.Equals(right);

    public static bool operator !=(TileProperty left, TileProperty right)
        => !left.Equals(right);

    public static readonly TileProperty Path = Get("PATH");
    public static readonly TileProperty Wall = Get("WALL"); 
    public static readonly TileProperty Goal = Get("GOAL"); 
}