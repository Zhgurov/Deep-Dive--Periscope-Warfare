using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 2;
    private bool isStart = false;

    private void Start()
    {
        Invoke("TrueIsStart", 2);
    }

    private void TrueIsStart()
    {
        isStart = true;
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            if (Keyboard.current.anyKey.isPressed)
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}