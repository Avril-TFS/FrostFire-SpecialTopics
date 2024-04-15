using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public Text victoryText;

    public GameObject menu;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Victory(col.gameObject);

        }
    }

    void Victory(GameObject player)
    {
        victoryText.text = "You Win!";
        

        PlayerController_ playerController = player.GetComponent<PlayerController_>();
        if(playerController != null)
        {
            playerController.RecordHighScore();
        }

        Time.timeScale = 0;

        menu.SetActive(true);
        restart.SetActive(true);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
