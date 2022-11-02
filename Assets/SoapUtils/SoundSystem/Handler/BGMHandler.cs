using AnimeTask;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class BGMHandler
    {
        [Inject] private readonly SoundView view;
        
        public void Play(AssetReferenceT<AudioClip> clip, float volume = 1)
        {
            if (clip == null)
            {
                Change(null, volume);
            }
            else
            {
                Addressables.LoadAssetAsync<AudioClip>(clip).Completed += handle => Change(handle.Result, volume);
            }
        }
        
        private async void Change(AudioClip clip, float volume)
        {
            var sound = view.GetBgmSound();
            
            await Easing.Create<Linear>(1, 0, 0.25f).ToAction(delta => sound.volume = delta);

            sound.Stop();
                
            if(sound.clip != null)
                Addressables.Release(sound.clip);

            sound.clip = clip;

            if (clip == null) return;
            
            sound.Play();
            
            await Easing.Create<Linear>(0, volume, 0.25f).ToAction(delta => sound.volume = delta);
        }
    }
}