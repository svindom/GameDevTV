using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // this things position (camera) should be the same as the car' position

    [SerializeField] GameObject thingToFollow;
    [SerializeField] Vector3 cameraPosition = new Vector3(0, 0, -10);
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + cameraPosition; 
    }
}
