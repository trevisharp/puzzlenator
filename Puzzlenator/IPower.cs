using System;

namespace Puzzlenator;

/// <summary>
/// Represents a Power used to change rules based on moves.
/// </summary>
public interface IPower
{
    /// <summary>
    /// Return true if this power can be activated.
    /// </summary>
    public bool CanHandle(Move move);

    /// <summary>
    /// Apply the rules associated with this power
    /// based on a apply function.
    /// </summary>
    public void ApplyRules(Action<IRule> define);
}