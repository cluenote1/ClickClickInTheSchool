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
    }

    public void CalculateScore()
    {
        GameManager.Instance.CalculateScore(isApple);

        Destroy();
    }

}
