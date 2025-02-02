using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _rotationSpeed = 150f;

    private Rigidbody _rig;
    private Vector2 _input;

    private ShootingComponent _shootingComponent;


    private void Awake()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.freezeRotation = true;

        _shootingComponent = GetComponent<ShootingComponent>();
    }
    private void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButton("Fire1"))
        {
            _shootingComponent?.Shoot();
        }

    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _input.x * _rotationSpeed * Time.fixedDeltaTime);

        _rig.linearVelocity = transform.forward * _speed * _input.y;
    }
}