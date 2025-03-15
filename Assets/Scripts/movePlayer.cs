using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private PlayerControls playerControls;

    [Header("Movement")]
    public float startingXPos;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float verticalSpeed = 0f;
    public float horizontalSpeed = 0f;

    [Header("Attack Input")]
    public float shooting;

    void Update()
    {
        handleInput();
        constrainPlayer();
        
        
        // Position Player
        transform.position = new Vector3(startingXPos + xOffset, yOffset, 0f);

       
    }

    void handleInput()
    {
        // Read movement value
        Vector2 movementInput = playerControls.Player.Move.ReadValue<Vector2>();

        float xMovement = movementInput[0];
        float yMovement = movementInput[1];
        xOffset += xMovement * horizontalSpeed * Time.deltaTime;
        yOffset += yMovement * horizontalSpeed * Time.deltaTime;

        // Check for firing
        shooting = playerControls.Player.Fire.ReadValue<float>();
        
    }

    void constrainPlayer(){
        xOffset = Mathf.Clamp(xOffset, -1.88f, 3.5f);
        yOffset = Mathf.Clamp(yOffset, -4f, 4f);
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
