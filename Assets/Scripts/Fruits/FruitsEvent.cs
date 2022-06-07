using System;
using UnityEngine;
using UnityEngine.Events;


public class FruitsEvent
{
    public static UnityEvent OnFruit = new UnityEvent();

    public static void SendFruit()
    {
        OnFruit.Invoke();
    }
}
