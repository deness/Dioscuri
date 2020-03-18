
using Assets.Components.DialogueBox.Scripts;
using System;
using UnityEngine;

public static class DialogueBox
{
    public static Action<string, string, Sprite> OnPrintDialogue { get; set; }
    
    /// <summary>
    /// Print the provided DialogueCard to the screen.
    /// </summary>
    /// <param name="dialogueCard"></param>
    public static void PrintDialogueCard(DialogueCard dialogueCard) {
        OnPrintDialogue?.Invoke(dialogueCard.DialogueText, dialogueCard.CharacterId.ToString(), null);
    }

    /// <summary>
    /// Print provided DialogueCards to the screen
    /// </summary>
    /// <param name="dialogueCards"></param>
    public static void PrintDialogueSequence(DialogueCard[] dialogueCards) {
        foreach(var card in dialogueCards)
            OnPrintDialogue?.Invoke(card.DialogueText, card.CharacterId.ToString(), null);
    }
}
