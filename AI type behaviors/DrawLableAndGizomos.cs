using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLableAndGizomos : MonoBehaviour
{
    public static DrawLableAndGizomos instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }



    public static void DrawRay(Vector3 position, Vector3 Direction, Color color)
    {
        if (Direction.sqrMagnitude > 0.001f)
        {
            Debug.DrawRay(position, Direction, color);
            UnityEditor.Handles.color = color;
            UnityEditor.Handles.DrawSolidDisc(position + Direction, Vector3.up, 0.25f);
        }




    }
    public static void DrawLabel(Vector3 position, string lable, Color color)
    {
        UnityEditor.Handles.BeginGUI();
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.Label(position, lable);
        UnityEditor.Handles.EndGUI();




    }
}
