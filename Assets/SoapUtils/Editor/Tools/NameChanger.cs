using System.Collections.Generic;
using SoapUtils.Utils;
using UnityEditor;
using UnityEngine;

namespace SoapUtils.Editor.Tools
{
    public class NameChanger : EditorWindow
    {
        [MenuItem("Soap/NameChanger")]
        private static void ShowWindow()
        {
            var window = GetWindow<NameChanger>();
            window.titleContent = new GUIContent("Setting");
            window.Show();
        }

        private string prefixesName   = "";
        private string suffixesName   = "";
        private int    startOrder     = 0;
        private bool   IsSameGroup    = true;
        private bool   IsGetRootOrder = false;

        private void OnGUI()
        {
            prefixesName = EditorGUILayout.TextField("Prefixes Name: ", prefixesName);
            suffixesName = EditorGUILayout.TextField("Suffixes Name: ", suffixesName);
            startOrder   = EditorGUILayout.IntField("Start Order: ", startOrder);
            IsSameGroup  = EditorGUILayout.Toggle("Same Group?", IsSameGroup);

            if (!IsSameGroup)
            {
                IsGetRootOrder = EditorGUILayout.Toggle("Order By Root?", IsGetRootOrder);
            }

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
                {
                    selectedPosOrder[i] = selectedPos[i].GetSiblingIndex();
                }
                else
                {
                    if (IsGetRootOrder)
                        selectedPosOrder[i] = selectedPos[i].root.GetSiblingIndex();
                    else
                        selectedPosOrder[i] = selectedPos[i].parent.GetSiblingIndex();
                }
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