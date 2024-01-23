using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("Start")]
    [SerializeField] public GameObject startMenu;
    [Header("Tutorial1")]
    [SerializeField] public GameObject tutorial1;
    [Header("Tutorial2")]
    [SerializeField] public GameObject tutorial2;
    [Header("Hud")]
    [SerializeField] public GameObject Hud;

    [Header("Game Over")]
    public GameObject gameOverUI;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void DisableStart()
    {
        Debug.Log("HOLA");
        startMenu.SetActive(false);
        tutorial1.SetActive(true);
    }
    public void StartGame()
    {
        tutorial1.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame2()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        Time.timeScale = 1f;
    }
    public void volver()
    {
        tutorial2.SetActive(false);
        tutorial1.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Game()
    {
        startMenu.SetActive(false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        Hud.SetActive(true);
        Time.timeScale = 1f;

    }
    public void activeGameOver()
    {
        startMenu.SetActive(false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        Hud.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
    public void Reload()
    {
        SceneManager.LoadScene("BasementMain");
    }
}