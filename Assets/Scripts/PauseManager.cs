using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    private bool isPaused = false;

    private void Start()
    {
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }
        Time.timeScale = 1f; // ensure game starts unpaused
    }

    private void Update()
    {
        // Press Esc to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        if (pauseUI != null)
        {
            pauseUI.SetActive(isPaused);
        }
    }

    private void OnDisable()
    {
        // Safety: if object is disabled/destroyed, unpause game
        Time.timeScale = 1f;
    }
}
