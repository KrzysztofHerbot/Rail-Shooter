using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] AudioClip enemyHit;
    [SerializeField] GameObject HitVFX;
    [SerializeField] int scoreWorth = 50;
    [SerializeField] int enemyHitPoints = 4;
    [SerializeField] Transform parent;
    int enemyHealth;
    AudioSource SoundBoom;
    ScoreBoard Sboard;
    Rigidbody rb;
    //bool isHit;

    /* void FixedUpdate()
     {
         if(isHit)
         {
             transform.localPosition = new Vector3(0, transform.localPosition.y - 10f, 0); //fix it later so enemy ship falls down
         }

    }*/

    private void Start()
    {
        parent = GameObject.FindWithTag("SpawnAtRuntime").transform;
        gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        SoundBoom = GetComponent<AudioSource>();
        Sboard = FindObjectOfType<ScoreBoard>();
        enemyHealth = enemyHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        Sboard.IncreaseScore(1);
        SoundBoom.PlayOneShot(enemyHit);
        GameObject vfx = Instantiate(HitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        if (enemyHealth < 1)
        { 
        killEnemy();
        Destroy(rb.GetComponent<Rigidbody>());
        Sboard.IncreaseScore(scoreWorth);
        }
        //isHit = true;

    }

    private void killEnemy()
    {
        GameObject vfx = Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

}
