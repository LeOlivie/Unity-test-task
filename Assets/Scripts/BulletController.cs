using UnityEngine;

//Moves a bullet and destroys it on collision
public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 moveVector = transform.TransformDirection(Vector3.forward) * _speed;
        transform.position += moveVector * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
