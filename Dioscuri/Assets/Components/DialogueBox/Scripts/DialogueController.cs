using Assets.Components.DialogueBox.Scripts;
using UnityEngine;
using UnityEngine.Assertions;

// This goes on same component as PlayerController
public class DialogueController : MonoBehaviour
{
    private bool _uiDisplayOpen = false;
    private IDialogueItem _dialogueItem;

    #region Control Methods
    // Update is called once per frame
    void Update()
    {
        if (!_uiDisplayOpen) return;

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
        _uiDisplayOpen = false;
        DialogueBoxNotifier.CloseDialogueBox();
        // enable playerController
        enabled = false;
    }

    #endregion

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void OpenDialoguBox(IDialogueItem dialogueItem) {
        _dialogueItem = dialogueItem;
        DialogueBoxNotifier.OpenDialoguBox();
        _uiDisplayOpen = true;
    }
}

// Potential Example of a component that has dialogue to display. So if the acting player
// interacts with it (via PlayerController) then PlayerController will get the colliding 
// IContainDialougue component and send it to the DialogueConttroller. This will disable 
// the PlayerController until the sequence is played out. Note that the DialogueConttoller 
// and DialogueBoxUI have no visibility on the logic on which card to play next.
public interface IDialogueItem {
    // DialogueGraph - potential component attached to dialogue holder that would also
    //                 contain all functionality to determine which text to play next.
    DialogueCard GetNextDialogueCard();
    bool HasNextCard();
}
