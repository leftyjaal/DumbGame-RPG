using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayCastWorldInfo : MonoBehaviour
{
    private NavMeshAgent _playerNavAgent;

    // Start is called before the first frame update
    //Rayo que aparece un rayo para tomar informacion de las colisiones y el movimiento del personaje
    void Start()
    {
        //podemos acceder a cualquier componente.
        _playerNavAgent = GetComponent<NavMeshAgent>();
        if(_playerNavAgent == null)
        {
            throw new MissingComponentException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetRaycastInfo();
        }
    }

    void GetRaycastInfo()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            //tag son etiquetas para los objetos y nos sirve para saber como interactua con los objetos.
            if (interactedObject.tag == "Iteractable")
            {
                //Debug.Log("Objeto interactuable");
                _playerNavAgent.stoppingDistance = 5f;
                _playerNavAgent.destination = interactedObject.transform.position;

                interactedObject.GetComponent<Interactable>().GetInteractionValues(_playerNavAgent, interactedObject);

                
            }
            else
            {
                //Debug.Log("Moviendose al objeto!");
                _playerNavAgent.stoppingDistance = 0f;
                _playerNavAgent.destination = interactionInfo.point;
            }
        }
    }
}
