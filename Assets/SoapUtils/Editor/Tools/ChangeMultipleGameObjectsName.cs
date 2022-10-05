using System.Collections.Generic;
using SoapUtils.Runtime.Utils;
using UnityEditor;
using UnityEngine;

namespace SoapUtils.Editor.Tools
{
    public class ChangeMultipleGameObjectsName : EditorWindow
    {
        [MenuItem("Soap/ChangeMultipleGameObjectsName")]
        private static void ShowWindow()
        {
            var window = GetWindow<ChangeMultipleGameObjectsName>();
            window.titleContent = new GUIContent("Setting");
            window.Show();
        }

        private string prefixesName = "";
        private string suffixesName = "";
        private int    startOrder   = 0;

        private class GameObjectOriginData
        {
            public Transform parent;
            public Vector3   localPosition;

            public GameObjectOriginData(Transform parent, Vector3 localPosition)
            {
                this.parent        = parent;
                this.localPosition = localPosition;
            }
        }

        private Dictionary<int, GameObjectOriginData> originDataDictionary = new(); 

        private void OnGUI()
        {
            prefixesName = EditorGUILayout.TextField("Prefixes Name: ", prefixesName);
            suffixesName = EditorGUILayout.TextField("Suffixes Name: ", suffixesName);
            startOrder   = EditorGUILayout.IntField("Start Order: ", startOrder);

            if (GUILayout.Button("Change"))
            {
                Change();
            }
        }

        private void Change()
        {
            int          startIndex   = startOrder;
            
            Transform[] selectedObjs   = Selection.transforms;
            int[]       selectedObjsOrder = new int[selectedObjs.Length];

            for (int i = 0; i < selectedObjs.Length; i++)
            {
                selectedObjsOrder[i] = selectedObjs[i].transform.root.GetSiblingIndex();
            }

            Transform[] orderObjs = SortUtils.BubbleSort(selectedObjsOrder, selectedObjs);

            for (int i = 0; i < orderObjs.Length; i++)
            {
                orderObjs[i].name = prefixesName + startIndex + suffixesName;
                startIndex++;
            }
        }
    }
}