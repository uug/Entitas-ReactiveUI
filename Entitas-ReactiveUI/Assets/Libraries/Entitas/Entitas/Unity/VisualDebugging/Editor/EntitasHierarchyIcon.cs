﻿using UnityEditor;
using UnityEngine;

namespace Entitas.Unity.VisualDebugging {

    [InitializeOnLoad]
    public static class EntitasHierarchyIcon {
        static Texture2D hierarchyIcon {
            get {
                if (_hierarchyIcon == null) {
                    _hierarchyIcon = EntitasEditorLayout.LoadTexture("l:Entitas-HierarchyIcon");
                }
                return _hierarchyIcon;
            }
        }

        static Texture2D _hierarchyIcon;

        static EntitasHierarchyIcon() {
            EditorApplication.hierarchyWindowItemOnGUI += onHierarchyWindowItemOnGUI;
        }

        static void onHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject != null) {
                if (gameObject.GetComponent<PoolObserverBehaviour>() != null
                    || gameObject.GetComponent<EntityBehaviour>() != null
                    || gameObject.GetComponent<DebugSystemsBehaviour>() != null) {

                    const float iconSize = 16f;
                    const float iconOffset = iconSize + 2f;
                    var rect = new Rect(selectionRect.x + selectionRect.width - iconOffset, selectionRect.y, iconSize, iconSize);
                    GUI.DrawTexture(rect, hierarchyIcon);
                }
            }
        }
    }
}