﻿using System;
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
                sound.pitch = pitch;
                sound.PlayOneShot(result, volume);

                Observable.Timer(TimeSpan.FromSeconds(result.length + 1))
                          .Subscribe(l => Addressables.Release(result));
            };
        }
    }
}