using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
        if (isApple)
        {
            SoundManager.Instance.Sound(0);
        }
        if (!isApple)
        {
            SoundManager.Instance.Sound(1);
        }
    }

    public void GiveScoreAndDeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);

        Destroy();
    }

}
