using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetTester))]
public class PlanetEditor : Editor
{
    PlanetTester planet;
    Editor planetEditor;

    public override void OnInspectorGUI()
    {

        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.CreatePlanet();                
            }
        }
            
        if (GUILayout.Button("Create Planet")) // A simple button to allow me to create a planet without Update Setting set to true
        {
            planet.CreatePlanet();
        }

        DrawSettingsEditor(planet.planetSettings, planet.OnPlanetSettingsUpdate, ref planet.hideSettings, ref planetEditor);
        DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdate, ref planet.hideSettings, ref planetEditor);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool hide, ref Editor editor)
    {
        if (settings != null)
        {
            hide = EditorGUILayout.InspectorTitlebar(hide, settings); // Makes the settings sections more visible in the editor.
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (hide == true)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();

                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
            }
        }         
    }

    private void OnEnable()
    {
        planet = (PlanetTester)target;
    }
}
