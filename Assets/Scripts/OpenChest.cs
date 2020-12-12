using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable
{
    private Animator _chestAnim;
    private bool _exist;

    // Start is called before the first frame update
    void Start()
    {
        _chestAnim = GetComponent<Animator>();
        if (_chestAnim == null)
        {
            Debug.LogWarning("No se encontro el conrolador de animacion del cofre");
        }
        _exist = true;
        //revisar si es nulo
    }

    // Update is called once per frame
    public override void Interact()
    {
        Debug.Log("Interactuando con confre del tesoro");
        _chestAnim.SetTrigger("Open");
        StartCoroutine(DeleteObject());
        playerCotroller_.UpdateMoney(20);
        //Debug.Log("Obtuviste 60 NeludiCoins");
        //base.Interact();
    }

    IEnumerator DeleteObject()
    {
        _exist = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
