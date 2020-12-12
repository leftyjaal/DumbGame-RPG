using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = transform.GetChild(0).GetComponent<Animator>();
        if (_playerAnim == null)
        {
            Debug.LogWarning("No se encontro el animador del hijo del jugador");
        }
    }

    public void PlayerMove(float speed)
    {
        _playerAnim.SetFloat("SpeedValue", speed);
    }

    public void PlayerAttack()
    {
        _playerAnim.SetTrigger("isAttacking");
    }

    public void PlayerBlock()
    {
        _playerAnim.SetTrigger("isBlocking");
    }

    public void PlayerSpecialAttack()
    {
        _playerAnim.SetTrigger("isSpecialAttack");
    }
}
