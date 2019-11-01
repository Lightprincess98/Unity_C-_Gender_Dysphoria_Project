using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenInteraction : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    private CharacterController character;
    private HandleTextFile textManager;
    public GameObject screenButtons;
    public string filePath;
    public string filePath2;
    private handler Manager;
    public AudioSource audio;

    // Start is called before the first frame update
    void OnEnable()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        textManager = GameObject.FindGameObjectWithTag("DManager").GetComponent<HandleTextFile>();
        Manager = GameObject.FindGameObjectWithTag("DManager").GetComponent<handler>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        screenButtons.SetActive(true);
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    public void DreamCheck()
    {
        textManager.Display(filePath);
        audio.Play();
        screenButtons.SetActive(false);
        Manager.PC = true;
        StartCoroutine(TimeWait(5));
    }

    public void FalseCheck()
    {
        textManager.Display(filePath2);
        audio.Play();
        screenButtons.SetActive(false);
        Manager.PC = true;
        StartCoroutine(TimeWait(5));
    }

    IEnumerator TimeWait(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        uiText.text = "";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.GetComponent<MeshCollider>().enabled = true;
        this.enabled = false;
    }
}
