using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float speedMovement = 5f;
    [SerializeField] float playerMass = 1f;
    [Header("Camera")]
    [SerializeField][Range(0f, 89f)] float upAngle = 15f;
    [SerializeField][Range(0f, 89f)] float downAngle = 15f;
    [SerializeField] Transform cameraTransform;

    Vector2 sight;
    Vector3 velocity;
    CharacterController characterController;
    GameObject torch;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        torch = GameObject.Find("TorchPlayer");
        torch.SetActive(false);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateSight();
        UpdateMovement();
        UpdateGravity();
    }

    void UpdateSight()
    {
        sight.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        sight.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        sight.y = Mathf.Clamp(sight.y, -upAngle, downAngle);

        cameraTransform.localRotation = Quaternion.Euler(-sight.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, sight.x, 0);
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        //transform.Translate(speedMovement * Time.deltaTime * input, Space.World);
        characterController.Move((input * speedMovement + velocity) * Time.deltaTime);
    }

    void UpdateGravity()
    {
        var gravity = playerMass * Time.deltaTime * Physics.gravity;
        velocity.y = characterController.isGrounded ? -1f : velocity.y + gravity.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StartPoint")
        {
            torch.SetActive(true);
        }
    }
}
