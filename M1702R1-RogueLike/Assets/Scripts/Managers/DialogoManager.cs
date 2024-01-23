using UnityEngine;

public class DialogoManager : MonoBehaviour
{
//    public static DialogoManager instance { get; private set; }
//    public static DialogoSpeaker speakerActual;
//    [SerializeField]
//    private DialogoUI dialogoUI;
//    [SerializeField]
//    private GameObject player;

//    public ControladorPreguntas controladorPreguntas;

//    private void Awake()
//    {
//        if (instance==null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//        dialogoUI = FindObjectOfType<DialogoUI>();

//        //controladorPreguntas = FindObjectOfType<ControladorPreguntas>();
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        MostrarUI(false);
//        player.GetComponent<DialogoSpeaker>().Conversar();
//    }
//    public void MostrarUI(bool mostrar)
//    {
//        dialogoUI.gameObject.SetActive(mostrar);
//        //Tambien puedo hacer un condicional para parar el juego si se esta mostrando
//    }
//    public void SetConversacion(Dialogo dialogo, DialogoSpeaker speaker)
//    {
//        if (speaker != null)
//        {
//            speakerActual = speaker;
//        }
//        else
//        {
//            dialogoUI.conversacion = dialogo;
//            dialogoUI.index = 0;
//            dialogoUI.ActualizarTextos(0);
//        }
//        if (dialogo.finalizado && !dialogo.reUsar)
//        {
//            dialogoUI.conversacion = dialogo;
//            dialogoUI.index = dialogo.dialogos.Length;
//            dialogoUI.ActualizarTextos(1);
//        }
//        else
//        {
//            dialogoUI.conversacion = dialogo;
//            dialogoUI.index = speakerActual.dialogoIndex;
//            dialogoUI.ActualizarTextos(0);
//        }
//    }

//    public void CambiarEstadoReUsable(Dialogo dialogo, bool estadoDeseado)
//    {
//        dialogo.reUsar = estadoDeseado;
//    }

//    public void BloqueoYDesbloqueoConversacion(Dialogo dialogo, bool desbloquear)
//    {
//        dialogo.desbloqueada = desbloquear;
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
}
