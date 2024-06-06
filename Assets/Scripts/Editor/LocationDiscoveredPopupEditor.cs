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
        
        if (GUILayout.Button("Show"))
            popup.Show("Hateno Marketplace", "Hateno");
    }
}
