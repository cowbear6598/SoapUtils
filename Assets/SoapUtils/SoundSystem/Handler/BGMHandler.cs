using AnimeTask;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class BGMHandler
    {
        [Inject] private readonly SoundView view;

        private AudioClip currentClip;

        public async void Play(AssetReferenceT<AudioClip> clipAsset, float volume = 1)
        {
            if (clipAsset == null)
            {
                Change(null, volume);
            }
            else
            {
                AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(clipAsset).Task;
                Change(clip, volume);
            }
        }

        private async void Change(AudioClip clip, float volume)
        {
            var sound = view.GetBgmSound();

            await Easing.Create<Linear>(1, 0, 0.25f).ToAction(delta => sound.volume = delta);

            sound.Stop();
            sound.clip = clip;

            if (currentClip != null)
                Addressables.Release(currentClip);

            currentClip = clip;
            
            if (clip == null) return;

            sound.Play();

            await Easing.Create<Linear>(0, volume, 0.25f).ToAction(delta => sound.volume = delta);
        }
    }
}