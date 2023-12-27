using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationsManager : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    void Start()
    {
        MouseSensitive.MouseOn += ShowInformations;
        MouseSensitive.MouseOff += ResetInformations;

    }
    private void OnDestroy()
    {
        MouseSensitive.MouseOn -= ShowInformations;
        MouseSensitive.MouseOff -= ResetInformations;
    }
    private void ShowInformations(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
    }
    private void ResetInformations()
    {
        nameText.text = string.Empty;
        descriptionText.text = string.Empty;

    }

}
