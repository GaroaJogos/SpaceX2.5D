using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float wavetWait;
    private int scoreTeam1;
    private int scoreTeam2;

    public Text scoreTextTeam1;
    public Text scoreTextTeam2;
    public Text restarText;
    public Text restarText2;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int playerkilled;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restart = false;

        restarText.text = "";
        restarText2.text = "";
        gameOverText.text = "";

        restarText.enabled = false;
        restarText2.enabled = false;
        gameOverText.enabled = false;

        playerkilled = 0;
        scoreTeam1 = 0;
        scoreTeam2 = 0;
        UpDateScore(true);
        UpDateScore(false);
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (playerkilled >= 3)
            GameOver();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavetWait);

            if (gameOver)
            {

                restart = true;
                break;
            }
        }
    }

    public void AddScore(int value, bool team1)
    {
        if (team1)
            scoreTeam1 += value;
        else
            scoreTeam2 += value;

        UpDateScore(team1);
    }

    void UpDateScore(bool team1)
    {
        if(team1)
            scoreTextTeam1.text = "Team 1 Score: " + scoreTeam1;
        else
            scoreTextTeam2.text = "Team 2 Score: " + scoreTeam2;
    }

    public void GameOver()
    {
        if (scoreTeam1 > scoreTeam2)
            restarText2.text = "Time 1 Venceu";
        else if (scoreTeam1 < scoreTeam2)
            restarText2.text = "Time 2 Venceu";
        else
            restarText2.text = "Empate";

        restarText.text = "Pressione 'R' para reiniciar";

        gameOverText.text = "Game Over!";
        gameOver = true;

        restarText.enabled = true;
        restarText2.enabled = true;
        gameOverText.enabled = true;
    }

    public void IncPlayerKilled()
    {
        ++playerkilled;
    }

}
