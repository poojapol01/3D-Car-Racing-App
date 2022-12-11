using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Window/Waypoints Editor Tools")]
		public static void ShowWindow()
        {
			GetWindow<WaypointManagerWindow>("Waypoints Editor Tools");
		}
}
