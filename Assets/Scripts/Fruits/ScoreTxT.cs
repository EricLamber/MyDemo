using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTxT : MonoBehaviour
{
    private int x;

    private void Awake()
    {
        FruitsEvent.OnFruit.AddListener(TxT);
    }

    private void TxT()
    {
        x++;
        GetComponent<Text>().text = $"Score: " + x;
    }
}
