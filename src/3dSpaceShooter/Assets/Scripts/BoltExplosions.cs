using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltExplosions : MonoBehaviour
{
    private GameObject parent;
    public GameObject boltExplotion;
    public GameObject playerExplotion;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameControler Script'");
        }
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

        if ( (other != null) && (parent != null) && (other.tag != parent.tag) )
        {
            Instantiate(playerExplotion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            switch (other.tag)
            {
                case "Player":
                case "Player2":
                    gameController.AddScore(10000, false);
                    gameController.IncPlayerKilled();
                    break;

                case "Player3":
                case "Player4":
                    gameController.AddScore(10000, true);
                    gameController.IncPlayerKilled();
                    break;
            }
        }

        if (other.gameObject.name.StartsWith("Asteroide") )
        {
            switch (parent.tag)
            {
                case "Player":
                case "Player2":
                    gameController.AddScore(100, true);
                    break;

                case "Player3":
                case "Player4":
                    gameController.AddScore(100, false);
                    break;
            }
        }
    }

    public void setParent(GameObject parent)
    {
        this.parent = parent;
    }
}
