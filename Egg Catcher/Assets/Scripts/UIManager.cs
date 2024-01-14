using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMP_Text scoreText,lifeText;
    private int eggsCount,lifesRemaining=3;
    PlayerController player;
    [SerializeField] Animator gameOverAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;
       
    }

    private void Start()
    {
        eggsCount = 0;
        scoreText.text = "Score: "+ eggsCount.ToString();
        lifesRemaining = 3;
        lifeText.text= "Life Remaining: " + lifesRemaining;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void IncreaseScore()
    {
        eggsCount++;
       
        scoreText.text = "Score: " + eggsCount.ToString();
    }


    public void ReduceLife()
    {
        lifesRemaining--;
        if (lifesRemaining <= 0)
        {
            lifesRemaining = 0;
            player.Dead();
            gameOverAnim.SetTrigger("GameOver");
            Time.timeScale = 0;
        }


        lifeText.text = "Life Remaining: " + lifesRemaining;
    }


    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
