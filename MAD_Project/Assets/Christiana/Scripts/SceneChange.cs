using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene 1");
    }

    public void MenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }

}