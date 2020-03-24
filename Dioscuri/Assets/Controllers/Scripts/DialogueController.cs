using Assets.Components.DialogueBox.Scripts;
using UnityEngine;

// This goes on same component as PlayerController
public class DialogueController : ControllerBase
{
    private DialogueContainer _dialogueItem;

    #region Control Methods
    // Update is called once per frame
    void Update()
    {
        if (!UIDisplayOpen) return;

        if (Input.GetKeyDown(KeyCode.Return) && !DialogueWriter.IsTyping)
            NextDialogue();
        if (Input.GetKeyDown(KeyCode.Space))
            CloseDialogueBox();
    }

    private void NextDialogue() {
        if(_dialogueItem.HasNextCard())
        DialogueBoxNotifier.PrintDialogueCard(_dialogueItem.GetNextDialogueCard());
    }

    private void CloseDialogueBox() {
        UIDisplayOpen = false;
        DialogueBoxNotifier.CloseDialogueBox();
        ActivateController<PlayerController>();
        DeactivateThis();
    }
    #endregion

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void OpenDialoguBox(DialogueContainer dialogueItem) {
        DeactivateController<PlayerController>();
        _dialogueItem = dialogueItem;
        DialogueBoxNotifier.OpenDialoguBox();
        UIDisplayOpen = true;
        NextDialogue();
    }
}