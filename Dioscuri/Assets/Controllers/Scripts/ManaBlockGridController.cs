using Assets.Enums;
using UnityEngine;

public class ManaBlockGridController : ControllerBase
{
    // Update is called once per frame
    void Update()
    {
        if (!UIDisplayOpen) return;

        if (Input.GetKeyDown(KeyCode.Space))
            CloseManaBlockGrid();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveManaBlock(Direction.East);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveManaBlock(Direction.West);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveManaBlock(Direction.North);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveManaBlock(Direction.South);
    }

    private void CloseManaBlockGrid() {
        UIDisplayOpen = false;
        ManaBlockGridNotifier.CloseManaBlockGrid();
        ActivateController<PlayerController>();
        DeactivateThis();
    }

    private void MoveManaBlock(Direction direction) {
        ManaBlockGridNotifier.MoveManaBlock(direction);
    }

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void OpenManaBlockGrid(ManaBlock manaBlock) {
        ManaBlockGridNotifier.OpenManaBlockGrid(manaBlock);
        UIDisplayOpen = true;
    }

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void ShowManaBlockSpell(ManaBlock manaBlock)
    {
        ManaBlockGridNotifier.ShowManaBlock(manaBlock);
    }

}
