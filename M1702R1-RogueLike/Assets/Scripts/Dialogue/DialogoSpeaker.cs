using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DialogoSpeaker: MonoBehaviour
{
    //public List<Dialogo> conversacionDisponible = new List<Dialogo>();

    //[SerializeField]
    //private int indexDeConversacion = 0;

    //public int dialogoIndex = 0;

    //void Start()
    //{
    //    indexDeConversacion = 0;
    //    dialogoIndex = 0;

    //    //foreach (var dialogo in conversacionDisponible)
    //    //{
    //    //    dialogo.finalizado = false;
    //    //    var preg = dialogo.pregunta;
    //    //    if (preg != null)
    //    //    {
    //    //        foreach (var opcion in preg.opciones)
    //    //        {
    //    //            opcion.dialogoResultante.finalizado = false;
    //    //        }
    //    //    }
    //    //}
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) 
    //    {
    //        Conversar();
    //    }
    //    if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
    //    {
    //        DialogoManager.instance.CambiarEstadoReUsable(conversacionDisponible[indexDeConversacion], !conversacionDisponible[indexDeConversacion].reUsar);
    //    }
    //}
    //bool ActualizarConversacion()
    //{
    //    if (!conversacionDisponible[indexDeConversacion].reUsar)
    //    {
    //        if (indexDeConversacion < conversacionDisponible.Count - 1)
    //        {
    //            indexDeConversacion++;
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}
    ////public void Conversar()
    ////{
    ////    if(indexDeConversacion <= conversacionDisponible.Count - 1)
    ////    {
    ////        if (conversacionDisponible[indexDeConversacion].desbloqueada)
    ////        {
    ////            if (conversacionDisponible[indexDeConversacion].finalizado)
    ////            {
    ////                if (ActualizarConversacion())
    ////                {
    ////                    DialogoManager.instance.MostrarUI(true);
    ////                    DialogoManager.instance.SetConversacion(conversacionDisponible[indexDeConversacion], this);
    ////                }
    ////                DialogoManager.instance.SetConversacion(conversacionDisponible[indexDeConversacion], this);
    ////                return;
    ////            }
    ////            DialogoManager.instance.MostrarUI(true);
    ////            DialogoManager.instance.SetConversacion(conversacionDisponible[indexDeConversacion], this);
    ////        }
    ////        else
    ////        {
    ////            Debug.Log("La coversacion esta bloqueada");
    ////            DialogoManager.instance.MostrarUI(false);
    ////        }
    ////    }
    ////    else
    ////    {
    ////        Debug.Log("Fin del dialogo");
    ////        DialogoManager.instance.MostrarUI(false);
    ////    }
    ////}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        DialogoManager.instance.MostrarUI(false);
    //    }
    //}
}