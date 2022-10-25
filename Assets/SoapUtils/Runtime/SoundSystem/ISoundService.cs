using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SoapUtils.Runtime.SoundSystem
{
    public interface ISoundService
    {
        void PlayBGM(AssetReferenceT<AudioClip> clip);
        void PlaySound(AssetReferenceT<AudioClip> clip, float volume = 1);
    }
}