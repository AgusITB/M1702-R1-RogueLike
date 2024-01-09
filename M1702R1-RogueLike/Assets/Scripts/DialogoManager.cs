using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager instance { get; private set; }
    //public static DialogueSpeaker speakerActual;
    [SerializeField]
    private DialogoUI dialogoUI;
    [SerializeField]
    private GameObject player;

    //public ControladorPreguntas controladorPreguntas;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        dialogoUI = FindObjectOfType<DialogoUI>();

        //controladorPreguntas = FindObjectOfType<ControladorPreguntas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MostrarUI(false);
        //player.GetComponent<DialogueSpeaker>().Conversar();
    }
    public void MostrarUI(bool mostrar)
    {
        dialogoUI.gameObject.SetActive(mostrar);
        //Tambien puedo hacer un condicional para parar el juego si se esta mostrando
    }
    //public void SetConversacion(Dialogo dialogo, /*DialogueSpeaker speaker*/)
    //{
    //    if (AudioSpeakerMode != null)
    //    {
    //        speakerActual = speaker;
    //    }
    //    else
    //    {

    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
