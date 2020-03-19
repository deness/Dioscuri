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
        // would live in PlayerController
        if (!_uiDisplayOpen && Input.GetKeyDown(KeyCode.D)) {
            _dialogueItem = GetComponent<IDialogueItem>();
            OpenDialoguBox(_dialogueItem);
        }

        //if (!_uiDisplayOpen) return;

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

