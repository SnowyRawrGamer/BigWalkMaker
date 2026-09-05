using BepInEx.Unity.IL2CPP;
using UnityEngine;
using BigWalkMaker.Data;

namespace BigWalkMaker.UI;

public sealed class MainMenuPatch : MonoBehaviour
{
    private bool _showManager;
    private string _newLevelName = "My Level";
    private string _importText = "";

    public void OpenCustomMenu() => _showManager = true;

    private void OnGUI()
    {
        if (!_showManager)
        {
            if (GUI.Button(new Rect(20, 20, 160, 45), "Custom Levels"))
            {
                _showManager = true;
            }
            return;
        }

        GUILayout.BeginArea(new Rect(80, 80, 700, 560), GUI.skin.window);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Custom Levels");
        if (GUILayout.Button("X", GUILayout.Width(30)))
        {
            _showManager = false;
        }
        GUILayout.EndHorizontal();

        foreach (var level in LevelData.ListSavedLevels())
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(level);
            if (GUILayout.Button("Play", GUILayout.Width(80))) LevelData.Load(level);
            if (GUILayout.Button("Edit", GUILayout.Width(80))) LevelData.Load(level);
            GUILayout.EndHorizontal();
        }

        _newLevelName = GUILayout.TextField(_newLevelName);
        if (GUILayout.Button("Create New Level")) LevelData.Create(_newLevelName);
        GUILayout.Label("Import via Code / JSON");
        _importText = GUILayout.TextArea(_importText, GUILayout.Height(100));
        if (GUILayout.Button("Import")) LevelData.Import(_importText);
        if (GUILayout.Button("Close")) _showManager = false;
        GUILayout.EndArea();
    }
}
