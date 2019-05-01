using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explotion;
    public GameObject playerExplotion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;

        if (other.tag == "Player")
            Instantiate(playerExplotion, other.transform.position, other.transform.rotation);

        Instantiate(explotion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
