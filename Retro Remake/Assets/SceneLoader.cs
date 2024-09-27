using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("Title Screen");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("duckplswork");
    }
} 



