using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mirror : MonoBehaviour
{
    private int bodyMood = 0;
    private int faceMood = 0;
    private int hairMood = 0;
    public TextMeshProUGUI uiText;
    private CharacterController character;
    public GameObject CheckButtons;

    // Start is called before the first frame update
    void OnEnable()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Interaction();
        this.gameObject.GetComponent<MeshCollider>()    .enabled = false;
    }

    public void Interaction()
    {
        CheckButtons.SetActive(true);
    }

    public void BodyCheck()
    {
        
        if(bodyMood == 0 || bodyMood >= 0)
        {
            uiText.text = "You stare long and deep at your body, analyzing it. You find nothing about your body that disturbs you";
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(2));
        }
        else if(bodyMood <= 0 && bodyMood >= -10)
        {
            uiText.text = "You stare long and deep at your body, analyzing it. You seem to notice your body's shoulders and hips more, it slightly disturbing you more";
            character.CharacterFemMood += 2;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(2));
        }
        else if(bodyMood >= -10)
        {
            uiText.text = "You stare long and deep at your body, analyzing it. You seem to notice your lack of chests as well as your height now bothering you, setting yourself off";
            character.CharacterFemMood += 5;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(2));
        }
    }

    public void FaceCheck()
    {
        if (faceMood == 0 || faceMood >= 0)
        {
            uiText.text = "You stare long and hard at your body, analyzing it. You find nothing about your face that disturbs you";
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
        else if (faceMood <= 0 && faceMood >= -10)
        {
            uiText.text = "You stare long and hard at your face, analyzing it. You seem to notice the slight hairs growing on your face, bothering you and making you shave clean";
            character.CharacterFemMood += 2;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
        else if (faceMood >= -10)
        {
            uiText.text = "You stare long and hard at your body, analyzing it. You begin to notice the masculine curves of your face, setting yourself off";
            character.CharacterFemMood += 5;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
    }

    public void HairCheck()
    {
        if (hairMood == 0 || hairMood >= 0)
        {
            uiText.text = "You stare long and deep at your hair, analyzing it. You find nothing about your hair that disturbs you, you style it a bit";
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
        else if (hairMood <= 0 && hairMood >= -10)
        {
            uiText.text = "You stare long and deep at your body, analyzing it. You take notice of your short hair, it slightly bothers you, and decide not to get it cut.";
            character.CharacterFemMood += 2;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
        else if (hairMood >= -10)
        {
            uiText.text = "You stare long and deep at your body, analyzing it. You begin to style your hair more feminine, changing it up a bit, growing it out.";
            character.CharacterFemMood += 5;
            CheckButtons.SetActive(false);
            StartCoroutine(TimeWait(5));
        }
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



