using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public PlayerSpawnerScript playerSpawn;
    public static bool CanRestart = false;

    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame() 
    {
        SoundManagerScript.PlaySoundBomDia();
        playerSpawn.InstantiatePlayer();
        gameOverPanel.SetActive(false);
    }

    public void GameOver() 
    {
        gameOverPanel.SetActive(true);
        if(!CanRestart)
            SoundManagerScript.PlaySoundSextaFeira();
        CanRestart = true;
    }

    public void RestartGame() 
    {
        CanRestart = false;
        if (!CanRestart) 
        {
            ScoreScript.scoreValue = 0;
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            StartGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRestart && Input.GetKey(KeyCode.Return))
        {
            RestartGame();
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            GameOver();
    }
}
