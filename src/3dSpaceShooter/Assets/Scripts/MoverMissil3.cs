using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMissil3 : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "Missil3(Clone)")
            speed = speed * (-1);

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed * (-1);
    }
}
