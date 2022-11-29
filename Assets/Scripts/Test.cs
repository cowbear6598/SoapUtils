using System;
using SoapUtils.SceneSystem;
using SoapUtils.SoundSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class Test : MonoBehaviour
{
    [Inject] private ISceneService sceneService;
    [Inject] private ISoundService soundService;

    [SerializeField] private AssetReference test1Scene;
    [SerializeField] private AssetReference test2Scene;

    [SerializeField] private AssetReferenceT<AudioClip> clip_BGM;
    [SerializeField] private AssetReferenceT<AudioClip> clip_Sound;
    [SerializeField] private AssetReferenceT<AudioClip> clip_Loop;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sceneService.DoLoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            sceneService.DoLoadScene(1);
        }
        
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            soundService.DoPlayBGM(clip_BGM);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            soundService.DoPlaySound(clip_Sound);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            soundService.DoPlayLoop(clip_Loop);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            soundService.DoPlayBGM(null);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            soundService.DoPlaySound(null);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            soundService.DoPlayLoop(null);
        }
    }
}