using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimation _animator;
    private NavMeshAgent _navAgent;
    [SerializeField]
    private int _money;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<PlayerAnimation>();
        if (_animator == null)
        {
            Debug.LogWarning("No se encontro el controlador de animacion del jugador");
        }
        _navAgent = GetComponent<NavMeshAgent>();
        if (_navAgent == null)
        {
            Debug.LogWarning("No se encontro el navmesh del jugador");
        }
        _money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = _navAgent.velocity.magnitude / _navAgent.speed; //normalizar
        _animator.PlayerMove(velocity);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.PlayerAttack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.PlayerSpecialAttack();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _animator.PlayerBlock();
        }

        if(_money >= 100)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpeedUp")
        {
            _navAgent.speed+=2;
            _navAgent.acceleration++;
        }

        if (other.gameObject.tag == "SpeedDown")
        {
            _navAgent.speed--;
            _navAgent.acceleration--;
        }

        if (other.gameObject.tag == "Collectible")
        {
            UpdateMoney(2);
        }

        Destroy(other.gameObject);
    }

    public void UpdateMoney(int money)
    {
        _money += money;
    }
}
