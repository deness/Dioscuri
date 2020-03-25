using Assets.Enums;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBlockGridUI : MonoBehaviour
{
    // TODO: Consider if it's really worth having ManaGrid and ManaBlock share the same UI component
    private List<Image> _currentManaGrid;
    private List<Image> _currentManaSpell;

    // Start is called before the first frame update
    void Start()
    {
        HandlesCloseManaBlockGrid();

        ManaBlockGridNotifier.OnOpenManaBlockGrid += HandlesOpenManaBlockGrid;
        ManaBlockGridNotifier.OnCloseManaBlockGrid += HandlesCloseManaBlockGrid;
        ManaBlockGridNotifier.OnShowManaBlock += HandlesShowManaBlock;
        ManaBlockGridNotifier.OnMoveManaBlock += HandlesMoveManaBlock;
        ManaBlockGridNotifier.OnPlaceManaBlock += HandlesPlaceManaBlock;

        _currentManaGrid = new List<Image>();
        _currentManaSpell = new List<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void HandlesOpenManaBlockGrid(ManaBlock manaBlockGrid) {
        gameObject.SetActive(true);
        _currentManaGrid = new List<Image>();
        _currentManaSpell = new List<Image>();
        HandlesShowManaBlock(manaBlockGrid, false);
    }

    private void HandlesCloseManaBlockGrid() {
        // note the actual gameObject needs destroyed not just the image component, otherwise
        // we will still see the objects on the hierarchy 
        //      - TODO: check to see if using list references work here
        foreach (var img in gameObject.GetComponentsInChildren<Image>())
            Destroy(img.gameObject);
        gameObject.SetActive(false);
    }

    // TODO: This needs refactored... need I say more....
    // Optional boolean needs to go
    private void HandlesShowManaBlock(ManaBlock manaBlockToDisplay, bool isSpellBlock = true) {
        foreach (var cell in manaBlockToDisplay.ManaCells) {
            var manaSlotImage = Instantiate(cell.ManaCellSprite);
            var imageDimensions = manaSlotImage.rectTransform.rect;

            // Set Location
            manaSlotImage.transform.SetParent(transform, false);
            manaSlotImage.transform.localPosition = new Vector3(
                cell.Column * imageDimensions.width * .5f, 
                cell.Row * imageDimensions.height * .5f, 
                0);

            manaSlotImage.name = $"Grid: {!isSpellBlock} -- Cell: ({cell.Row},{cell.Column})";
            manaSlotImage.transform.localScale = new Vector3(.5f, .5f, .5f);
            
            // Assign spell and grid to proper list so we can keep track of references
            // TODO: This needs re-thought 
            if (!isSpellBlock) _currentManaGrid.Add(manaSlotImage);
            else _currentManaSpell.Add(manaSlotImage);
        }
    }

    private void HandlesMoveManaBlock(Direction directionToMove) {
        foreach (var img in _currentManaSpell) {
            var imageDimensions = img.rectTransform.rect;
            img.transform.localPosition += CalculateNewPosition(directionToMove, imageDimensions);
        }
    }

    private void HandlesPlaceManaBlock() {  
    }

    private Vector3 CalculateNewPosition(Direction direction, Rect imgDimensions) {
        switch (direction)
        {
            case Direction.North:
                return new Vector3(0, imgDimensions.height * .5f, 0);
            case Direction.South:
                return new Vector3(0, -imgDimensions.height * .5f, 0);
            case Direction.West:
                return new Vector3(-imgDimensions.width * .5f, 0, 0);
            case Direction.East:
                return new Vector3(imgDimensions.width * .5f, 0, 0);
        }

        return new Vector3();
    }
}
