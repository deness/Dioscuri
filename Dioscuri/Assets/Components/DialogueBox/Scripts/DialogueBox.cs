
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    private Image _backgroundPanel;
    private Image _characterPortrait;
    private Text _characterName;
    private Text _dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to child UI components on start up so we don't have to 
        // find them later to update. Bad practice? Acceptable? 
        //  This approach taken so it's easier to edit and see all UI parts in editor 
        
        _backgroundPanel = transform.GetChild(0).GetComponent<Image>();
        _characterPortrait = transform.GetChild(1).GetComponent<Image>();
        _characterName = transform.GetChild(2).GetComponent<Text>();
        _dialogueText = transform.GetChild(3).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Initial thought is that only a few features belong here
        //  - scrolling of text; each frame shows a little more?
        //  - auto page flip (next dialogue based on time not input)
        //      May just be Timer with action/event to keep from checking delta time every frame
        //  - 
    }

    private void FlipDialoguePage()
    { 
        // calls backing c# class to retrieve next set of dialogue to display
    }

    private void ChangeSpeakingCharacter() 
    {
        // Just some fake code to show potential way to update dialogue box at runtime. This should be attached to an action/event.
        // DO NOT put in Update function!!!!! If the referenced values change here I suspect the Update function already handles re-rendering
        var testSprite = _backgroundPanel.sprite;
        _backgroundPanel.sprite = Sprite.Create(testSprite.texture, testSprite.rect, testSprite.pivot, testSprite.pixelsPerUnit);
    }
}
