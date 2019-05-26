using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explotion;
    public GameObject playerExplotion;
    public int scoreValue;
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

        if ( other.tag.StartsWith("Player"))
        {
            Instantiate(playerExplotion, other.transform.position, other.transform.rotation);
            
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

        Instantiate(explotion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
