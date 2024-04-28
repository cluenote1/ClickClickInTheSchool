using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip[] audioClips; // ���� ����� Ŭ���� ������ �迭

    public AudioSource audioSource; // ���� ����� �ҽ��� ������ �迭

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

