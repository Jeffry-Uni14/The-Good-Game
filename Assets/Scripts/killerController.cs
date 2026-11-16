using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killerController : MonoBehaviour
{
    //To import the player object
    public GameObject Player;

    //To import the respawn point object
    public Transform respawnPoint;


    void Update()

    {

    }

    //Kills player and respawns the player at a respawn point 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Player.transform.position = respawnPoint.position;
        }
    }

}
