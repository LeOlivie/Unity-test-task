using UnityEngine;

//Gets WASD input, moves and rotates the player
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _animBlendSpeed;
    private const string _walkVarName = "WalkSpeed";
    private CharacterController _characterController;
    private Animator _animator;
    private Vector3 _moveDirection;
    private float _animBlend;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        Move();
        DoAnimation();
    }

    private void GetInput() // Get W-A-S-D and mouse inputs
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        float mouseInput = Input.GetAxis("Mouse X");

        _moveDirection = new Vector3(horInput,0,verInput);
        transform.Rotate(0,mouseInput,0);
    }
    
    private void Move()
    {
        _moveDirection = transform.TransformDirection(_moveDirection) * _speed; //Transform to local coordinates
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void DoAnimation()
    {
        _animBlend = Mathf.Lerp(_animBlend, _moveDirection.normalized.magnitude, Time.deltaTime*_animBlendSpeed); //Interpolate animation change speed
        _animator.SetFloat(_walkVarName, _animBlend); //Change animation from idle to walk
    }
    public void StopMoving()
    {
        enabled = false;
    }
    public void ResumeMoving()
    {
        enabled = true;
    }
}
