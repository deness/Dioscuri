using UnityEngine;

public class ManaBlockGridUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HandlesCloseManaBlockGrid();

        ManaBlockGridNotifier.OnOpenManaBlockGrid += HandlesOpenManaBlockGrid;
        ManaBlockGridNotifier.OnCloseManaBlockGrid += HandlesCloseManaBlockGrid;
        ManaBlockGridNotifier.OnShowManaBlock += HandlesShowManaBlock;
        ManaBlockGridNotifier.OnMoveManaBlock += HandlesMoveManaBlock;
        ManaBlockGridNotifier.OnPlaceManaBlock += HandlesPlaceManaBlock;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void HandlesOpenManaBlockGrid(ManaBlock manaBlockGrid) {
        gameObject.SetActive(true);
    }

    private void HandlesCloseManaBlockGrid() {
        gameObject.SetActive(false);
    }

    private void HandlesShowManaBlock(ManaBlock manaBlockToDisplay) { 
    }

    private void HandlesMoveManaBlock(Direction directionToMove) {
    }

    private void HandlesPlaceManaBlock() {  
    }
}
