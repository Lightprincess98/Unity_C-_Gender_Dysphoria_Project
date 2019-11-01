using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public float startTime;
    bool isOpened = false;
    public AudioSource doorAudio;

    void OnEnable()
    {
        isOpened = !isOpened;

        startTime = Time.time;

        doorAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpened)
        {
            transform.Rotate(transform.up, -90 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(transform.up, 90 * Time.deltaTime);
        }


        if (Time.time - startTime > 1f)
        {
            enabled = false;
        }
    }
}
