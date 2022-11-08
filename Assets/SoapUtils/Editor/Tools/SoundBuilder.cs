using SoapUtils.SoundSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace SoapUtils.Editor.Tools
{
    public class SoundBuilder : EditorWindow
    {
        [MenuItem("Soap/Sound Builder")]
        private static void ShowWindow()
        {
            var window = GetWindow<SoundBuilder>();
            window.titleContent = new GUIContent("Setting");
            window.Show();
        }

        private int             effectSoundCount = 0;
        private AudioMixerGroup bgmMixerGroup;
        private AudioMixerGroup effectMixerGroup;

        private void OnGUI()
        {
            bgmMixerGroup    = EditorGUILayout.ObjectField("BGM Mixer", bgmMixerGroup, typeof(AudioMixerGroup), false) as AudioMixerGroup;
            effectMixerGroup = EditorGUILayout.ObjectField("Effect Mixer", effectMixerGroup, typeof(AudioMixerGroup), false) as AudioMixerGroup;

            effectSoundCount = EditorGUILayout.IntField("Effect Sound Count: ", effectSoundCount);

            if (GUILayout.Button("Build"))
            {
                Build();
            }
        }

        private void Build()
        {
            Transform rootTrans = new GameObject("SoundGroup").transform;
            SoundView soundView = rootTrans.gameObject.AddComponent<SoundView>();

            // 創建背景音樂
            AudioSource bgmSound = new GameObject("BGM_Sound").AddComponent<AudioSource>();
            bgmSound.outputAudioMixerGroup = bgmMixerGroup;
            bgmSound.playOnAwake           = false;
            bgmSound.loop                  = true;
            bgmSound.transform.SetParent(rootTrans);

            soundView.SetBGMSound(bgmSound);

            // 創建音效
            AudioSource[] effectSounds = new AudioSource[effectSoundCount];

            for (int i = 0; i < effectSoundCount; i++)
            {
                AudioSource effectSound = new GameObject($"Effect_Sound_{i + 1}").AddComponent<AudioSource>();
                effectSound.outputAudioMixerGroup = effectMixerGroup;
                effectSound.playOnAwake           = false;
                effectSound.transform.SetParent(rootTrans);

                effectSounds[i] = effectSound;
            }

            soundView.SetEffectSound(effectSounds);

            // 創建循環音效
            AudioSource loopSound = new GameObject("Loop_Sound").AddComponent<AudioSource>();
            loopSound.outputAudioMixerGroup = effectMixerGroup;
            loopSound.playOnAwake           = false;
            loopSound.loop                  = true;
            loopSound.transform.SetParent(rootTrans);

            soundView.SetLoopSound(loopSound);

            EditorUtility.SetDirty(soundView);
        }
    }
}