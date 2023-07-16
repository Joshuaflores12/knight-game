using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string scenetoLoad;
    // Start is called before the first frame update

    public void LoadScene() 
    {
        SceneManager.LoadScene(scenetoLoad);
    }
}