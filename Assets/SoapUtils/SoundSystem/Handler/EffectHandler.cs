using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class EffectHandler
    {
        [Inject] private readonly SoundView view;

        public async void Play(AssetReferenceT<AudioClip> clipAsset, float volume = 1, float pitch = 1)
        {
            AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(clipAsset).Task;
            
            var sound = view.GetEffectSound();
                
            sound.pitch        = pitch;
            sound.spatialBlend = 0;
            sound.PlayOneShot(clip, volume);

            Observable.Timer(TimeSpan.FromSeconds(clip.length + 1))
                      .Subscribe(l => Addressables.Release(clip));
        }

        public async void Play3D(AssetReferenceT<AudioClip> clipAsset, Vector3 position, float volume = 1)
        {
            AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(clipAsset).Task;
            
            var sound = view.GetEffectSound();
                
            sound.transform.position = position;
            sound.spatialBlend       = 1.0f;
            sound.PlayOneShot(clip, volume);

            Observable.Timer(TimeSpan.FromSeconds(clip.length + 1))
                      .Subscribe(l => Addressables.Release(clip));
        }
    }
}