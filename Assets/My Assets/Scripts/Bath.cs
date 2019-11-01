using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bath : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    private CharacterController character;
    private HandleTextFile textManager;
    public string filePath;
    private handler Manager;

    // Start is called before the first frame update
    void OnEnable()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        textManager = GameObject.FindGameObjectWithTag("DManager").GetComponent<HandleTextFile>();
        Manager = GameObject.FindGameObjectWithTag("DManager").GetComponent<handler>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        Bathe();
    }

    public void Bathe()
    {
        textManager.Display(filePath);
        Manager.Bath = true;
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
