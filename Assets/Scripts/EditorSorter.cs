//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//[CustomEditor(typeof(EditZ))]
//public class ObjectBuilderEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        EditZ myScript = (EditZ)target;
//        if (GUILayout.Button("Sort"))
//        {
//            myScript.RandomSortingLayer();
//        }
//        if (GUILayout.Button("EditZ"))
//        {
//            myScript.SortingZ();
//        }
//        if (GUILayout.Button("AddTag"))
//        {
//            myScript.AddTag();
//        }
//        if (GUILayout.Button("AddScript"))
//        {
//            myScript.AddPaintingScript();
//        }
//        if (GUILayout.Button("AddPolygonCollider"))
//        {
//            myScript.AddPolygonCollider();
//        }
//    }
//}
