using Assets.Components.DialogueBox.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DialogueContainer : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private TextAsset DialogueFile;
    [SerializeField]
    private string SequenceId;
#pragma warning restore 0649

    private Queue<DialogueCard> dialogueCardQueue;
    
    public DialogueCard GetNextDialogueCard() {
        return dialogueCardQueue.Dequeue();
    }

    public bool HasNextCard() {
        return dialogueCardQueue.Count > 0;
    }

    public void ResetCardSequence() {
        if(dialogueCardQueue != null) dialogueCardQueue.Clear();
        var cards = DialogueCardRetriever.GetDialogueCardsBySequenceId(DialogueFile, SequenceId);
        foreach (var card in cards) 
            if(card.DialogueText != null) 
                dialogueCardQueue.Enqueue(card);
    }

    void Start() {
        Assert.IsNotNull(DialogueFile);
        Assert.IsNotNull(SequenceId);

        dialogueCardQueue = new Queue<DialogueCard>();
        ResetCardSequence();
        dialogueCardQueue.Dequeue();
    }
}
