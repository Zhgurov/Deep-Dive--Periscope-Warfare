using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private float speed;

    private void Start() => Destroy(this.gameObject, destroyTime);

    private void FixedUpdate() => transform.Translate(Vector3.forward * speed * Time.deltaTime);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().MinHealth();
            Destroy(this.gameObject);
        }
    }
}
