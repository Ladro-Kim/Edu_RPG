using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    // 재생객체 -> Audio Source
    // 오디오소스 가져오기 -> Audio Clip
    // 관객 -> Audio Listener

    AudioSource[] _audioSources = new AudioSource[(int)Define.Audio.MaxCount];    

    public void Init()
    {
        GameObject go_sound = GameObject.Find("@Sound");
        if (go_sound == null)
        {
            go_sound = new GameObject("@Sound");
            UnityEngine.Object.DontDestroyOnLoad(go_sound);

            string[] names = Enum.GetNames(typeof(Define.Audio));
            for (int i = 0; i < names.Length - 1; i++)
            {
                GameObject go = new GameObject { name = names[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = go_sound.transform;
            }
            _audioSources[(int)Define.Audio.BGM].loop = true;
        }
    }

    public void Play(Define.Audio audioType, string path, float pitch = 1.0f)
    {
        AudioClip audioClip = Managers._resource.Load<AudioClip>($"Sounds/{path}");
        if (audioClip == null)
        {
            Debug.Log($"AudioClip Missing : {path}");
            return;
        }
        AudioSource audioSource;

        switch (audioType)
        {
            case Define.Audio.BGM:
                audioSource = _audioSources[(int)Define.Audio.BGM];
                
                if (audioSource.isPlaying)
                    audioSource.Stop();

                audioSource.pitch = pitch;
                audioSource.clip = audioClip;
                audioSource.Play();

                break;
            case Define.Audio.Effect:
                audioSource = _audioSources[(int)Define.Audio.Effect];
                audioSource.pitch = pitch;
                audioSource.PlayOneShot(audioClip);
                break;
        }
    }


}
