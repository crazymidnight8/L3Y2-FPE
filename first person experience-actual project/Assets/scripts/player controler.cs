using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroler : MonoBehaviour
{
    public float moveSpeed;
    public float cameraSpeed;
    public float gravity;
    public float gravityLimit;
    public float gracityMultiplier;
    public float jumpForce;
    Vector2 Inputs;

    public Vector3 moveDirection;
    // public float maxDashTime = 1.0f, dashSpeed = 1.0f, dashStoppingSpeed = 0.1f, dashDistance = 10;

    public float dashValue;
    public float currentDashValue;

    public float dashCooldown;
    public float cooldownValue;

    private float currnetDashTime;

    public CharacterController controller;
    public GameObject cam;
    public GameObject playerHead;

    public string spawnPoint;
    public Animator bbox;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // currnetDashTime = maxDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20f)
        {
            StartCoroutine(ResetOnDeath());
        }

        Move();
        Jump();
        Rotation();

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     currnetDashTime = 0.0f;
        // }
        // if (currnetDashTime < maxDashTime)
        // {
        //     moveDirection = new Vector3(Inputs.x, gravity, Inputs.y);
        //     currnetDashTime += dashStoppingSpeed;
        // }
        // else
        // {
        //     moveDirection = Vector3.zero;
        // }
        // controller.Move(moveDirection * Time.deltaTime * dashSpeed);


        // Dash
        if (Input.GetKeyDown(KeyCode.Q) && cooldownValue <= 0)
        {
            currentDashValue = dashValue;

            cooldownValue = dashCooldown;
        }

        if (currentDashValue > 1)
        {
            currentDashValue -= Time.deltaTime * 2f;
        }
        else
        {
            currentDashValue = 1f;
        }

        if (cooldownValue > 0)
        {
            cooldownValue -= Time.deltaTime;
        }
    }

    void Move()
    {
        Inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(Inputs.x, gravity, Inputs.y);
        movement = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * movement;
        controller.Move(movement * moveSpeed * Time.deltaTime * currentDashValue);
    }

    void Rotation()
    {
        playerHead.transform.rotation = Quaternion.Slerp(playerHead.transform.rotation, cam.transform.rotation, cameraSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else
        {
            gravity -= Time.deltaTime * gracityMultiplier;
        }

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpForce);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("spikes"))
        {
            StartCoroutine(ResetOnDeath());
        }
    }

    public IEnumerator ResetOnDeath()
    {
        bbox.SetBool("out", false);
        controller.enabled = false;
        yield return new WaitForSeconds(1f);

        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(.1f);
        bbox.SetBool("out", true);
        controller.enabled = true;
    }
    public IEnumerator ResetPos()
    {
        bbox.SetBool("out", true);
        controller.enabled = false;
        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(.1f);
        controller.enabled = true;
    }

    public IEnumerator LoadNewScene(string levelName)
    {
        bbox.SetBool("out", false);

        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }
}
