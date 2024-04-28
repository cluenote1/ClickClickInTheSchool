using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] audioClips; // 여러 오디오 클립을 저장할 배열

    public AudioSource audioSource; // 여러 오디오 소스를 저장할 배열

    private void Awake()
    {
        Instance = this;
    }

    public void Sound(int sound)
    {
        audioSource.clip = audioClips[sound];
        audioSource.Play();
    }


    
}

