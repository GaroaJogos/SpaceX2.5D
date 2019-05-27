using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rigidbody;

    public GameObject shot;
    public Transform shotSpawn1;
    public float fireRate;

    private float nextFire2;
    
    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((Input.GetButton("Fire1Joy2")) && (Time.time > nextFire2))
        {
            GameObject child = null;
            child = Instantiate(shot, shotSpawn1.position, shot.transform.rotation);

            nextFire2 = Time.time + fireRate;
            BoltExplosions boltExplosions = child.GetComponent<BoltExplosions>();

            boltExplosions.setParent(this.gameObject);
            sound.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        float playerRotation = 0;

        //playerRotation = 90f;
        moveHorizontal = Input.GetAxis("HorizontalJoy2");
        moveVertical = Input.GetAxis("VerticalJoy2") * (-1);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.z * -tilt * (-1), playerRotation, 0f);

    }
}
