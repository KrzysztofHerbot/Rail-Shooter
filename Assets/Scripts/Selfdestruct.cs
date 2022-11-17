using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    [SerializeField] float TimeUntilDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, TimeUntilDestroy);
    }

}
