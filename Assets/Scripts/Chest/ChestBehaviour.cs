using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    [Header("References")]
    public Sprite openChestSprite;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    [Header("Attributes")]
    public int fruitsToEarn = 5;
    
    private bool _isOpen;

    private void Start()
    {
        _isOpen = false;
        GameManager.Instance.AddFruits(fruitsToEarn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isOpen && other.CompareTag("Player"))
        {
            _isOpen = true;
            spriteRenderer.sprite = openChestSprite;
            GameManager.Instance.CollectFruits(fruitsToEarn);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
