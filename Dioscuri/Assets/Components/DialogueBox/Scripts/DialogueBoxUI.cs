using Assets.Components.DialogueBox.Scripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DialogueBoxUI : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _characterPortrait;
    [SerializeField]
    private Text _characterNameLabel;
    [SerializeField]
    private Text _dialogueText;
#pragma warning restore 0649

    // Currently exposing here to allow testing of different speeds.
    public int TextSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        HandlesCloseDialogueBox();

        // Ensure that component has UI fields set within Editor
        Assert.IsNotNull(_characterPortrait);
        Assert.IsNotNull(_characterNameLabel);
        Assert.IsNotNull(_dialogueText);

        DialogueBoxNotifier.OnConfirmNextDialogue += HandlesPrintDialogue;
        DialogueBoxNotifier.OnOpenDialoguBox += HandlesOpenDialogueBox;
        DialogueBoxNotifier.OnCloseDialogueBox += HandlesCloseDialogueBox;
        DialogueWriter.SetTextSpeed(TextSpeed);
    }
    
    private void HandlesPrintDialogue(DialogueCard dialogueCard) {
        _characterPortrait.sprite = dialogueCard.CharacterPortrait;
        _characterNameLabel.text = dialogueCard.CharacterName;
        StartCoroutine(DialogueWriter.TypeDialogue(dialogueCard.DialogueText, _dialogueText));
    }
    private void HandlesCloseDialogueBox() {
        gameObject.SetActive(false);
    }

    private void HandlesOpenDialogueBox() {
        gameObject.SetActive(true);
    }
}
