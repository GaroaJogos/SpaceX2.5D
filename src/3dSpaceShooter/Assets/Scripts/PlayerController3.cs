using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rigidbody;

    public GameObject shot;
    public GameObject player;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    private bool shot2 = false;
    public float fireRate;

    private float nextFire3;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        rigidbody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((Input.GetButton("Fire1Joy3")) && (Time.time > nextFire3))
        {
            GameObject child = null;

            if (shotSpawn2 != null)
                shot2 = !shot2;

            if (shot2)
                child = Instantiate(shot, shotSpawn2.position, shot.transform.rotation);
            else
                child = Instantiate(shot, shotSpawn1.position, shot.transform.rotation);

            nextFire3 = Time.time + fireRate;
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

        playerRotation = 270f;
        moveHorizontal = Input.GetAxis("HorizontalJoy3");
        moveVertical = Input.GetAxis("VerticalJoy3") * (-1);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, playerRotation, rigidbody.velocity.z * -tilt * (-1));
    }
}
