using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Finish
{
    public void StartTemplate()
    {
        Debug.Log("StartingTemplate");

        if (ShouldPlayCutscene())
        {
            PlayCutscene();
        }

        if (ShouldLoadDialogue())
        {
            LoadDialogue();
        }

        if (ShouldDisableNonNeededObjects())
        {
            DisableObjects();
        }

        if (ShouldSpawnNewResources())
        {
            SpawnResources();
        }
    }

    protected abstract void PlayCutscene();
    protected abstract void LoadDialogue();
    protected abstract void DisableObjects();
    protected abstract void SpawnResources();

    protected virtual bool ShouldPlayCutscene() { return true; } // << called Hook
    protected virtual bool ShouldLoadDialogue() { return true; }
    protected virtual bool ShouldDisableNonNeededObjects() { return true; }
    protected virtual bool ShouldSpawnNewResources() { return true; }

    protected void StartScene()
    {
        Debug.Log("Scenes have Started");
    }

    protected void EndScene()
    {
        Debug.Log("Scenes are ending");
    }
}

public class CutsceneDialogue : Finish
{
    private HandleTextFile text = GameObject.FindGameObjectWithTag("Navigator").GetComponent<HandleTextFile>();
    private GameObject disable = GameObject.FindGameObjectWithTag("CutsceneRemoval");
    protected override void PlayCutscene()
    {
        Debug.Log("Playing Cutscene");
    }

    protected override void LoadDialogue()
    {
        Debug.Log("Loading Dialogue");
        text.Display("Dialogue Files/Cutscene1.txt");
    }

    protected override void DisableObjects()
    {
        Debug.Log("DisablingObjects");
        disable.SetActive(false);
    }

    protected override void SpawnResources()
    {
        Debug.Log("Spawning Resources for next scenario");
    }
}