using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void GoToSceneTwo() {
        SceneManager.LoadScene("startScene");
    }

    public void GoToSceneThree() {
        SceneManager.LoadScene("SelectionMenu");
    }

}