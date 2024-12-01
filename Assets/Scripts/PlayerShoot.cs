using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform raySpawn;
    [SerializeField] private Ray rayPrefab;
    [SerializeField] private float range;
    [SerializeField] private GameObject tarpedaPrefab;
    [SerializeField] private Transform[] spawnsTarpeds;
    [SerializeField] private int countTarpeds = 2;

    private Camera playerCamera;
    private int spawnTarpedVector;

    private void Start()
    {
        playerCamera = FindAnyObjectByType<Camera>();
        spawnTarpedVector = Random.Range(1,2);
    }
    
    public void Shoot()
    {
        RaycastHit raycastHit;
        Ray newRayPrefab = Instantiate(rayPrefab, raySpawn.transform.position, raySpawn.transform.rotation);

        if (Physics.Raycast(raySpawn.transform.position, raySpawn.transform.forward, out raycastHit, range))
        {
            Enemy enemyTarget = raycastHit.transform.GetComponent<Enemy>();

            if (enemyTarget != null)
            {
                AudioManager.Instance.PlaySound("Shoot", false);
                enemyTarget.MinHealth();
            }
        }
    }

    public void ShootTorpeda()
    {
        if (countTarpeds <= 0)
            print("No tarpeds!");
        else
        {
            if(spawnTarpedVector == 1)
            {
                GameObject newTarpedaPrefab = Instantiate(tarpedaPrefab, spawnsTarpeds[0].transform.position, spawnsTarpeds[0].rotation);
                spawnTarpedVector = 2;
            }
            else if (spawnTarpedVector == 2)
            {
                GameObject newTarpedaPrefab = Instantiate(tarpedaPrefab, spawnsTarpeds[0].transform.position, spawnsTarpeds[0].rotation);
                spawnTarpedVector = 1;
            }
        }
    }
}