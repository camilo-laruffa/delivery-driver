using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followedObject;
    void LateUpdate()
    {
        transform.position = followedObject.transform.position + new Vector3(0,0,-10);
        
    }
}
