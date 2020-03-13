
using Assets.Components.DialogueBox.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    // UI Display
    private Image _backgroundPanel;
    private Image _characterPortrait;
    private Text _characterName;
    private Text _dialogueText;

    // Card Information
    public string SequenceId;
    public List<string> CardIds;
    public TextAsset CustomTextFile;

    // Writing
    public int TextSpeed = 5;
    private DialogueWriter _dialogueWriter;
    private int _currentDialogueIndex = 0;
    private List<DialogueCard> _dialogueCardsToType;

    // Junk for demo purposes - all lines below for character info NEED worked out in future
    public List<Sprite> Portaits;

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
        _dialogueCardsToType = DialogueCardRetriever.GetDialogueCardsBySequenceId(CustomTextFile, SequenceId).ToList();

        // TODO: Unit Test
        var dialogueSelectedCard = DialogueCardRetriever.GetDialogueCardById(CustomTextFile, CardIds.First());

        // TODO: Unit Test
        var dialogueSelectedCards = DialogueCardRetriever.GetDialogueCardsByIds(CustomTextFile, CardIds);
        var dialogueCardTest3 = dialogueSelectedCards.Select(x => x.DialogueText).ToList();

        // Setup talking character
        var currentCharacter = CharacterRetriever.RetrieveCharacterById(_dialogueCardsToType[_currentDialogueIndex].CharacterId);
        _characterPortrait.sprite = Portaits[_dialogueCardsToType[_currentDialogueIndex].CharacterId];
        _characterName.text = currentCharacter.Name;

        // Writing of Dialogue using test data. The Lines here would have actually been fetched by the CardId.
        // Still debating if this should be one static writer or if we would want multiple writer objects
        _dialogueWriter = new DialogueWriter(_dialogueText);
        _dialogueWriter.SetTextSpeed(TextSpeed);                // Turn this list into its own data structure 
        StartCoroutine(_dialogueWriter.TypeNextDialogue(_dialogueCardsToType[_currentDialogueIndex].DialogueText));
    }

    // Update is called once per frame
    void Update() {
        // use as input check for now
        if (Input.GetKeyUp(KeyCode.Return) && !_dialogueWriter.IsTyping) 
        {

            _currentDialogueIndex++;

            // StartCoroutine comes from MonoBehavior so cannot be used in C# class, but
            // the function for the Coroutine can; Like here.

            var currentCharacter = CharacterRetriever.RetrieveCharacterById(_dialogueCardsToType[_currentDialogueIndex].CharacterId);
            _characterPortrait.sprite = Portaits[_dialogueCardsToType[_currentDialogueIndex].CharacterId];
            _characterName.text = currentCharacter.Name;

            StartCoroutine(_dialogueWriter.TypeNextDialogue(_dialogueCardsToType[_currentDialogueIndex].DialogueText));
        }
    }

}
