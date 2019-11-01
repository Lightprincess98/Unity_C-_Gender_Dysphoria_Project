using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    private Camera cam;
    private int characterFemMood = 0;
    public Text interactionText;
    public GameObject PhoneScreen;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can further set it on Unity. (Edit, Project Settings, Input)
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(straffe, 0, translation);
        }

        if (Input.GetKeyDown("escape"))
        {
            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(PhoneScreen.activeInHierarchy  == true)
            {
                PhoneScreen.SetActive(false);
            }
            else
            {
                PhoneScreen.SetActive(true);
            }
        }

        CheckInteration();
    }

    void CheckInteration()
    {
        Vector3 origin = cam.transform.position;
        Vector3 direction = cam.transform.forward;
        float distance = 3f;
        RaycastHit hit;
        interactionText.text = "";

        if(Physics.Raycast(origin, direction, out hit, distance))
        {
            Debug.DrawRay(origin, direction,Color.red);
            if(hit.transform.tag == "Mirror")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Mirror>().enabled = true;
                    interactionText.text = "";
                }
            }

            if(hit.transform.tag == "Door")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<OpenDoor>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "Computer")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<ScreenInteraction>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "Dresser")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Dresser>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "Computer")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<ScreenInteraction>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "Bath")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Bath>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "HardSwitch")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Switch>().enabled = true;
                    interactionText.text = "";
                }
            }


            if (hit.transform.tag == "Exit")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<ChangeScenes>().enabled = true;
                    interactionText.text = "";
                }
            }

            if (hit.transform.tag == "Navigator")
            {
                interactionText.text = "Press E to Interact";
                Debug.Log("Hit");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<CharacterConversation>().enabled = true;
                    interactionText.text = "";
                }
            }
        }
    }

    public int CharacterFemMood
    {
        get { return characterFemMood; }
        set { characterFemMood = value; }
    }
}