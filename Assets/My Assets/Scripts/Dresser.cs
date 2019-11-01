using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dresser : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    private CharacterController character;
    private HandleTextFile textManager;
    public string filePath1;
    public string filepath2;
    private handler Manager;

    // Start is called before the first frame update
    void OnEnable()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        Manager = GameObject.FindGameObjectWithTag("DManager").GetComponent<handler>();
        Cursor.lockState = CursorLockMode.None;
        textManager = GameObject.FindGameObjectWithTag("DManager").GetComponent<HandleTextFile>();
        Cursor.visible = true;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        Dressed();
    }

    public void Dressed()
    {

        if(Manager.PC == true)
        {
            textManager.Display(filePath1);
        }
        else
        {
            textManager.Display(filepath2);
        }
        Manager.Dresser = true;
        StartCoroutine(TimeWait(5));
    }

    IEnumerator TimeWait(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        uiText.text = "";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.enabled = false;
    }
}
