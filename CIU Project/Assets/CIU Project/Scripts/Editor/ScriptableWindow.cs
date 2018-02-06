/// ScriptableWindow.cs Enero 6/2018 Antonio Moon
/// 

using System;
using System.Linq;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace MoonPincho
{

    internal class EndNameEdit : EndNameEditAction
    {
        #region Implementacion abstracta de miembros en EndNameEditAction
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(instanceId), AssetDatabase.GenerateUniqueAssetPath(pathName));
        }

        #endregion
    }

    /// <summary>
    /// Scriptable object window.
    /// </summary>
    public class ScriptableWindow : EditorWindow
    {

        private int selectedIndex;
        private string[] nombres;

        private Type[] types;

        public Type[] Types
        {
            get { return types; }
            set
            {
                types = value;
                nombres = types.Select(t => t.FullName).ToArray();
            }
        }

        public void OnGUI()
        {
            GUILayout.Label("ScriptableObject Class");
            selectedIndex = EditorGUILayout.Popup(selectedIndex, nombres);

            if (GUILayout.Button("Crear"))
            {
                var asset = ScriptableObject.CreateInstance(types[selectedIndex]);
                ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                    asset.GetInstanceID(),
                    ScriptableObject.CreateInstance<EndNameEdit>(),
                    string.Format("{0}.asset", nombres[selectedIndex]),
                    AssetPreview.GetMiniThumbnail(asset),
                    null);

                Close();
            }
        }
    }
}
