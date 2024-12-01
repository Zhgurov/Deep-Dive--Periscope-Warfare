using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 2;
    private void FixedUpdate()
    {
        if(Keyboard.current.anyKey.isPressed)
        {
            SceneManager.LoadScene(sceneIndex);
        }      
    }
}
