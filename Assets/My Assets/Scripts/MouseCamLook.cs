using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
    [SerializeField]
    private GameObject AI;
    [SerializeField]
    private float speed;
    private Quaternion originalRotation;
    private float sensitivity = 1.5f;
    private float yRotation;
    private float xRotation;

    // Use this for initialization
    void Start()
    {
        AI = this.transform.parent.gameObject;
        originalRotation = this.transform.rotation;
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360f;
        }

        if (angle > 360)
        {
            angle -= 360f;
        }

        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            yRotation += Input.GetAxis("Mouse Y") * sensitivity * speed;
            yRotation = ClampAngle(yRotation, -60, 60);
            Quaternion yQuaternion = Quaternion.AngleAxis(-yRotation, Vector3.right);


            xRotation += Input.GetAxis("Mouse X") * sensitivity * speed;
            xRotation = ClampAngle(xRotation, -360, 360);
            Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);
            transform.localRotation = originalRotation * yQuaternion;
            AI.transform.localRotation = originalRotation * xQuaternion;
        }
    }
}