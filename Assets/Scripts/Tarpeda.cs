using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tarpeda : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform target;
    private Rigidbody rigidbody;
 
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.forward * 10, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        transform.LookAt(target.transform);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 10))
        {
            Enemy enemyTarget = raycastHit.transform.GetComponent<Enemy>();

            if (enemyTarget != null)
            {
                enemyTarget.MinHealth();
            }
        }
    }
}