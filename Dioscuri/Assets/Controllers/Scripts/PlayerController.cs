
using UnityEngine;

public class PlayerController : ControllerBase
{
    protected override void Start() 
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.D))
            ActivateDialogueControl();
        if (Input.GetKeyDown(KeyCode.B))
            ActivateManaBlockGridControl();
    }

    private void ActivateDialogueControl(){        
        var dialogueController = ActivateController<DialogueController>();
        var dialogueContainer = CollisionOrEventPassesDialogue();
        dialogueContainer.ResetCardSequence();
        dialogueController.OpenDialoguBox(dialogueContainer);
        DeactivateThis();
    }

    private void ActivateManaBlockGridControl() {
        var manaBlockGridConroller = ActivateController<ManaBlockGridController>();
        var manaBlock = PartyPairPassInManaBlock();
        manaBlockGridConroller.OpenManaBlockGrid(manaBlock);
        DeactivateThis();
    }

    private DialogueContainer CollisionOrEventPassesDialogue() {
        return GetComponent<DialogueContainer>();
    }

    private ManaBlock PartyPairPassInManaBlock() {
        return new ManaBlock();
    }
}
