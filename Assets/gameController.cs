using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject ganvas;

    public static bool playing;
    public static int reset;

    public Text title;
    public Text playText;
    private bool firstPlay;

    void Start()
    {
        notPlaying();
        reset = 0;
        firstPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBarHandler.healthVal <= 0f && playing) 
        {
            player1.SetActive(false);
            notPlaying();
            title.text = "Player 2 Wins!";
            playText.text = "PLAY AGAIN";
        }


        if (HealthBarHandler2.healthVal <= 0f && playing) 
        {
            player2.SetActive(false);
            notPlaying();
            title.text = "Player 1 Wins!";
            playText.text = "PLAY AGAIN";
        }
    }

    public void startGame()
    {
        Debug.Log("play");
        HealthBarHandler.healthVal = 1f;
        HealthBarHandler.SetHealthBarValue(0f);

        HealthBarHandler2.healthVal = 1f;
        HealthBarHandler2.SetHealthBarValue(0f);

        if (!firstPlay)
        {
            reset = 4;
        }
        

        player1.SetActive(true);

        player2.SetActive(true);

        ganvas.SetActive(false);
        playing = true;
        firstPlay = false;
    }

    private void notPlaying()
    {
        playing = false;
        ganvas.SetActive(true);
    }
}
