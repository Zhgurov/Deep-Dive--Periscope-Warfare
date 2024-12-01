using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject images;
    [SerializeField] private TextMeshProUGUI panelTextMeshProUGUI;

    private StatisticManager statisticManager;
    private Timer timer;
    private bool isStart = false;

    private void Start()
    {
        statisticManager = FindAnyObjectByType<StatisticManager>();
        timer = FindAnyObjectByType<Timer>();
        Invoke("TrueIsStart", 2);    
    }
    private void TrueIsStart() => isStart = true;

    private void FixedUpdate()
    {
        if (isStart)
        {
            if (statisticManager.GetArtifacts() > 5 && timer.GetTime() == 0)
            {
                StateGame(true);
            }
            else
            if (statisticManager.GetArtifacts() <= 5 && timer.GetTime() == 0)
            {
                StateGame(true);
            }
            else if (statisticManager.GetPlayerHealth().GetHealth() <= 0)
            {
                StateGame(false);
            }

        }
    }
    public void StateGame(bool isLoseOrWon)
    {
        if (isLoseOrWon)
        {
            panel.SetActive(true);
            images.SetActive(false);
            panelTextMeshProUGUI.text = "VICTORY!\nCOLLECTED ARTIFACTS: " + statisticManager.GetArtifacts().ToString();
        }
        else
        {
            panel.SetActive(true);
            images.SetActive(false);
            panelTextMeshProUGUI.text = "DEFEAT! COLLECTED ARTIFACTS: " + statisticManager.GetArtifacts().ToString();
        }
    }
}