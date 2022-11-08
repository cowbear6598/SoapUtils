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

        public void Play(AssetReferenceT<AudioClip> clip, float volume = 1, float pitch = 1)
        {
            Addressables.LoadAssetAsync<AudioClip>(clip).Completed += handler =>
            {
                AudioClip result = handler.Result;

                var sound = view.GetEffectSound();
                sound.pitch        = pitch;
                sound.spatialBlend = 0;
                sound.PlayOneShot(result, volume);

                Observable.Timer(TimeSpan.FromSeconds(result.length + 1))
                          .Subscribe(l => Addressables.Release(result));
            };
        }

        public void Play3D(AssetReferenceT<AudioClip> clip, Vector3 position, float volume = 1)
        {
            Addressables.LoadAssetAsync<AudioClip>(clip).Completed += handler =>
            {
                AudioClip result = handler.Result;

                var sound = view.GetEffectSound();
                sound.transform.position = position;
                sound.spatialBlend       = 1.0f;
                sound.PlayOneShot(result, volume);

                Observable.Timer(TimeSpan.FromSeconds(result.length + 1))
                          .Subscribe(l => Addressables.Release(result));
            };
        }
    }
}