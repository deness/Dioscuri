using Assets.Components.DialogueBox.Scripts;
using Assets.Extensions.Exceptions;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxUI : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Image _characterPortrait;
    [SerializeField]
    private Text _characterNameLabel;
    [SerializeField]
    private Text _dialogueText;
#pragma warning restore 0649

    // Currently exposing here to allow testing of different speeds.
    public int TextSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that component has UI fields set within Editor
        Validate.RequiredComponentField(_characterPortrait, nameof(_characterPortrait), nameof(DialogueBoxUI));
        Validate.RequiredComponentField(_characterNameLabel, nameof(_characterNameLabel), nameof(DialogueBoxUI));
        Validate.RequiredComponentField(_dialogueText, nameof(_dialogueText), nameof(DialogueBoxUI));

        DialogueBox.OnPrintDialogue += HandlesPrintDialogue;
        DialogueWriter.SetTextSpeed(TextSpeed);
    }
    
    private void HandlesPrintDialogue(string dialogueText, string characterName, Sprite characterPortrait) {
        if(characterPortrait != null) _characterPortrait.sprite = characterPortrait;
        _characterNameLabel.text = characterName;
        StartCoroutine(DialogueWriter.TypeDialogue(dialogueText, _dialogueText));
    }
}
