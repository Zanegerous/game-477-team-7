using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private PlayerControls playerControls;
    private gameHandler gameHandler;

    [Header("Movement")]
    public bool canMove;
    public float startingXPos;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float noseAngle = 0f;
    public float smoothingSensitivity;
    public float verticalSpeed = 0f;
    public float horizontalSpeed = 0f;
    public float turningSpeed = 10f;

    [Header("Attack Input")]
    public float shooting;


    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameHandler>();
    }


    void Update()
    {   
        canMove = !gameHandler.gamePaused;

        handleInput();
        constrainPlayer();

        
        yOffset += verticalSpeed * Mathf.Sin(noseAngle * Mathf.PI / 180f) * Time.deltaTime;
        noseAngle = Mathf.Lerp(noseAngle, 0f, Time.deltaTime * smoothingSensitivity);
        
        
        // Position Player
        transform.position = new Vector3(startingXPos + xOffset, yOffset, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, noseAngle);
       
    }

    void handleInput()
    {   
        // Read movement value
        Vector2 movementInput = playerControls.Player.Move.ReadValue<Vector2>();

        float xMovement = movementInput[0];
        float yMovement = movementInput[1];
        float xScale = xMovement > 0f ? 1f : 8f;

        xOffset += xMovement * horizontalSpeed * Time.deltaTime * xScale;
        // yOffset += yMovement * verticalSpeed * Time.deltaTime;
        noseAngle += yMovement * turningSpeed * Time.deltaTime;

        // Check for firing
        shooting = playerControls.Player.Fire.ReadValue<float>();
        
    }

    void constrainPlayer(){
        xOffset = Mathf.Clamp(xOffset, -2.1f, 6f);
        yOffset = Mathf.Clamp(yOffset, -3.87f, 3.9f);
        noseAngle = Mathf.Clamp(noseAngle, -60f, 60f);
    }
    
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }
}
