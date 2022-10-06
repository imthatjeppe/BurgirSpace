using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventController))]
public class EventZoneEditor : Editor
{
    EventController _target;
    List<Editor> editors = new List<Editor>();
    bool showEditors;
    bool addEvent = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DrawButtons();
        DrawInspectors();
        PrefabUtility.RecordPrefabInstancePropertyModifications(_target);
    }

    void DrawButtons()
    {
        addEvent = EditorGUILayout.Foldout(addEvent, "Add Event", true);

        if (addEvent)
        {

            if (GUILayout.Button("Add Gravity Event"))
            {

                _target.AddEvent((GameEvent)CreateInstance(typeof(GravityEvent)));
                CreateEditors();
            }

            if (GUILayout.Button("Add Suction Event"))
            {

                _target.AddEvent((GameEvent)CreateInstance(typeof(SuctionEvent)));
                CreateEditors();
            }

            if (GUILayout.Button("Add Smoke Event"))
            {

                _target.AddEvent((GameEvent)CreateInstance(typeof(SmokeEvent)));
                CreateEditors();
            }

            EditorGUILayout.Space(10);
        }
    }

    void DrawInspectors()
    {

        if (editors.Count == 0) { return; }

        showEditors = EditorGUILayout.Foldout(showEditors, "Events", true);

        if (showEditors)
        {
            EditorGUILayout.BeginVertical("Box");

            for (int i = 0; i < editors.Count; i++)
            {

                _target.events[i].Minimized = EditorGUILayout.Foldout(_target.events[i].Minimized, _target.events[i].ToString(), true);

                if (!_target.events[i].Minimized) { continue; }

                editors[i].OnInspectorGUI();

                if (GUILayout.Button("Remove Event"))
                {
                    _target.RemoveEvent(i);
                    CreateEditors();
                }

                EditorGUILayout.BeginHorizontal();

                if (i != 0 && GUILayout.Button("Move Up"))
                {
                    _target.SwapElements(i, i - 1);
                    CreateEditors();
                }

                if (i != (editors.Count - 1) && GUILayout.Button("Move Down"))
                {
                    _target.SwapElements(i, i + 1);
                    CreateEditors();
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();
        }
    }

    void CreateEditors()
    {
        editors.Clear();
        foreach (GameEvent GameEvent in _target.events)
        {
            editors.Add(CreateEditor(GameEvent));
        }
    }

    private void OnEnable()
    {
        _target = (EventController)target;
        CreateEditors();
    }

}