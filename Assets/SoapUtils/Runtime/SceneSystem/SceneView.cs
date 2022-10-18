using System;
using AnimeTask;
using UnityEngine;

namespace SoapUtils.Runtime.SceneSystem
{
    public class SceneView : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public async void SetAppear(bool IsOn)
        {
            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            await Easing.Create<Linear>(IsOn ? 1 : 0, 0.25f).ToColorA(canvasGroup);
        }
    }
}