using UnityEngine;

[RequireComponent (typeof(StatisticManager))]
public class ItemManager : MonoBehaviour
{
    private StatisticManager statisticManager;

    private void Start()
    {
        statisticManager = GetComponent<StatisticManager>();    
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Item>().GetTypeItem() == Item.TypeItem.Gear)
        {
            statisticManager.AddHealth();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Item>().GetTypeItem() == Item.TypeItem.Barrel)
        {
            statisticManager.AddPetrol();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Item>().GetTypeItem() == Item.TypeItem.Default)
        {
            statisticManager.AddArtifacts();
            Destroy(collision.gameObject);
        }
    }
}
