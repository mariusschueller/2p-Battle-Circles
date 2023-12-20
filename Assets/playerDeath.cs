using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public ParticleSystem dedPar;

    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        dedPar = dedPar.GetComponent<ParticleSystem>();
    }
    

    // Update is called once per frame
     void Update()
    {
        if (HealthBarHandler.healthVal <= 0f && gameController.playing)
        {
            transform.position = new Vector2(player1.transform.position.x, player1.transform.position.y);
            dedPar.time = 0;
            dedPar.Play();
        }

        if (HealthBarHandler2.healthVal <= 0f && gameController.playing)
        {
            transform.position = new Vector2(player2.transform.position.x, player2.transform.position.y);
            dedPar.time = 0;
            dedPar.Play();
        }
    }
}
