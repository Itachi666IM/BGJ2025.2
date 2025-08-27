using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    Vector2 turn;
    public bool isCursorLocked = false;
    [SerializeField] GameObject torch;
    [SerializeField] Image torchImage;
    [SerializeField] Sprite torchOff;
    [SerializeField] Sprite torchOn;
    private bool isActive = false;
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
        if(isActive)
        {
            torch.SetActive(false);
            torchImage.sprite = torchOff;
            isActive = false;
        }
        else
        {
            torch.SetActive(true);
            torchImage.sprite = torchOn;
            isActive = true;
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