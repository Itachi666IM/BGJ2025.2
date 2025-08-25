using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    Vector2 turn;
    public bool isCursorLocked = false;
    [SerializeField] GameObject torch;
    private void Start()
    {
        if(isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTorch();
        }
    }

    public void SwitchTorch()
    {
        if(torch.GetComponent<Light>().enabled == true)
        {
            torch.GetComponent<Light>().enabled = false;
        }
        else
        {
            torch.GetComponent<Light>().enabled = true;
        }
    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}