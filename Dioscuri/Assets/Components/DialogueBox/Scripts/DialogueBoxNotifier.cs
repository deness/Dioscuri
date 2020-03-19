
using Assets.Components.DialogueBox.Scripts;
using System;
using System.Collections.Generic;

public static class DialogueBoxNotifier
{
    public static Action<DialogueCard> OnConfirmNextDialogue { get; set; }
    public static Action OnConfirmDialogueChoice { get; set; }
    public static Action OnSwitchDialogueChoice { get; set; }
    public static Action OnCloseDialogueBox { get; set; }
    public static Action OnOpenDialoguBox { get; set; }

    /// <summary>
    /// Print the provided DialogueCard to the screen.
    /// </summary>
    /// <param name="dialogueCard"></param>
    public static void PrintDialogueCard(DialogueCard dialogueCard) {
        OnConfirmNextDialogue?.Invoke(dialogueCard);
    }

    /// <summary>
    /// Print provided DialogueCards to the screen
    /// </summary>
    /// <param name="dialogueCards"></param>
    public static void PrintDialogueSequence(DialogueCard[] dialogueCards) {
        foreach(var card in dialogueCards)
            OnConfirmNextDialogue?.Invoke(card);
    }

    /// <summary>
    /// Print provided DialogueCards to the screen
    /// </summary>
    /// <param name="dialogueCards"></param>
    public static void PrintDialogueGraph(Queue<DialogueCard> dialogueCards) {
        foreach (var card in dialogueCards)
            OnConfirmNextDialogue?.Invoke(card);
    }

    /// <summary>
    /// Closes the DialogueBox UI display
    /// </summary>
    public static void CloseDialogueBox() {
        OnCloseDialogueBox?.Invoke();
    }

    /// <summary>
    /// Opens the DialogueBox UI display
    /// </summary>
    public static void OpenDialoguBox() {
        OnOpenDialoguBox?.Invoke();
    }
}
