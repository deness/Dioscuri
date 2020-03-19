using Assets.Components.DialogueBox.Scripts;
using UnityEngine;

public class DialogueHolder : MonoBehaviour, IDialogueItem
{
    public Sprite CardSprite;
    public Sprite CardSprite2;

    private DialogueCard[] dialogueCards;
    private int currentIndex = 0;

    #region IDialogueItem Implementation
    public DialogueCard GetNextDialogueCard() {
        currentIndex++;
        return dialogueCards[currentIndex];
    }

    public bool HasNextCard() {
        return currentIndex < dialogueCards.Length;
    }
    #endregion

    void Start() { 
        dialogueCards = new DialogueCard[]{
            new DialogueCard { CharacterPortrait = CardSprite, CharacterName = "Viktor", DialogueText = "This is some text 1"},
            new DialogueCard { CharacterPortrait = CardSprite2, CharacterName = "Markus", DialogueText = "This is some text 2"},
            new DialogueCard { CharacterPortrait = CardSprite, CharacterName = "Viktor", DialogueText = "This is some text 3"},
            new DialogueCard { CharacterPortrait = CardSprite2, CharacterName = "Markus", DialogueText = "THis is some text 4"}
    };
    }
}
