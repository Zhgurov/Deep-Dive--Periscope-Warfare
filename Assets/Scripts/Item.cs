using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    [SerializeField] private TypeItem typeItem;
    [SerializeField] private Outline outline;


    public TypeItem GetTypeItem() => typeItem;

    public enum TypeItem
    {
        Default,
        Gear,
        Barrel
    }

    private void Start()
    {
        outline.enabled = false;
        Invoke("OutlineItem", 15);
    }

    private void OutlineItem()
    {
        outline.enabled = true;
        Invoke("DeoutlineItem", 2f);
    }

    private void DeoutlineItem()
    {
        outline.enabled = false;
        Invoke("OutlineItem", Random.Range(5, 10));
    }
}
