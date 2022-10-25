using UnityEngine;

namespace SoapUtils.SoundSystem
{
    public class SoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource   bgmSound;
        [SerializeField] private AudioSource   loopSound;
        [SerializeField] private AudioSource[] effectSound;

        private int effectSoundIndex = 0;

        public AudioSource GetBgmSound() => bgmSound;
        public AudioSource GetLoopSound() => loopSound;
        public AudioSource GetEffectSound()
        {
            AudioSource sound = effectSound[effectSoundIndex];

            effectSoundIndex++;

            if (effectSoundIndex >= effectSound.Length)
                effectSoundIndex = 0;

            return sound;
        }

        public void SetBGMSound(AudioSource sound) => bgmSound = sound;
        public void SetEffectSound(AudioSource[] sound) => effectSound = sound;
        public void SetLoopSound(AudioSource sound) => loopSound = sound;
    }
}