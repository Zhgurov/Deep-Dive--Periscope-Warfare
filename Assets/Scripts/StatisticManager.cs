using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class StatisticManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI petrolTextMeshProUGUI;
    [SerializeField] private TextMeshProUGUI artifactsTextMeshProUGUI;

    private int petrol = 100;
    private int artifacts = 0;
    private PlayerHealth health;

    public PlayerHealth GetPlayerHealth() => health;
    public int GetPetrol() => petrol;
    public int GetArtifacts() => artifacts;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        Invoke("MinPetrol", 10);
    }
    private void FixedUpdate()
    {
        if (petrol >= 100)         
            petrol = 100;

        if (artifacts <= 5)
            artifactsTextMeshProUGUI.color = Color.red;
        else
            artifactsTextMeshProUGUI.color = Color.white;

        petrolTextMeshProUGUI.text = petrol.ToString() + "%";
        artifactsTextMeshProUGUI.text = artifacts.ToString();
    }

    public void AddPetrol()
    {
        if (petrol < 100)
            petrol += 10;
        else
            petrol = 100;
    }

    public void AddHealth() => health.MaxHealth(Random.Range(5, 20));

    public void AddArtifacts() => artifacts++;

    private void MinPetrol()
    {
        petrol -= 5;
        Invoke("MinPetrol", 10);
    }
}
