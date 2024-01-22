using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public Dialogo _dialog;
    public GameObject dialogoPanel;
    public Text dialogoText;
    private int index = 0;
    public int select_lang;
    private string[] language;
    public Button nextPhrase;

    void Start()
    {
        switch (select_lang)
        {
            case 0:
                language = _dialog.dialogoEsp;
                break;
            case 1:
                language = _dialog.dialogoIng;
                break;
        }
        dialogoPanel.SetActive(false);
    }
    public void continueDialog()
    {
        index++;
        if(index== language.Length )
        {
            index = language.Length - 1;
        }
        dialogoText.text= language[index];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogoPanel.SetActive(true);
            dialogoText.text = language[0];
            nextPhrase.onClick.AddListener(continueDialog);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogoPanel.SetActive(false);
            index= 0;
            nextPhrase.onClick.RemoveAllListeners();
        }    
    }
}
