using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class buttonFunctionality : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndApplication() {
        Application.Quit();

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #endif
    }
}
