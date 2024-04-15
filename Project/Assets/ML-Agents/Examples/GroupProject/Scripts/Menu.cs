using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject startButton, instructionsButton, quitButton, backButton;
    public GameObject instructionText;
    public GameObject titleText;
    
    private Quaternion camStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        camStartRotation = Camera.main.transform.rotation;

        titleText.SetActive(true);
        instructionText.SetActive(false);

        startButton.SetActive(true);
        instructionsButton.SetActive(true);
        quitButton.SetActive(true);
        backButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Shooter");
    }
   /* public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");     I dont think we use this?
    }*/
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        StartCoroutine(ShowInstructions()); ;
    }
    private IEnumerator ShowInstructions()
    {
        Camera.main.transform.Rotate(new Vector3(0, 180, 0));

        titleText.SetActive(false);
        instructionText.SetActive(true);

        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        quitButton.SetActive(false);
        backButton.SetActive(true);

        yield return null;
    }
    public void BackButton()
    {
        StartCoroutine(ReturnToMenu());
    }
    private IEnumerator ReturnToMenu()
    {
        Camera.main.transform.rotation = camStartRotation;

        titleText.SetActive(true);
        instructionText.SetActive(false);

        startButton.SetActive(true);
        instructionsButton.SetActive(true);
        quitButton.SetActive(true);
        backButton.SetActive(false);

        yield return null;
    }
}
