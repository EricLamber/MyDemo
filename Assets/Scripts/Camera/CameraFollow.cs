using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;
    [SerializeField] private Vector3 Position;

    private void LateUpdate()
    {
        transform.position = ObjectToFollow.position + Position;
    }

}
