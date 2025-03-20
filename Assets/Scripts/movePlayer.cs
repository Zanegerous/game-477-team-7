using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private PlayerControls playerControls;
    private gameHandler gameHandler;

    [Header("Movement")]
    public bool canMove;
    public bool flyingVertically;
    public float startingXPos;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float noseAngle = 0f;
    public float verticalSpeed = 0f;
    public float horizontalSpeed = 0f;
    public float turningSpeed;
    public float smoothingSensitivity;

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

        
        if (!flyingVertically) noseAngle = Mathf.Lerp(noseAngle, 0f, Time.deltaTime * smoothingSensitivity);
        yOffset += verticalSpeed * Mathf.Sin(noseAngle * Mathf.PI / 180f) * Time.deltaTime;
        
        
        // Position Player
        transform.position = new Vector3(startingXPos + xOffset, yOffset, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, noseAngle/2f);
       
    }

    void handleInput()
    {   
        // Read movement value
        Vector2 movementInput = playerControls.Player.Move.ReadValue<Vector2>();

        float xMovement = movementInput[0];
        float yMovement = movementInput[1];

        if (!canMove){
            xMovement = 0f;
            yMovement = 0f;
        }

        flyingVertically = yMovement != 0;

        float xScale = xMovement > 0f ? 1f : 2f; // Move 2 times faster left than right laterally

        xOffset += xMovement * horizontalSpeed * Time.deltaTime * xScale;
        // yOffset += yMovement * verticalSpeed * Time.deltaTime;
        noseAngle += yMovement * turningSpeed * Time.deltaTime;



        // Check for firing
        shooting = playerControls.Player.Fire.ReadValue<float>();
        
    }

    void constrainPlayer(){
        xOffset = Mathf.Clamp(xOffset, -2.1f, 6f);
        yOffset = Mathf.Clamp(yOffset, -3.87f, 3.9f);
        noseAngle = Mathf.Clamp(noseAngle, -80f, 80f);
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
