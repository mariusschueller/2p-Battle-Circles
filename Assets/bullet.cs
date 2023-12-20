using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject deathParticlePrefab;

    private void Update()
    {
        if (transform.position.x > 12f || transform.position.x < -12f || transform.position.y > 5.5f || transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player 1 hit");
            //SceneManager.LoadScene(levelName);
            Instantiate(deathParticlePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            HealthBarHandler.SetHealthBarValue(.1f);
            Destroy(gameObject);
        }

        else if (other.CompareTag("player2"))
        {
            Debug.Log("player2 hit");
            Instantiate(deathParticlePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            HealthBarHandler2.SetHealthBarValue(.1f);
            Destroy(gameObject);
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)
    }
}
