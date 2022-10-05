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
        private bool   IsSameGroup  = true;

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
            IsSameGroup  = EditorGUILayout.Toggle("Same Group?", IsSameGroup);

            if (GUILayout.Button("Change"))
            {
                Change();
            }
        }

        private void Change()
        {
            int          startIndex   = startOrder;
            
            Transform[] selectedPos   = Selection.transforms;
            int[]       selectedPosOrder = new int[selectedPos.Length];

            for (int i = 0; i < selectedPos.Length; i++)
            {
                if (IsSameGroup)
                    selectedPosOrder[i] = selectedPos[i].GetSiblingIndex();
                else
                    selectedPosOrder[i] = selectedPos[i].transform.root.GetSiblingIndex();
            }

            Transform[] orderObjs = SortUtils.BubbleSort(selectedPosOrder, selectedPos);

            for (int i = 0; i < orderObjs.Length; i++)
            {
                orderObjs[i].name = prefixesName + startIndex + suffixesName;
                startIndex++;
            }
        }
    }
}