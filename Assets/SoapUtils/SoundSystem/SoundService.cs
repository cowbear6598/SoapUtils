using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SoapUtils.SoundSystem
{
    internal class SoundService : ISoundService
    {
        [Inject] private BGMHandler    bgmHandler;
        [Inject] private EffectHandler effectHandler;
        [Inject] private LoopHandler   loopHandler;

        public void DoPlayBGM(AssetReferenceT<AudioClip> clip, float volume = 1) => bgmHandler.Play(clip, volume);
        public void DoPlaySound(AssetReferenceT<AudioClip> clip, float volume = 1, float pitch = 1) => effectHandler.Play(clip, volume, pitch);
        public void DoPlayLoop(AssetReferenceT<AudioClip> clip, float volume = 1) => loopHandler.Play(clip, volume);
    }
}