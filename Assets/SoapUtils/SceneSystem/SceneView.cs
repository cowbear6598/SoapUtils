using AnimeRx;
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
        private CompositeDisposable alphaDisposable;
            
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void UpdateEvent(long frame)
        {
            loadingTrans.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime), Space.Self);
        }
        
        public void SetAppear(bool IsOn)
        {
            if (IsOn)
            {
                updateDisposable = new CompositeDisposable();
                Observable.EveryUpdate().Subscribe(UpdateEvent).AddTo(updateDisposable);
            }

            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            alphaDisposable?.Dispose();
            
            alphaDisposable = new CompositeDisposable();

            Anime.Play(canvasGroup.alpha, IsOn ? 1 : 0, Easing.Linear(0.25f))
                 .Subscribe(alpha => canvasGroup.alpha = alpha)
                 .AddTo(alphaDisposable);

            if(!IsOn)
                updateDisposable.Dispose();
        }
    }
}