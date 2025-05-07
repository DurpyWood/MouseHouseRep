using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public bool isGrounded = true;

    public float speed;
    public float runSpeed;
    public float walkSpeed;
    public float gravity = -9.81f;
    public float turnSmoothing = 0.1f;
    public float jumpPower;
    public float stamina;
    public float stambam;
    public int stammax;
    public bool canSprint = true;
    public bool isSprinting;
    float turnSmoothVelocity;
    public Transform cam;
    public Transform groundCheck;
    public float groundDistance = 0.55f;
    public LayerMask groundMask;
    Vector3 velocity;
    public TMPro.TextMeshProUGUI displayText;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stamina = stammax;
    }

    private IEnumerator StaminaDrain()
    {
        while (isSprinting == true)
        {
            yield return new WaitForSeconds(1);
            if (stamina > 0f)
            {
                stamina = stamina - stambam;
            }
            else if (stamina <= 1f)
            {
                speed = walkSpeed;
            }
        }
    }

    private IEnumerator StaminaGain()
    {
        while (isSprinting == false)
        {
            yield return new WaitForSeconds(1);
            if (stamina < stammax)
            {
                stamina = stamina + stambam;
            }
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        displayText.text = stamina.ToString();

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Title");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isSprinting = true;
            StartCoroutine(StaminaDrain());
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            isSprinting = false;
            StartCoroutine(StaminaGain());
        }
    }
}
