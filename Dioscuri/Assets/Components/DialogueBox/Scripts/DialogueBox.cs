
using Assets.Components.DialogueBox.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    
    private Image _backgroundPanel;
    private Image _characterPortrait;
    private Text _characterName;
    private Text _dialogueText;

    public int TextSpeed = 5;
    public List<string> _dialogueLines = new List<string> {
         "This is a test that the letters show up one at a time. Currently it does not support auto paging." +
            " Need to try some more text because right now the speed seems off. Next is paging it like auto scroll; no input.",
        "This is the second text in the sequence. This should not need another page.",
        "The thrid line tends to be long winded. So who know how long this could go for. Maybe it is because" +
            " it's the big reveal of the game. Note that during this there is not response to any input other than that of" +
            " the dialogue box. So the character can't move on the map."
    };

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

        // Writing of Dialogue using test data. The Lines here would have actually been fetched by the CardId.
        // Still debating if this should be one static writer or if we would want multiple writer objects
        _dialogueWriter = new DialogueWriter(_dialogueText, _dialogueLines);
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
