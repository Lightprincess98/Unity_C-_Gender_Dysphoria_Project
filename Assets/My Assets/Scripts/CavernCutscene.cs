using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CavernCutscene : MonoBehaviour
{
    public int seconds;
    public bool scene2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchScenes(seconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwitchScenes(float seconds)
    {
        yield return new WaitForSeconds(10);
        if(scene2)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
