/// CustomAlineacionDatabaseInspector.cs Enero 6/2018 Antonio Moon
/// 

using UnityEngine;
using UnityEditor;

namespace MoonPincho.Alineacion.Editors
{
    [CustomEditor(typeof(AlineacionDataBase))]
    public class CustomAlineacionDatabaseInspector : Editor
    {
        AlineacionDataBase db;
        bool modo = true;

        private void OnEnable()
        {
            db = (AlineacionDataBase)target;
        }

        public override void OnInspectorGUI()
        {
            if (modo == true)
            {
                #region Modo ON
                GUILayout.BeginVertical("box");
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.Space(10);

                GUILayout.Label("Alineaciones Totales: " + db.alineaciones.Count);
                if (GUILayout.Button("Añadir Alineacion"))
                    AgregarAlineacion();

                GUILayout.Space(10);
                GUILayout.EndHorizontal();
                GUILayout.Space(5);
                GUILayout.EndVertical();
                GUILayout.Space(20);

                for (int cnt = 0; cnt < db.alineaciones.Count; cnt++)
                {
                    GUILayout.BeginHorizontal();
                    db.alineaciones[cnt].nombreAlineacion = GUILayout.TextField(db.alineaciones[cnt].nombreAlineacion, GUILayout.Width(100));
                    db.alineaciones[cnt].ColorFondo = EditorGUILayout.ColorField(db.alineaciones[cnt].ColorFondo);
                    if (GUILayout.Button("X"))
                    {
                        QuitarAlineacion(cnt);
                        return;
                    }

                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("Añadir Alineacion"))
                    AgregarAlineacion();

                if (GUILayout.Button(string.Format("Modo X : {0}", modo)))
                {
                    if (modo != true)
                    {
                        modo = true;
                    }
                    else
                    {
                        modo = false;
                    }
                }

                //Muestra la base de las var
                //GUILayout.Space(20);
                //base.OnInspectorGUI();
                #endregion
            }
            else
            {
                #region Modo OFF
                GUILayout.BeginVertical("box");
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.Space(10);

                GUILayout.Label("Alineaciones Totales: " + db.alineaciones.Count);
                if (GUILayout.Button("Añadir Alineacion"))
                    AgregarAlineacion();

                GUILayout.Space(10);
                GUILayout.EndHorizontal();
                GUILayout.Space(5);
                GUILayout.BeginVertical();
                GUILayout.Space(20);

                for (int cnt = 0; cnt < db.alineaciones.Count; cnt++)
                {
                    GUILayout.BeginHorizontal();
                    db.alineaciones[cnt].nombreAlineacion = GUILayout.TextField(db.alineaciones[cnt].nombreAlineacion, GUILayout.Width(100));
                    db.alineaciones[cnt].ColorFondo = EditorGUILayout.ColorField(db.alineaciones[cnt].ColorFondo);
                    if (GUILayout.Button("X"))
                    {
                        QuitarAlineacion(cnt);
                        return;
                    }

                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("Añadir Alineacion"))
                    AgregarAlineacion();

                if (GUILayout.Button(string.Format("Modo X : {0}", modo)))
                {
                    if (modo != true)
                    {
                        modo = true;
                    }
                    else
                    {
                        modo = false;
                    }
                }
                GUILayout.EndVertical();
                //Muestra la base de las var
                //GUILayout.Space(20);
                //base.OnInspectorGUI();
                #endregion
            }

        }

        private void AgregarAlineacion()
        {
            db.alineaciones.Add(new Alineacion());
        }

        private void QuitarAlineacion(int index)
        {
            db.alineaciones.RemoveAt(index);
        }
    }
}
