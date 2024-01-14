using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject tutorial1Canvas;
    public GameObject tutorial2Canvas;

    // Llamado por el botón en el canvas 1
    public void OnNextButtonClicked()
    {
        tutorial1Canvas.SetActive(false);
        tutorial2Canvas.SetActive(true);
    }
}