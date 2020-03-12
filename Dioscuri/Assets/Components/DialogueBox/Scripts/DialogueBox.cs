
using Assets.Components.DialogueBox.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    
    private Image _backgroundPanel;
    private Image _characterPortrait;
    private Text _characterName;
    private Text _dialogueText;

    public string SequenceId;
    public List<string> CardIds;
    public TextAsset CustomTextFile;

    public int TextSpeed = 5;
    private DialogueWriter _dialogueWriter;

    // Start is called before the first frame update
    void Start() {
        // Get reference to child UI components on start up so we don't have to 
        // find them later to update. Bad practice? Acceptable? 
        //  This approach taken so it's easier to edit and see all UI parts in editor 
        _backgroundPanel = transform.GetChild(0).GetComponent<Image>();
        _characterPortrait = transform.GetChild(1).GetComponent<Image>();
        _characterName = transform.GetChild(2).GetComponent<Text>();
        _dialogueText = transform.GetChild(3).GetComponent<Text>();

        // TODO: Unit Test
        var dialogueSequenceCards = DialogueCardRetriever.GetDialogueCardsBySequenceId(CustomTextFile, SequenceId);
        var dialogueCardTest = dialogueSequenceCards.Select(x => x.DialogueText).ToList();

        // TODO: Unit Test
        var dialogueSelectedCard = DialogueCardRetriever.GetDialogueCardById(CustomTextFile, CardIds.First());

        // TODO: Unit Test
        var dialogueSelectedCards = DialogueCardRetriever.GetDialogueCardsByIds(CustomTextFile, CardIds);
        var dialogueCardTest3 = dialogueSelectedCards.Select(x => x.DialogueText).ToList();

        // Writing of Dialogue using test data. The Lines here would have actually been fetched by the CardId.
        // Still debating if this should be one static writer or if we would want multiple writer objects
        _dialogueWriter = new DialogueWriter(_dialogueText, dialogueCardTest);
        _dialogueWriter.SetTextSpeed(TextSpeed);
        StartCoroutine(_dialogueWriter.TypeNextDialogue());
    }

    // Update is called once per frame
    void Update() {
        // use as input check for now
        if (Input.GetKeyUp(KeyCode.Return) && !_dialogueWriter.IsTyping) 
        {
            // StartCoroutine comes from MonoBehavior so cannot be used in C# class, but
            // the function for the Coroutine can; Like here.
            StartCoroutine(_dialogueWriter.TypeNextDialogue());
        }
    }

}
