using UnityEngine;

public class FactoryPlayerMovement : MonoBehaviour
{
    private float yaw = 0f, pitch = 0f;
    private Rigidbody rb;

    public float walkSpeed = 4f;
    public float sensitivity = 2f;

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        rb = GetComponent<Rigidbody>();
           
    }

    
    void Update()
    {
        Look();   
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Look()
    {
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }

    private void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkSpeed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0f, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.linearVelocity.y);
        rb.linearVelocity = wishDirection;
    }
}
