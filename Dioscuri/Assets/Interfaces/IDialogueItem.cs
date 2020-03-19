using Assets.Components.DialogueBox.Scripts;

// Potential Example of a component that has dialogue to display. So if the acting player
// interacts with it (via PlayerController) then PlayerController will get the colliding 
// IContainDialougue component and send it to the DialogueConttroller. This will disable 
// the PlayerController until the sequence is played out. Note that the DialogueConttoller 
// and DialogueBoxUI have no visibility on the logic on which card to play next.
public interface IDialogueItem
{
    // DialogueGraph - potential component attached to dialogue holder that would also
    //                 contain all functionality to determine which text to play next.
    DialogueCard GetNextDialogueCard();
    bool HasNextCard();
}