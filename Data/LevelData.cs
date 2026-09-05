using System.Text.Json;
using UnityEngine;

namespace BigWalkMaker.Data;

public sealed class LevelData
{
    public string Name { get; set; } = "Untitled";
    public List<BlockData> Blocks { get; set; } = new();
    public List<TriggerLink> Links { get; set; } = new();
    public static string DirectoryPath => Path.Combine(Application.persistentDataPath, "BigWalkMaker", "Levels");

    public static IEnumerable<string> ListSavedLevels() => Directory.Exists(DirectoryPath) ? Directory.EnumerateFiles(DirectoryPath, "*.json").Select(Path.GetFileName) : Enumerable.Empty<string>();
    public static LevelData Create(string name)
    {
        var level = new LevelData { Name = name };
        level.Blocks.Add(new BlockData { Id = Guid.NewGuid().ToString("N"), Prefab = "StarterFlatGround", Position = new Vector3(0, -0.5f, 0), Scale = new Vector3(20, 1, 20) });
        Save(level);
        // The builder should load a clean sandbox containing only this starter platform.
        return level;
    }
    public static LevelData? Load(string file) => File.Exists(Path.Combine(DirectoryPath, file)) ? JsonSerializer.Deserialize<LevelData>(File.ReadAllText(Path.Combine(DirectoryPath, file))) : null;
    public static void Import(string json) { var level = JsonSerializer.Deserialize<LevelData>(json); if (level != null) Save(level); }
    public static void Save(LevelData level) { Directory.CreateDirectory(DirectoryPath); File.WriteAllText(Path.Combine(DirectoryPath, level.Name + ".json"), JsonSerializer.Serialize(level, new JsonSerializerOptions { WriteIndented = true })); }
}

public sealed class BlockData { public string Id { get; set; } = ""; public string Prefab { get; set; } = ""; public Vector3 Position { get; set; } public Quaternion Rotation { get; set; } = Quaternion.identity; public Vector3 Scale { get; set; } = Vector3.one; }
public sealed class TriggerLink { public string TriggerId { get; set; } = ""; public string TargetId { get; set; } = ""; }
