using AnimeTask;
using UniRx;
using UnityEngine;

namespace SoapUtils.SceneSystem
{
    public class SceneView : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        [SerializeField] private RectTransform loadingTrans;
        [SerializeField] private float         rotateSpeed;
        
        private CompositeDisposable updateDisposable;
            
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void UpdateEvent(long frame)
        {
            loadingTrans.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime), Space.Self);
        }
        
        public async void SetAppear(bool IsOn)
        {
            if (IsOn)
            {
                updateDisposable = new CompositeDisposable();
                Observable.EveryUpdate().Subscribe(UpdateEvent).AddTo(updateDisposable);
            }

            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            await Easing.Create<Linear>(IsOn ? 1 : 0, 0.25f).ToColorA(canvasGroup);
            
            if(!IsOn)
                updateDisposable.Dispose();
        }
    }
}