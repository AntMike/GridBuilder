using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public bool canMove = false;
    
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public Transform cam;

    void Start()
    {
        //cam = Camera.main;
    }

    void Update()
    {
        if(!canMove) return;
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation -= mouseY;
        xRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.eulerAngles = new Vector3(0, xRotation, 0.0f);
        cam.eulerAngles = new Vector3(yRotation,cam.eulerAngles.y, cam.eulerAngles.z);
    }
}