using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] GameObject Boom;
    [SerializeField] AudioClip ac;
    AudioSource SoundBoom;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + "! You've hit " + collision.gameObject.name);
        StartCrash();
        
    }
    void StartCrash()
    {
        SoundBoom = GetComponent<AudioSource>();
        SoundBoom.PlayOneShot(ac);
        Boom.SetActive(true);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
