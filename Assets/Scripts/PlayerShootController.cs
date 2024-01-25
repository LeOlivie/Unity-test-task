using UnityEngine;

//Gets Left mouse button input and shoots a bullet
public class PlayerShootController : MonoBehaviour 
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletSpawnPoint;
    private const string _triggerName = "PistolShoot";
    private PlayerMoveController _moveController;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _moveController = GetComponent<PlayerMoveController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger(_triggerName);
        }
    }

    public void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _bulletSpawnPoint.transform.position, transform.rotation);
    }

}
