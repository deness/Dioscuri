
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            ActivateDialogueControl();
    }

    private void ActivateDialogueControl(){
        var dialogueController = GetComponent<DialogueController>();
        dialogueController.enabled = true;
        var dialogueContainer = CollisionOrEventPassesDialogue();
        dialogueController.OpenDialoguBox(dialogueContainer);
        enabled = false;
    }

    private DialogueContainer CollisionOrEventPassesDialogue() {
        return GetComponent<DialogueContainer>();
    }
}
