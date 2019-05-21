using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltExplosions : MonoBehaviour
{
    private GameObject parent;
    public GameObject boltExplotion;
    public GameObject playerExplotion;
    
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;

        if (other.tag == "Bolt")
        {
            Instantiate(boltExplotion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag != parent.tag)
        {
             Instantiate(playerExplotion, transform.position, transform.rotation);
             Destroy(gameObject);
             Destroy(other.gameObject);
        }

        //gameController.AddScore(scoreValue);
    }

    public void setParent(GameObject parent)
    {
        this.parent = parent;
    }
}
