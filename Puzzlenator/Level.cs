using System;
using System.Collections.Generic;

namespace Puzzlenator;

/// <summary>
/// Represents a level with stage, rules and initial position for a player.
/// </summary>
public record Level(
    Stage Stage,
    RuleSet Rules,
    IEnumerable<IPower> Powers,
    IEnumerable<IPortal> Portals,
    int PlayerStartX,
    int PLayerStartY
)
{
    public static Level GetExample(int level)
        => level switch
        {
            1 => Level1,
            _ => throw new Exception($"Unknow level {level}.")
        };

    static Level? level1 = null;
    static Level Level1 =>
        level1 ??= new(
            Stage.CreateRounded(3, TileArchetype.Path, TileArchetype.Path, TileArchetype.Goal),
            [ IRule.Left, IRule.Right, IRule.Gravity ],
            [], [],
            1, 1
        );
}