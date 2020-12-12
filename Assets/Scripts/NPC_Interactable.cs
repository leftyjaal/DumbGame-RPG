using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interactable : Interactable
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;
    //private string[] dialogueMad;
    private DialogManager _manejadorDialogos;

    // Start is called before the first frame update
    void Start()
    {
        _manejadorDialogos = FindObjectOfType<DialogManager>();
        if(_manejadorDialogos == null)
        {
            Debug.LogWarning("No hay manejador de Dialogos");
        }
    }

    public override void Interact()
    {
        //base.Interact();
        Debug.Log("Interactuando con NPC");
        _manejadorDialogos.GetDialogue(_dialogue, _name);
    }
}
