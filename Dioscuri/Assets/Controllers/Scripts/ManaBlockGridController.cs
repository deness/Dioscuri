using UnityEngine;

public class ManaBlockGridController : ControllerBase
{
    // Update is called once per frame
    void Update()
    {
        if (!UIDisplayOpen) return;

        if (Input.GetKeyDown(KeyCode.Space))
            CloseManaBlockGrid();
    }

    private void CloseManaBlockGrid() {
        UIDisplayOpen = false;
        ManaBlockGridNotifier.CloseManaBlockGrid();
        ActivateController<PlayerController>();
        DeactivateThis();
    }

    /// <summary>
    /// Opens the DialogueBox and plays out the provided DialogueItem
    /// </summary>
    /// <param name="dialogueItem"></param>
    public void OpenManaBlockGrid(ManaBlock manaBlock) {
        DeactivateController<PlayerController>();
        ManaBlockGridNotifier.OpenManaBlockGrid(manaBlock);
        UIDisplayOpen = true;
    }
}
