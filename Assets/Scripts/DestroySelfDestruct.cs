using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfDestruct : MonoBehaviour
{
    [SerializeField] float TimeUntilDestroy = 10f;
    [SerializeField] AudioClip EnemyExplosion;
    AudioSource SoundBoom;
    void Start()
    {
        SoundBoom = GetComponent<AudioSource>();
        SoundBoom.PlayOneShot(EnemyExplosion);
        Destroy(gameObject, TimeUntilDestroy);
    }

}
