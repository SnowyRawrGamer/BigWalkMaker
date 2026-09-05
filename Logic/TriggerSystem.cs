using System.Collections.Generic;
using UnityEngine;

namespace BigWalkMaker.Logic;

public sealed class TriggerSystem : MonoBehaviour
{
    private readonly Dictionary<string, List<string>> _links = new();
    private readonly HashSet<string> _active = new();

    public void Link(string triggerGuid, string targetGuid)
    {
        if (!_links.TryGetValue(triggerGuid, out var targets)) _links[triggerGuid] = targets = new();
        if (!targets.Contains(targetGuid)) targets.Add(targetGuid);
    }

    public void Fire(string triggerGuid)
    {
        if (!_links.TryGetValue(triggerGuid, out var targets)) return;
        foreach (var target in targets) _active.Add(target);
    }

    public bool IsActive(string targetGuid) => _active.Contains(targetGuid);
}
