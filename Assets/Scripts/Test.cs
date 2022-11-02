using System;
using System.Threading;
using AnimeTask;
using Cysharp.Threading.Tasks;
using SoapUtils.DatabaseSystem;
using SoapUtils.SoundSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

public class Test : MonoBehaviour
{
    [Inject] private readonly IDatabaseService databaseService;
    [Inject] private readonly ISoundService    soundService;

    [SerializeField] private AssetReferenceT<AudioClip> clipBGM;
    [SerializeField] private AssetReferenceT<AudioClip> clipLoop;
    [SerializeField] private AssetReferenceT<AudioClip> clipEffect;

    [SerializeField] private Image testImg;

    private CancellationTokenSource tokenSource;

    private bool IsOn = false;

    private async void Start()
    {
        Debug.Log(await databaseService.DoGet(0, "/receipt/get"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            soundService.DoPlayBGM(clipBGM);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            soundService.DoPlayBGM(null);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            soundService.DoPlayLoop(clipLoop);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            soundService.DoPlayLoop(null);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            soundService.DoPlaySound(clipEffect, 1, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TestCancel();
        }
    }

    private async void TestCancel()
    {
        IsOn = !IsOn;

        tokenSource?.Cancel();
        tokenSource = new CancellationTokenSource();

        Easing.Create<Linear>(IsOn ? 1 : 0, 1f).ToColorA(testImg, tokenSource.Token);
        Easing.Create<Linear>(IsOn ? Vector3.one : Vector3.zero, 1f).ToLocalScale(testImg.transform, tokenSource.Token);
    }
}