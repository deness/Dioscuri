using Assets.Components.DialogueBox.Scripts;
using UnityEngine;

// This goes on same component as PlayerController
public class DialogueController : MonoBehaviour
{
    private bool _uiDisplayOpen = false;
    private DialogueContainer _dialogueItem;

    private void Start()
    {
        enabled = false;
    }

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
        GetComponent<PlayerController>().enabled = true;
        enabled = false;
    }
    #endregion

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void OpenDialoguBox(DialogueContainer dialogueItem) {
        //GetComponent<PlayerController>().enabled = false;
        _dialogueItem = dialogueItem;
        DialogueBoxNotifier.OpenDialoguBox();
        _uiDisplayOpen = true;
    }
}