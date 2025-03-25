using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class gameHandler : MonoBehaviour
{

    public bool gamePaused;
    public SpaceShip shipScript;
    public int shipScraps;
    public bool levelCompleted = false;

    [Header("UI Stuff")]
    public TextMeshProUGUI statsText;
    public GameObject helpText;
    public GameObject shopPanel;
    public TextMeshProUGUI attackSpeedCost;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI ShipSpeedCost;
    public TextMeshProUGUI ShipSpeedText;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gamePaused = false;

        updateAttackSpeedCost();
        updateShipSpeedCost();
    }

    // Update is called once per frame
    void Update()
    {
        syncWithSpaceShipScript();
        checkInput();

        displayStatsCorrectly();
    }

    void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleCursor();
        }
    }

    /////////////////////////////////////////////////////////////  

    public void QuitGame()
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
            
            updateAllCostTexts();
        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        shopPanel.SetActive(Cursor.visible);
        helpText.SetActive(!shopPanel.activeInHierarchy);
        gamePaused = shopPanel.activeInHierarchy;
        Time.timeScale = shopPanel.activeInHierarchy ? 0f : 1f;
    }


    ////////////////////////////////////////////////////////////

    void syncWithSpaceShipScript()
    {
        shipScraps = shipScript.scraps;
    }

    void displayStatsCorrectly()
    {
        statsText.text = "Scraps: " + shipScraps.ToString();
    }

    //  VVVVV WILL NEED TO BE DUPLICATED FOR MORE UPGRADES VVVVV

    void updateAllCostTexts(){
        updateAttackSpeedCost();
        updateShipSpeedCost();
    }

    public void updateAttackSpeedCost()
    {
        attackSpeedCost.text = "$" + shipScript.currentAttackSpeedUpgradeCost;
        attackSpeedText.text = shipScript.attackSpeed.ToString("F2") + " -> " + (shipScript.attackSpeed / 1.1f).ToString("F2");
    }

    public void updateShipSpeedCost()
    {
        ShipSpeedCost.text = "$" + shipScript.currentShipSpeedUpgradeCost;
        ShipSpeedText.text = shipScript.speedMult.ToString("F2") + " -> " + (shipScript.speedMult + 0.1f).ToString("F2");
    }

}
