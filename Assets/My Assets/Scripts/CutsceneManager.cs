using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public float seconds;
    public Animator navigator;
    public RuntimeAnimatorController Talking;
    public RuntimeAnimatorController Thinking;
    public Animator therapist;
    private CutsceneDialogue manager;
    private HandleTextFile text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutsceneAnimationManager(seconds));
        manager = new CutsceneDialogue();
        manager.StartTemplate();
        text = GameObject.FindGameObjectWithTag("Navigator").GetComponent<HandleTextFile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CutsceneAnimationManager(float seconds)
    {
        navigator.runtimeAnimatorController = Talking;
        therapist.runtimeAnimatorController = Thinking;
        yield return new WaitForSecondsRealtime(seconds);
        navigator.runtimeAnimatorController = Thinking;
        therapist.runtimeAnimatorController = Talking;
        StartCoroutine(LoadScene(30));
        text.Display("Dialogue Files/Cutscene2.txt");
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(3);
    }
}
