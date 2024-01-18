using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton2 : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    public void OnStartButtonClicked()
    {
        Debug.Log("Clic en el bot�n de carga en " + SceneManager.GetActiveScene().name);
        Debug.Log("Cargando escena: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}