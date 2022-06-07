using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRoom2Change : MonoBehaviour
{
    //[SerializeField] GameObject Playerprefab;

   // private Vector2 position;

    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    /*private void OnEnable()
    {
        position = transform.position;
        position.y += 1;
        Instantiate(Playerprefab, position, Quaternion.identity);
    }*/
}
