using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene1()
    {
        SceneManager.LoadScene("01-TerrainExperiment");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("02-Interiors");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("03-Prototype2");
    }
}
