using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    [SerializeField]
    private Camera cam;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Get a momvent vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Get a rotation vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Get a camera rotation vector
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //Run every physics iteration
    void FixedUpdate()
    {
        PreformMomvent();
        PreformRotation();

    }

    //Preform Momvent beased on velocity variable
    void PreformMomvent()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Preform Rotation
    void PreformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
