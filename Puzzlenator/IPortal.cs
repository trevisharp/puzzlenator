using System;

namespace Puzzlenator;

/// <summary>
/// Represents a Portal used to change rules based on tiles.
/// </summary>
public interface IPortal
{
    /// <summary>
    /// Return true if this portal can be activated.
    /// </summary>
    public bool CanHandle(TileArchetype move);

    /// <summary>
    /// Apply the rules associated with this portal
    /// based on a apply function.
    /// </summary>
    public void ApplyRules(Action<IRule> define);
}