using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        if(GameObject.Find("Player(Clone)") == null)
        Instantiate(player);
    }
}
