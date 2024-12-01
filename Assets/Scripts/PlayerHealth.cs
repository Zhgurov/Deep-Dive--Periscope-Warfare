using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshProUGUI healthTextMeshProUGUI;

    public int GetHealth() => health;   

    private void FixedUpdate()
    {
        healthTextMeshProUGUI.text = health.ToString() + "%";
    }

    public void MinHealth()
    {
        health -= Random.Range(1, 5);
    }

    public void MaxHealth(int addHealth) 
    {
        health += addHealth;
    }
}
