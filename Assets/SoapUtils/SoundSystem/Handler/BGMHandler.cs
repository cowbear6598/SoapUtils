using AnimeTask;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class BGMHandler
    {
        [Inject] private readonly SoundView view;
        
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
            var sound    = view.GetBgmSound();
            var lastClip = sound.clip;
            
            await Easing.Create<Linear>(1, 0, 0.25f).ToAction(delta => sound.volume = delta);

            sound.Stop();
            sound.clip = clip;

            if (lastClip == null)
                Addressables.Release(lastClip);

            if (clip == null) return;
            
            sound.Play();
            
            await Easing.Create<Linear>(0, volume, 0.25f).ToAction(delta => sound.volume = delta);
        }
    }
}