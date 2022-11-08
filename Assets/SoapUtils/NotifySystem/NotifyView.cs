using System;
using System.Threading;
using AnimeTask;
using Cysharp.Threading.Tasks;
using SoapUtils.SoundSystem;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

namespace SoapUtils.NotifySystem
{
    public class NotifyView : MonoBehaviour
    {
        [Inject] private readonly ISoundService soundService;

        [SerializeField] private CanvasGroup     canvasGroup;
        [SerializeField] private RectTransform   bgPos;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private Button          cancelBtn;
        [SerializeField] private Button          confirmBtn;

        [SerializeField] private AssetReferenceT<AudioClip> clip_Click;
        [SerializeField] private AssetReferenceT<AudioClip> clip_Cancel;

        private CancellationTokenSource tokenSource;

        public void SetContent(string content)
        {
            contentText.text = content;

            confirmBtn.gameObject.SetActive(false);
            cancelBtn.gameObject.SetActive(false);
        }

        public void SetContent(string content, Action confirmAction)
        {
            contentText.text = content;

            confirmBtn.gameObject.SetActive(true);
            cancelBtn.gameObject.SetActive(false);

            SetButtonListener(confirmBtn, confirmAction, true);
        }

        public void SetContent(string content, Action confirmAction, Action cancelAction)
        {
            contentText.text = content;

            confirmBtn.gameObject.SetActive(true);
            cancelBtn.gameObject.SetActive(true);

            SetButtonListener(confirmBtn, confirmAction, true);
            SetButtonListener(cancelBtn, cancelAction, false);
        }

        private void SetButtonListener(Button button, Action action, bool IsConfirm)
        {
            button.onClick.RemoveAllListeners();

            button.onClick.AddListener(() =>
            {
                soundService.DoPlaySound(IsConfirm ? clip_Click : clip_Cancel);
                SetAppear(false);
            });
            button.onClick.AddListener(() => action?.Invoke());
        }

        public void SetAppear(bool IsOn)
        {
            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            float tweenTime = 0.1f;

            tokenSource?.Cancel();
            tokenSource = new CancellationTokenSource();

            Easing.Create<Linear>(IsOn ? 1 : 0, tweenTime).ToColorA(canvasGroup, tokenSource.Token);
            Easing.Create<Linear>(IsOn ? Vector3.one : Vector3.zero, tweenTime).ToLocalScale(bgPos, tokenSource.Token);
        }
    }
}