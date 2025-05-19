using System.Linq;
using System.Collections.Generic;

namespace Puzzlenator;

/// <summary>
/// Represent a set of rules.
/// If a rule are added twice, needs be removed twice.
/// </summary>
public class RuleSet
{
    class RuleItem(IRule rule)
    {
        public readonly IRule Rule = rule;
        public int Count { get; set; } = 1;
    }
    readonly Dictionary<string, RuleItem> rules = [];

    /// <summary>
    /// Get all rules.
    /// </summary>
    public IEnumerable<IRule> Rules => 
        from item in rules.Values
        select item.Rule;
    
    /// <summary>
    /// Get the quantity of rules.
    /// </summary>
    public int Count => rules.Count;

    /// <summary>
    /// Add a rule.
    /// </summary>
    public void Add(IRule rule)
    {
        var ruleName = rule.GetType().Name;
        if (rules.TryGetValue(ruleName, out var item))
        {
            item.Count++;
            return;
        }

        rules.Add(ruleName, new RuleItem(rule));
    }

    /// <summary>
    /// Remove a rule.
    /// </summary>
    public void Remove(IRule rule)
    {
        var ruleName = rule.GetType().Name;
        if (!rules.TryGetValue(ruleName, out var item))
            return;
        
        item.Count--;
        if (item.Count == 0)
            rules.Remove(ruleName);
    }

    /// <summary>
    /// Returns true if the rule set contains a specific rule.
    /// </summary>
    public bool Contains(IRule rule)
        => rules.ContainsKey(rule.GetType().Name);
}