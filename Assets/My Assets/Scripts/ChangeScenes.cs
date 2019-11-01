using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScenes : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    private CharacterController AI;
    public GameObject screenButtons;

    // Start is called before the first frame update
    void OnEnable()
    {
        AI = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        screenButtons.SetActive(true);
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        uiText.text = "Where will I be going?";
    }

    public void UnversitySceneLoad()
    {
        screenButtons.SetActive(false);
        uiText.text = "";
        //StartCoroutine(TimeWait(5));
        SceneManager.LoadScene(2);
    }

    public void ParkSceneLoad()
    {
        screenButtons.SetActive(false);
        uiText.text = "";
        //StartCoroutine(TimeWait(5));
        SceneManager.LoadScene(5);
    }

    public void RoomSceneLoad()
    {
        screenButtons.SetActive(false);
        uiText.text = "";
        //StartCoroutine(TimeWait(5));
        SceneManager.LoadScene(1);
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
