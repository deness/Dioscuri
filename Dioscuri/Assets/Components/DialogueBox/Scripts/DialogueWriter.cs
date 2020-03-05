
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Components.DialogueBox.Scripts
{
    public  class DialogueWriter
    {
        /// <summary>
        /// Indicates if the DialogueWriter is currently writing. Only one requested dialogue can be typed at a time.
        /// </summary>
        public bool IsTyping { get; private set; } = false;

        private float _textDelayInSeconds = .05f;
        private Text _dialogueTextComponent;
        private List<string> _dialogueSequence;
        private int _currentSequenceIndex = 0;

        /// <summary>
        /// Instantiate a new DialogueWriter object to write text to the screen.
        /// </summary>
        public DialogueWriter(Text dialogueTextComponent, List<string> dialogueSequence = null)
        {
            _dialogueTextComponent = dialogueTextComponent;
            _dialogueSequence = dialogueSequence;
        }

        /// <summary>
        /// Loads a set of dialogue texts to display in sequence
        /// </summary>
        public void LoadDialogueSequence(List<string> dialogueSequence)
        {
            _dialogueSequence = dialogueSequence;
        }

        /// <summary>
        /// Set desired text speed for the writer. Although not enforced recommended values are from 1-10.
        /// Values less than or equal to 0 result in slowest speed used. 
        /// Value of -1 will provides instant text.
        /// </summary>
        public void SetTextSpeed(int textSpeed)
        {
            if (textSpeed == -1) 
            { 
                _textDelayInSeconds = 0;
                return;
            }

            if (textSpeed <= 0) textSpeed = 1;
            _textDelayInSeconds = 1 / (float)(7 * textSpeed);

            
        }

        /// <summary>
        /// A Coroutine to append the letters of a given string to the text of a <see cref="Text" /> Component.
        /// WARNING: Always ensure the DialogueWriter is not currently typing with IsTyping.
        /// </summary>
        public IEnumerator TypeNextDialogue() 
        {
            IsTyping = true;

            _dialogueTextComponent.text = "";
            yield return TypeCurrentDialogue();
            _currentSequenceIndex++;

            IsTyping = false;
        }

        private IEnumerator TypeCurrentDialogue() 
        {
            var textToType = _dialogueSequence[_currentSequenceIndex];
            var charactersToType = textToType.ToArray();
            foreach (var letter in charactersToType)
            {
                _dialogueTextComponent.text += letter;
                yield return new WaitForSeconds(_textDelayInSeconds);
            }
        }
    }
}
