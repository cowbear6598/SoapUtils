using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SoapUtils.SoundSystem
{
    public interface ISoundService
    {
        void DoPlayBGM(AssetReferenceT<AudioClip> clip, float volume = 1);
        void DoPlaySound(AssetReferenceT<AudioClip> clip, float volume = 1, float pitch = 1);
        void DoPlaySound3D(AssetReferenceT<AudioClip> clip, Vector3 position, float volume = 1);
        void DoPlayLoop(AssetReferenceT<AudioClip> clip, float volume = 1);
    }
}