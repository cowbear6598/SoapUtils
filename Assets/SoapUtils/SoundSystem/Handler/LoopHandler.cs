using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class LoopHandler
    {
        [Inject] private readonly SoundView view;

        private AudioClip currentClip;

        public async void Play(AssetReferenceT<AudioClip> clipAsset, float volume)
        {
            var sound = view.GetLoopSound();

            sound.Stop();
            sound.clip = null;

            if (currentClip != null)
            {
                Addressables.Release(currentClip);
                currentClip = null;
            }

            if (clipAsset == null)
                return;

            currentClip = await Addressables.LoadAssetAsync<AudioClip>(clipAsset).Task;

            sound.clip   = currentClip;
            sound.volume = volume;

            sound.Play();
        }
    }
}