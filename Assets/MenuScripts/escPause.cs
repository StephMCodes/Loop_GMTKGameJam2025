using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escPause : MonoBehaviour
{
    [SerializeField] DialogueUI DialogueUI;
    [SerializeField] GameObject EventSystem;
    public GameObject pauseMenu;
    private bool isPaused = false;
    bool inDialogue = DialogueUI.inDialogue;

    void Update()
    {
        inDialogue = DialogueUI.inDialogue;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        //Debug.Log(inDialogue);
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // Toggle pause state
        pauseMenu.SetActive(isPaused); // Show or hide menu
        Time.timeScale = isPaused ? 0 : 1; // Pause or resume game
        //allow clicking
        EventSystem.gameObject.SetActive(true);
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide menu
        Time.timeScale = 1; // Resume game
        if (inDialogue)
        {
            EventSystem.gameObject.SetActive(false); //remove clicking if still in dialogue
        }
    }
}
