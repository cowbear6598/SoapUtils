using UnityEngine;

namespace SoapUtils.Runtime.SceneSystem
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        
        public async void SetAppear(bool IsOn)
        {
            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            // await Easing.Create<Linear>(IsOn ? 1 : 0, 0.25f).ToColorA(canvasGroup);
        }
    }
}