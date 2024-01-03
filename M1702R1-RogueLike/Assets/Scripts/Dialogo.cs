using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityExtensions;

[CreateAssetMenu(fileName ="Dialogo", menuName ="Sistema de Dialogo/Nueva Conversacion")]
public class Dialogo : ScriptableObject
{
    [System.Serializable]
    public struct Linea
    {
        public Personaje_Dialogo personaje;

        //Se puede meter audio tambien
        [TextArea(3, 5)]
        public string dialogo;
    }
    public bool desbloqueada;
    public bool finalizado;
    public bool reUsar;
    //[ReordenableList]
    public Linea[] dialogos;
}
