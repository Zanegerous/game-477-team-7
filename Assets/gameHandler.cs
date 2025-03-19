using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class gameHandler : MonoBehaviour
{

    public bool gamePaused;
    public spaceshipScript shipScript;
    public int shipScraps;

    [Header("UI Stuff")]
    public TextMeshProUGUI statsText;
    public GameObject helpText;
    public GameObject shopPanel;
    public TextMeshProUGUI attackSpeedCost;
    public TextMeshProUGUI attackSpeedText;


    void Start()
    {
        Application.targetFrameRate = 300;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        updateAttackSpeedCost();
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
        helpText.SetActive(!shopPanel.activeInHierarchy);
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

    public void updateAttackSpeedCost(){
        shipScript.currentAttackSpeedUpgradeCost += 100;
        attackSpeedCost.text = "$" + shipScript.currentAttackSpeedUpgradeCost;
        attackSpeedText.text = shipScript.attackSpeed.ToString("F2") + " -> " + (shipScript.attackSpeed/1.1f).ToString("F2");
        
    }

}
