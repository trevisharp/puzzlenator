using System;
using System.Collections.Generic;

namespace Puzzlenator;

/// <summary>
/// Represents a legal game move.
/// </summary>
public readonly struct Move
{
    static readonly HashSet<string> moves = [];

    /// <summary>
    /// Get a property or create if it does not already exist.
    /// </summary>
    public static Move Get(string name)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        moves.Add(name);
        return new Move(name);
    }

    private Move(string name)
        => Name = name;

    public readonly string Name;

    public override int GetHashCode()
        => Name.GetHashCode();

    public override bool Equals(object? obj)
        => obj is Move prop && prop.Name == Name;

    public static bool operator ==(Move left, Move right)
        => left.Equals(right);

    public static bool operator !=(Move left, Move right)
        => !left.Equals(right);

    public static readonly Move None = Get("NONE");
    public static readonly Move Left = Get("LEFT");
    public static readonly Move Right = Get("RIGHT");
}