using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private bool restart;
    private void Update()
    {
        restart = Input.GetKeyDown(KeyCode.R);

        if (restart)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
