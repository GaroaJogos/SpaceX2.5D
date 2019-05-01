using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
