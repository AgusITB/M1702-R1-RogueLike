using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public Dialogo conversacion;
    [SerializeField]
    private GameObject diaContainer;
    [SerializeField]
    private GameObject pregContainer;

    [SerializeField]
    private Image speakImage;
    [SerializeField]
    private TextMeshProUGUI nombre;
    [SerializeField]
    private TextMeshProUGUI convText;

    [SerializeField]
    private Button continuarButton;

    [SerializeField]
    private Button anteriorButton;

    public int index = 0;




    // Start is called before the first frame update
    void Start()
    {
        diaContainer.SetActive(true);
        pregContainer.SetActive(false);

        continuarButton.gameObject.SetActive(true);
        anteriorButton.gameObject.SetActive(false);
    }

    public void ActualizarTextos(int comportamiento)
    {
        diaContainer.SetActive(true);
        pregContainer.SetActive(false);

        switch (comportamiento)
        {
            case -1:
                if (index > 0)
                {
                    Debug.Log("dialogo anterior");
                    index--;
                    nombre.text = conversacion.dialogos[index].personaje.nombre;
                    convText.text = conversacion.dialogos[index].dialogo;
                    speakImage.sprite = conversacion.dialogos[index].personaje.imagen;
                    anteriorButton.gameObject.SetActive(index > 0);
                }
                break;
                //DialogoManager.speakerActual.diaLocalIn=index;
            default:
            break;
            case 0:
                Debug.Log("Dialogo actualizado");

                nombre.text = conversacion.dialogos[index].personaje.nombre;
                convText.text = conversacion.dialogos[index].dialogo;
                speakImage.sprite = conversacion.dialogos[index].personaje.imagen;
                anteriorButton.gameObject.SetActive(index > 0);
                if (index>=conversacion.dialogos.Length-1)
                {
                    continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                }
                else
                {
                    continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                }
                break;
            case 1:
                if (index < conversacion.dialogos.Length - 1)
                {
                    Debug.Log("Dialogo Siguiente");
                    index++;
                    nombre.text = conversacion.dialogos[index].personaje.nombre;
                    convText.text = conversacion.dialogos[index].dialogo;
                    speakImage.sprite = conversacion.dialogos[index].personaje.imagen;
                    anteriorButton.gameObject.SetActive(index > 0);
                    if (index >= conversacion.dialogos.Length - 1)
                    {
                        continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                    }
                    else
                    {
                        continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                    }
                }
                else
                {
                    Debug.Log("Dialogo terminado");
                    index = 0;
                    //DialogoManager.speakerActual.diaLocalIn=0;
                    conversacion.finalizado = true;
                    ///////
                    //if (conversacion.pregunta!=null)
                    //{
                    //    diaContainer.SetActive(false);
                    //    pregContainer.SetActive(true);
                    //    var preg = conversacion.pregunta;
                    //    DialogoManager.instance.controladorPreguntas.ActivarBotones(preg.opciones.lenght,preg.pregunta,preg.opciones);
                    //    return;
                    //}
                    //DialogoManager.intance.MostrarUI(false);
                    //return;
                
                
                }
                //DialogoManager.speakActual.diaLocalIn = index;
                //break;
            //default:
                Debug.LogWarning("Estas pasando un valor no admitido");
            break;

        }
    }
    //IEnumerator EscribirTexto()
    //{
    //    convText.maxVisibleCharacters= 0;
    //    convText.text = conversacion.dialogos[index].dialogo;
    //    convText.richText = true;
    //}
}
