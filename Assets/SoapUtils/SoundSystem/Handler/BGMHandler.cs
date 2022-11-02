using AnimeRx;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class BGMHandler
    {
        [Inject] private readonly SoundView view;

        private CompositeDisposable stopDisposable;
        private CompositeDisposable startDisposable;

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

        private void Change(AudioClip clip, float volume)
        {
            var sound = view.GetBgmSound();

            stopDisposable?.Dispose();
            stopDisposable = new CompositeDisposable();

            Anime.Play(sound.volume, 0, Easing.Linear(0.25f))
                 .DoOnCompleted(() =>
                 {
                     sound.Stop();

                     if (sound.clip != null)
                         Addressables.Release(sound.clip);

                     sound.clip = clip;

                     if (clip == null) return;

                     sound.Play();

                     startDisposable?.Dispose();
                     startDisposable = new CompositeDisposable();
                     
                     Anime.Play(sound.volume, 1, Easing.Linear(0.25f))
                          .Subscribe(volume => sound.volume = volume)
                          .AddTo(startDisposable);
                 })
                 .Subscribe(volume => sound.volume = volume)
                 .AddTo(stopDisposable);
        }
    }
}