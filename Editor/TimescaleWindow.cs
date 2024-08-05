using UnityEditor;
using UnityEngine;

namespace Sainna.Utils.Editor
{
    public class TimescaleWindow : EditorWindow
    {
        float timeScale = 1.00f;

        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/Timescale")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            TimescaleWindow w = (TimescaleWindow)EditorWindow.GetWindow(typeof(TimescaleWindow));
            w.titleContent = new GUIContent("Timescale");
            w.maxSize = new Vector2(2000, 150);
        }

        void OnGUI()
        {
            timeScale = EditorGUILayout.Slider("Timescale", timeScale, 0.1f, 3.0f);

            EditorGUILayout.Space();

            if (GUILayout.Button("Apply"))
            {
                Time.timeScale = timeScale;
            }

        }
    }
}