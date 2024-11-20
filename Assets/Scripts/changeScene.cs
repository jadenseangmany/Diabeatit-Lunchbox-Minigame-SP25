using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class changeScene : MonoBehaviour
{
    public Text totalPointsTxt;
    public void GoToSceneTwo() {
        SceneManager.LoadScene("startScene");
    }

    public void GoToSceneThree() {
        SceneManager.LoadScene("SelectionMenu");
    }

    public void GoToSceneFour() {
        SceneManager.LoadScene("finishScene");
        SceneManager.sceneLoaded += OnSceneLoaded; //check scene is loaded
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    if (scene.name == "finishScene") {
        totalPointsTxt = GameObject.Find("finalPoints").GetComponent<Text>();
        displayTotalPoints();
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe after handling
    }
}

    public void displayTotalPoints() {
        if (totalPointsTxt != null) {
            totalPointsTxt.text = ($"{sceneData.TotalPoints}");
            Debug.Log("FINAL POINTS SUCCESS!");
        } else {
            Debug.Log("finalPoints is not assigned in the Inspector");
        }
    }

}