using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SoapUtils.Runtime.SoundSystem
{
    public interface ISoundService
    {
        void PlayBGM(AssetReferenceT<AudioClip> clip);
        void PlaySound(AssetReferenceT<AudioClip> clip, float volume = 1);
    }
    
    public class SoundService : ISoundService
    {
        private AudioSource bgmSound;
        private AudioSource effectSound;

        public SoundService(AudioSource bgmSound, AudioSource effectSound)
        {
            this.bgmSound    = bgmSound;
            this.effectSound = effectSound;
        }

        public async void PlayBGM(AssetReferenceT<AudioClip> clip)
        {
            if (clip == null)
            {
                ChangeBGM(null);
            }
            else
            {
                Addressables.LoadAssetAsync<AudioClip>(clip).Completed += (handle) =>
                {
                    ChangeBGM(handle.Result);
                };
            }
        }

        private async void ChangeBGM(AudioClip clip)
        {
            // await Easing.Create<Linear>(1, 0, 0.25f).ToAction(volume => bgmSound.volume = volume);
            
            bgmSound.Stop();
                
            if(bgmSound.clip != null)
                Addressables.Release(bgmSound.clip);

            bgmSound.clip = clip;

            if (clip == null) return;
            
            bgmSound.Play();
            
            // await Easing.Create<Linear>(0, 1, 0.25f).ToAction(volume => bgmSound.volume = volume);
        }

        public void PlaySound(AssetReferenceT<AudioClip> clip, float volume = 1)
        {
            Addressables.LoadAssetAsync<AudioClip>(clip).Completed += handler =>
            {
                AudioClip result = handler.Result;

                effectSound.PlayOneShot(result, volume);

                Observable.Timer(TimeSpan.FromSeconds(result.length + 1))
                          .Subscribe(l => Addressables.Release(result));
            };
        }

        [Serializable]
        public class Settings
        {
            public AudioSource bgmSound;
            public AudioSource effectSound;
        }
    }
}