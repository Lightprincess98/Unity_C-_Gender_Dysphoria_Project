using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class HandleTextFile : MonoBehaviour
{
    public string FilePath;
    private

    void Start()
    {
        StartCoroutine(TextDisplay(FilePath, 5f));
    }

    public IEnumerator TextDisplay(string filepath,float waitTime)
    {
        TextMeshProUGUI dialogueText;
        dialogueText = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        ReadString(filepath);
        yield return new WaitForSeconds(waitTime);
        dialogueText.text = "";
    }

    public void Display(string filepath)
    {
        StartCoroutine(TextDisplay(filepath, 10));
    }

    public static void ReadString(string Filepath)
    {
        string path = Filepath;
        TextMeshProUGUI dialogueText;
        dialogueText = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TextMeshProUGUI>();

    //Read the text from directly from the test.txt file
    StreamReader reader = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));
        dialogueText.text = reader.ReadToEnd();
        reader.Close();
    }
}