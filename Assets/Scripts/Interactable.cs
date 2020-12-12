using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Interactable : MonoBehaviour
{
    protected NavMeshAgent playerNavAgent_;
    protected GameObject interactedObject_;
    protected PlayerController playerCotroller_;
    private bool _hasInteracted;

    // Start is called before the first frame update
    void Start()
    {
        _hasInteracted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNavAgent_ != null && !playerNavAgent_.pathPending)
        {
            if(playerNavAgent_.remainingDistance <= playerNavAgent_.stoppingDistance)
            {
                if (!_hasInteracted)
                {
                    _hasInteracted = true;
                    Interact();
                    playerNavAgent_ = null; //optional
                }
            }
        }
    }

    public void GetInteractionValues(NavMeshAgent playerNavAgent, GameObject interactedObject)
    {

        playerNavAgent_ = playerNavAgent;
        playerCotroller_ = playerNavAgent.GetComponent<PlayerController>();

        if (playerCotroller_ == null)
        {
            Debug.LogWarning("No se encontro el controlador del jugador a traves del NavAgent");
        }

        interactedObject_ = interactedObject;
        _hasInteracted = false;
    }

    //
    //virtual == override de clases hijo
    public virtual void Interact()
    {
        Debug.Log("Interactuando con algun objeto desconocido...");
    }

}
