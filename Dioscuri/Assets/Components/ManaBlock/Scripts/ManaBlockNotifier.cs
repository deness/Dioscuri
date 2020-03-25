

using Assets.Enums;
using System;

public static class ManaBlockGridNotifier
{ 
    public static Action<ManaBlock> OnOpenManaBlockGrid { get; set; }
    public static Action OnCloseManaBlockGrid { get; set; }
    public static Action<ManaBlock, bool> OnShowManaBlock { get; set; }
    public static Action<Direction> OnMoveManaBlock { get; set; }
    public static Action OnPlaceManaBlock { get; set; }

    /// <summary>
    /// Opens the provided Mana Block on the UI as the grid
    /// </summary>
    public static void OpenManaBlockGrid(ManaBlock manaBlockGrid) {
        OnOpenManaBlockGrid?.Invoke(manaBlockGrid);
    }

    /// <summary>
    /// Closes currently displayed ManaBlock grid from UI
    /// </summary>
    public static void CloseManaBlockGrid(){
        OnCloseManaBlockGrid?.Invoke();
    }

    /// <summary>
    /// Moves the current ManaBlock piece in provided direction within the bounds of the ManaBlock grid
    /// </summary>
    public static void MoveManaBlock(Direction directionToMove) {
        OnMoveManaBlock?.Invoke(directionToMove);
    }

    /// <summary>
    /// Displays the provided ManaBlock within the bounds of the current ManaBlock grid on the UI
    /// </summary>
    public static void ShowManaBlock(ManaBlock manaBlocktoDisplay, bool isSpell = true) {
        OnShowManaBlock?.Invoke(manaBlocktoDisplay, isSpell);
    }

    /// <summary>
    /// Place ManaBlock within bounds of the current grid
    /// </summary>
    public static void PlaceManaBlock() {
        OnPlaceManaBlock?.Invoke();
    }
}