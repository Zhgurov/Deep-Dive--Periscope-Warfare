using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTextMeshProUGUI;
    [SerializeField] private float time;

    private float _timeLeft = 0f;

    public float GetTime() => _timeLeft;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerTextMeshProUGUI.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}