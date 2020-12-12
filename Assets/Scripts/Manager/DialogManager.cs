using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Singleton*** Solo una instancia debe existir  (crear una instancia y destruir nuevas).
public class DialogManager : MonoBehaviour
{
    private static DialogManager _Instance{get; set ;}//Singleton

    //UI
    [SerializeField] // inverso a HideInInspector
    private GameObject _DialoguePnl;
    private Text _DialogueText;
    private Text _NpcNameText;
    private Button _OK_Button;
    private Text _OK_Text;

    private string _name;
    private int _dialogueIndex;
    private List<string> _dialogueList = new List<string>();

    //Es en cuanto se crea el objeto.
    private void Awake()
    {
        if(_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _Instance = this;
        }

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        if ( _DialoguePnl == null)
        {
            Debug.LogWarning("No se agrego el panel de dialogo en Unity, arrastrarlo");
        }

        _DialogueText = _DialoguePnl.transform.GetComponentInChildren<Text>();
        //_DialogueText = _DialoguePnl.transform.GetChild(0).GetComponent<Text>(); // destripa mejor los datos.
        if (_DialogueText == null)
        {
            Debug.LogWarning("El primer hijo del panel de dialogo no tiene componente de Texto");
        }

        _NpcNameText = _DialoguePnl.transform.GetChild(1).GetComponentInChildren<Text>();
        if(_NpcNameText == null)
        {
            Debug.LogWarning("El panel del nombre del NPC no tiene un hijo con componente de texto");
        }

        _OK_Button = _DialoguePnl.transform.GetChild(2).GetComponent<Button>();
        if (_OK_Button == null)
        {
            Debug.LogWarning("No se encontro un boton como tercer hijo del panel de dialogo");
        }
        else
        {
            _OK_Text = _OK_Button.transform.GetComponentInChildren<Text>();
            if (_OK_Text == null)
            {
                Debug.LogWarning("El boton de dialogo no tiene hijo con Text");
            }
        }
        _DialogueText.text = ("Punto punto punto");
        _NpcNameText.text = ("Kotaro");
        _OK_Text.text = ("OK");
        _DialoguePnl.SetActive(false);

        _OK_Button.onClick.AddListener(delegate { ContinuarDialogo(); });
    }
    
    public void GetDialogue(string[] dialogue, string name)
    {
        Debug.Log("Comienza el juego");
        _dialogueIndex = 0;
        _name = name;
        _DialoguePnl.SetActive(true);
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _NpcNameText.text = name;
        CrearDialogos();
    }

    public void CrearDialogos()
    {
        _DialogueText.text = _dialogueList[_dialogueIndex];
    }

    public void ContinuarDialogo()
    {
        if(_dialogueIndex < _dialogueList.Count - 1)
        {
            _dialogueIndex++;
            CrearDialogos();
        }else
        {
            Debug.Log("Finaliza el dialogo");
            _DialoguePnl.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
