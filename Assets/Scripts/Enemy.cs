using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Image healthFillAmoutImage;
    [SerializeField] private Transform healthFillAmoutCanvas;
    [SerializeField, Range(0.1f, 1f)] private float health = 1;
    [SerializeField] private float speed = 1.2f;
    [SerializeField] private float speedInShoot = 0.8f;
    [SerializeField] private float speedHealthFillAmoutImage = 1;
    [SerializeField] float shootDistance = 2f;
    [SerializeField] private Transform raySpawn;
    [SerializeField] private EnemyRay rayPrefab;
    [SerializeField] private float range;

    private Transform target;
    private bool isDestroy = false;
    private bool isReload = true;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        target = GameObject.FindWithTag("Player").transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            MinHealth();
            Destroy(collision.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (isDestroy == false)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > shootDistance)
            {
                Vector3 direction = target.position - transform.position;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
                LookAtY();
                healthFillAmoutCanvas.LookAt(target.transform);
            }
            else
            {
                if (isReload == true)
                {
                    Vector3 direction = target.position - transform.position;
                    transform.Translate(direction * speedInShoot * Time.deltaTime, Space.World);
                    LookAtY();
                    healthFillAmoutCanvas.LookAt(target.transform);
                    isReload = false;
                    Invoke("Reload", 10);
                    RaycastHit raycastHit;
                    EnemyRay newRayPrefab = Instantiate(rayPrefab, raySpawn.transform.position, raySpawn.transform.rotation);

                    if (Physics.Raycast(raySpawn.transform.position, transform.forward, out raycastHit, range))
                    {
                        Player playerTarget = raycastHit.transform.GetComponent<Player>();

                        if (playerTarget != null)
                        {

                            AudioManager.Instance.PlayEffect("Shoot");
                            playerTarget.GetPlayerHealth().MinHealth();
                        }
                    }
                }
            }
        }

        healthFillAmoutImage.fillAmount = Mathf.Lerp(healthFillAmoutImage.fillAmount, health, Time.deltaTime * speedHealthFillAmoutImage);
    }

    private void Reload()
    {
        isReload = true;
    }

    public void MinHealth()
    {
        if (health <= 0)
        {
            isDestroy = true;
            rigidbody.isKinematic = false;
            Destroy(this.gameObject, 30);
        }
        else
            health -= 0.01f;
    }

    private void LookAtY()
    {
        Vector3 targetPostition = new Vector3(target.position.x,
                                       this.transform.position.y,
                                       target.position.z);
        this.transform.LookAt(targetPostition);
    }
}