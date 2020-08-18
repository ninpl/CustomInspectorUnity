/// ScriptableCore.cs Enero 6/2018 Antonio Moon
/// 

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace MoonPincho
{
    /// <summary>
    /// Helper class para instanciar ScriptableObjects.
    /// </summary>
    public class ScriptableCore
    {
        [MenuItem("Assets/Create/ScriptableObject")]
        [MenuItem("Moon Pincho/Create/ScriptableObject")]
        public static void Create()
        {
            var assembly = GetAssembly();

            // Obtener todas las clases que derivan de ScriptableObject
            var allScriptableObjects = (from t in assembly.GetTypes()
                                        where t.IsSubclassOf(typeof(ScriptableObject))
                                        select t).ToArray();

            // Mostrar la ventana de seleccion.
            var window = EditorWindow.GetWindow<ScriptableWindow>(true, "Crear un nuevo ScriptableObject", true);
            window.ShowPopup();

            window.Types = allScriptableObjects;
        }

        /// <summary>
        /// Devuelve el ensamblado que contiene el código de secuencia de comandos para este proyecto (en la actualidad no modificable)
        /// </summary>
        private static Assembly GetAssembly()
        {
            return Assembly.Load(new AssemblyName("Assembly-CSharp"));
        }
    }
}
