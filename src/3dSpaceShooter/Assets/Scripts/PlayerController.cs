using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
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

    private float nextFire;
    private float nextFire2;
    private float nextFire3;
    private float nextFire4;

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        switch(player.name)
        {
            case "Player":
                firePlayer("Fire1Joy1");
                //firePlayer("Fire1");
                break;

            case "Player2":
                firePlayer("Fire1Joy2");
                //firePlayer("Fire1");
                break;

            case "Player3":
                firePlayer("Fire1Joy3");
                //firePlayer("Fire1");
                break;

            case "Player4":
                firePlayer("Fire1Joy4");
                //firePlayer("Fire1");
                break;
        }
    }

    private void firePlayer(string input)
    {
        if ((Input.GetButton(input)) && (Time.time > nextFire))
        {
            GameObject child = null;

            if (shotSpawn2 != null)
                shot2 = !shot2;

            if (shot2)
                child = Instantiate(shot, shotSpawn2.position, shot.transform.rotation);
            else
                child = Instantiate(shot, shotSpawn1.position, shot.transform.rotation);

            nextFire = Time.time + fireRate;
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

        switch (player.name)
        {
            case "Player":
                playerRotation = 90f;
                moveHorizontal = Input.GetAxis("HorizontalJoy1");
                moveVertical = Input.GetAxis("VerticalJoy1");

                //moveHorizontal = Input.GetAxis("Horizontal");
                //moveVertical = Input.GetAxis("Vertical");

                break;

            case "Player2":
                //playerRotation = 90f;
                moveHorizontal = Input.GetAxis("HorizontalJoy2");
                moveVertical = Input.GetAxis("VerticalJoy2") * (-1);

                //moveHorizontal = Input.GetAxis("Horizontal");
                //moveVertical = Input.GetAxis("Vertical");
                break;

            case "Player3":
                playerRotation = 270f;
                moveHorizontal = Input.GetAxis("HorizontalJoy3");
                moveVertical = Input.GetAxis("VerticalJoy3") * (-1);

                //moveHorizontal = Input.GetAxis("Horizontal");
                //moveVertical = Input.GetAxis("Vertical");

                break;

            case "Player4":
                playerRotation = 180f;
                moveHorizontal = Input.GetAxis("HorizontalJoy4");
                moveVertical = Input.GetAxis("VerticalJoy4") * (-1);

                //moveHorizontal = Input.GetAxis("Horizontal");
                //moveVertical = Input.GetAxis("Vertical");

                break;
        }

        rigidbody = player.GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );


        switch (player.name)
        {
            case "Player":
                rigidbody.rotation = Quaternion.Euler(0.0f, playerRotation, rigidbody.velocity.z * -tilt * (-1));
                break;

            case "Player2":
                rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.z * -tilt * (-1), playerRotation, 0f);
                break;

            case "Player3":
                rigidbody.rotation = Quaternion.Euler(0.0f, playerRotation, rigidbody.velocity.z * -tilt * (-1));
                break;

            case "Player4":
                //rigidbody.rotation = Quaternion.Euler(0.0f, playerRotation, rigidbody.velocity.z * -tilt * (-1));
                rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.z * -tilt, playerRotation, 0f);
                break;
        }
        
    }
}
