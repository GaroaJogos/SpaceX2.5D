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
    public Transform shotSpawn;
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
                if ((Input.GetButton("Fire1Joy1")) && (Time.time > nextFire))
                {
                    nextFire = Time.time + fireRate;
                    GameObject child = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    BoltExplosions boltExplosions = child.GetComponent<BoltExplosions>();
                    boltExplosions.setParent(this.gameObject);
                    sound.Play();
                }
                break;


            case "Player2":
                if ((Input.GetButton("Fire1Joy2")) && (Time.time > nextFire2))
                {
                    nextFire2 = Time.time + fireRate;
                    GameObject child = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    BoltExplosions boltExplosions = child.GetComponent<BoltExplosions>();
                    boltExplosions.setParent(this.gameObject);
                    sound.Play();
                }
                break;

            case "Player3":
                if ((Input.GetButton("Fire1Joy3")) && (Time.time > nextFire3))
                {
                    nextFire3 = Time.time + fireRate;
                    GameObject child = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    BoltExplosions boltExplosions = child.GetComponent<BoltExplosions>();
                    boltExplosions.setParent(this.gameObject);
                    sound.Play();
                }
                break;

            case "Player4":
                if ((Input.GetButton("Fire1Joy4")) && (Time.time > nextFire4))
                {
                    nextFire4 = Time.time + fireRate;
                    GameObject child = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    BoltExplosions boltExplosions = child.GetComponent<BoltExplosions>();
                    boltExplosions.setParent(this.gameObject);
                    sound.Play();
                }
                break;
        }
    }

    private void firePlayer()
    {
        
        {
            
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
                break;

            case "Player2":
                playerRotation = 90f;
                moveHorizontal = Input.GetAxis("HorizontalJoy2");
                moveVertical = Input.GetAxis("VerticalJoy2") * (-1);
                break;

            case "Player3":
                playerRotation = 270f;
                moveHorizontal = Input.GetAxis("HorizontalJoy3");
                moveVertical = Input.GetAxis("VerticalJoy3") * (-1);
                break;

            case "Player4":
                playerRotation = 270f;
                moveHorizontal = Input.GetAxis("HorizontalJoy4");
                moveVertical = Input.GetAxis("VerticalJoy4") * (-1);
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

        rigidbody.rotation = Quaternion.Euler(0.0f, playerRotation, rigidbody.velocity.z * -tilt);
    }
}
