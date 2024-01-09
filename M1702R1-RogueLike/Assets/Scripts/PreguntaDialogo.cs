using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Opciones
{
    [TextArea(2, 4)]
    public string opcion;
    public Dialogo Resultante;
}

[CreateAssetMenu(fileName ="PreguntaDialogo", menuName ="Sistema de Dialogo/Nueva Pregunta")]
public class PreguntaDialogo : ScriptableObject
{
    [TextArea(3, 5)]
    public string pregunta;
    public Opciones[] opciones;
}
