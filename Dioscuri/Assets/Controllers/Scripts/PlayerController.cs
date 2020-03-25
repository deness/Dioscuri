
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ControllerBase
{
    public Image TestUnusedImage;
    public Image TestUsedImage;

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
        var manaBlockSpell = PartyPairPassInSpellManaBlock();
        manaBlockGridConroller.OpenManaBlockGrid(manaBlock);
        manaBlockGridConroller.ShowManaBlockSpell(manaBlockSpell);
        DeactivateThis();
    }

    private DialogueContainer CollisionOrEventPassesDialogue() {
        return GetComponent<DialogueContainer>();
    }

    private ManaBlock PartyPairPassInManaBlock() {
        var cells = new List<ManaCell>
            {
                new ManaCell(0, 0, TestUnusedImage)
                , new ManaCell(0, 1, TestUnusedImage)
                , new ManaCell(0, 2, TestUnusedImage)
                , new ManaCell(0, 3, TestUnusedImage)
                , new ManaCell(1, 0, TestUnusedImage)
                , new ManaCell(1, 1, TestUnusedImage)
                , new ManaCell(1, 2, TestUnusedImage)
                , new ManaCell(1, 3, TestUnusedImage)
                , new ManaCell(2, 0, TestUnusedImage)
                , new ManaCell(2, 1, TestUnusedImage)
                , new ManaCell(2, 2, TestUnusedImage)
                , new ManaCell(2, 3, TestUnusedImage)
                , new ManaCell(3, 0, TestUnusedImage)
                , new ManaCell(3, 1, TestUnusedImage)
                , new ManaCell(3, 2, TestUnusedImage)
                , new ManaCell(3, 3, TestUnusedImage)
            };
        return new ManaBlock() { ManaCells = cells };
        
    }

    private ManaBlock PartyPairPassInSpellManaBlock()
    {
        var cells = new List<ManaCell>
            {
                new ManaCell(0, 0, TestUsedImage)
                , new ManaCell(0, 1, TestUsedImage)
                , new ManaCell(1, 0, TestUsedImage)
            };
        return new ManaBlock() { ManaCells = cells };

    }
}
