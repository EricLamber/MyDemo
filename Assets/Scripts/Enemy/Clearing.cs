using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearing : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    private void Update()
    {
        if(Enemy == null)
            Destroy(gameObject);
    }
}
