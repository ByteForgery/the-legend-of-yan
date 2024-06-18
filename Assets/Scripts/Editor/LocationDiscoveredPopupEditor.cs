using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LocationDiscoveredPopup))]
public class LocationDiscoveredPopupEditor : Editor
{
    private LocationDiscoveredPopup popup;
    
    private void Awake()
    {
        popup = (LocationDiscoveredPopup)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        bool isPlaying = Application.isPlaying;
        
        if (!isPlaying) EditorGUI.BeginDisabledGroup(true);
        if (GUILayout.Button("Show"))
            popup.Show("Yan's House", "Hyrule Hills");
        if (!isPlaying) EditorGUI.BeginDisabledGroup(false);
    }
}
