using UnityEngine;

public class Ray : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private float speed;

    private void Start() => Destroy(this.gameObject, destroyTime);

    private void FixedUpdate() => transform.Translate(Vector3.forward * speed * Time.deltaTime);

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
            Destroy(this.gameObject);
    }
}
