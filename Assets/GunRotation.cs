using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float sensXGun;
    public float sensYGun;

    public Transform orientationFps;

    float xRotationGun;
    float yRotationGun;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensXGun;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensYGun;

        yRotationGun += mouseX;

        xRotationGun -= mouseY;
        xRotationGun = Mathf.Clamp(xRotationGun, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotationGun, yRotationGun, 0);
        orientationFps.rotation = Quaternion.Euler(0, yRotationGun, 0);
        //transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensX);
    }
}
