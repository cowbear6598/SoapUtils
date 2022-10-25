using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class LoopHandler
    {
        [Inject] private readonly SoundView view;

        public void Play(AssetReferenceT<AudioClip> clip, float volume)
        {
            var sound = view.GetLoopSound();
            
            if (clip == null)
            {
                sound.Stop();
                
                if (sound.clip != null)
                    Addressables.Release(sound.clip);

                sound.clip = null;
                return;
            }
            
            Addressables.LoadAssetAsync<AudioClip>(clip).Completed += handler =>
            {
                sound.Stop();

                if (sound.clip != null)
                    Addressables.Release(sound.clip);

                sound.clip   = handler.Result;
                sound.volume = volume;

                sound.Play();
            };
        }
    }
}