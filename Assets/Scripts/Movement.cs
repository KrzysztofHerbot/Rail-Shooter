using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //[SerializeField] InputAction move;
    //[SerializeField] InputAction fire;
    [Header("General Setup Settings")]
    [Tooltip("How fast player is moving X and Y on screen")] [SerializeField] float moveSpeed = 0.5f;
    [Tooltip("Left right restriction")] [SerializeField] float xRange = 50f;
    [Tooltip("Top down restriction")] [SerializeField] float yRange = 20f;
    
    [Header("Ship rotation factor")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float positionYawFactor = -2f;
    
    [Header("GameObjects Setup")]
    [Tooltip("Lasers emmiting from the player")] [SerializeField] GameObject[] lasers;

    float xThrow;
    float yThrow;
    void Start()
    {

    }
    /*private void OnEnable()
    {
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }*/

    void FixedUpdate()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        if (Input.GetKeyDown(KeyCode.R))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }


    }

    void ProcessTranslation()
    {
        /*float horizontal = move.ReadValue<Vector2>().x;
                float vertical = move.ReadValue<Vector2>().y;
                Debug.Log("horizontal: " + horizontal);
                Debug.Log("vertical: " + vertical);*/

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * moveSpeed;
        float xNewPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(xNewPos, -xRange, xRange);

        float yOffset = yThrow * moveSpeed;
        float yNewPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(yNewPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXpos,
        clampedYpos,
        transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {

        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isActive;
        }
    }
}
