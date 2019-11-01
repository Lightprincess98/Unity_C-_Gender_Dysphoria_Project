using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterConversation : MonoBehaviour
{
    public string textFile1;
    public string textFile2;
    public string Intro;
    private HandleTextFile textdialogue;
    private CharacterController character;
    public GameObject UI;

    // Start is called before the first frame update
    void OnEnable()
    {
        textdialogue = GameObject.FindGameObjectWithTag("Navigator").GetComponent<HandleTextFile>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        textdialogue.Display(Intro);
        UI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DreamTelling()
    {
        textdialogue.Display(textFile1);
        StartCoroutine(TimeWait(5));
    }

    public void HealthTelling()
    {
        textdialogue.Display(textFile1);
        StartCoroutine(TimeWait(5));
    }

    IEnumerator TimeWait(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        UI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.enabled = false;
    }
}
