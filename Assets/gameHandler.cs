using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class gameHandler : MonoBehaviour
{

    public bool gamePaused;
    public GameObject shopPanel;
    public spaceshipScript shipScript;
    public int shipScraps;
    public TextMeshProUGUI statsText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        syncWithSpaceShipScript();
        checkInput();

        displayStatsCorrectly();
    }

    void checkInput(){

        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();

        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleCursor();
    }

    /////////////////////////////////////////////////////////////  

    void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #endif
    }

    void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        shopPanel.SetActive(Cursor.visible);
        gamePaused = shopPanel.activeInHierarchy;
        // Time.timeScale = shopPanel.activeInHierarchy ? 0f : 1f;
    }


    ////////////////////////////////////////////////////////////

    void syncWithSpaceShipScript(){
        shipScraps = shipScript.scraps;
    }

    void displayStatsCorrectly(){
        statsText.text = "Scraps: " + shipScraps.ToString();
    }


}
