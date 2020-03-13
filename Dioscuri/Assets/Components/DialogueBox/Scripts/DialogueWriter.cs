
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Components.DialogueBox.Scripts
{
    /// <summary>
    /// Types text for a <see cref="Text" /> Component for display within a Dialogue Box
    /// </summary>
    public  class DialogueWriter
    {
        /// <summary>
        /// Indicates if the DialogueWriter is currently writing. Only one requested dialogue can be typed at a time.
        /// </summary>
        public bool IsTyping { get; private set; } = false;

        private float _textDelayInSeconds = .05f;
        private Text _dialogueTextComponent;

        #region Public Section
        /// <summary>
        /// Instantiate a new DialogueWriter object to write text to the screen.
        /// </summary>
        public DialogueWriter(Text dialogueTextComponent, List<string> dialogueSequence = null) {
            _dialogueTextComponent = dialogueTextComponent;
        }

        /// <summary>
        /// Set desired text speed for the writer. Although not enforced recommended values are from 1-10.
        /// Values less than or equal to 0 result in slowest speed used. 
        /// </summary>
        public void SetTextSpeed(int textSpeed) {
            if (textSpeed <= 0) textSpeed = 1;
            _textDelayInSeconds = 1 / (float)(7 * textSpeed);
        }

        /// <summary>
        /// A Coroutine to append the letters of a given string to the text of a <see cref="Text" /> Component.
        /// WARNING: Always ensure the DialogueWriter is not currently typing with IsTyping.
        /// </summary>
        public IEnumerator TypeNextDialogue(string textToType) {
            StartTyping();
            _dialogueTextComponent.text = "";
            yield return TypeCurrentDialogue(textToType);
            EndTyping();
        }

        #endregion

        #region Private Section
        private IEnumerator TypeCurrentDialogue(string textToType) {
            var charactersToType = textToType.ToArray();
            foreach (var letter in charactersToType)
            {
                _dialogueTextComponent.text += letter;
                yield return new WaitForSeconds(_textDelayInSeconds);
            }
        }

        private void StartTyping() {
            IsTyping = true;
        }

        private void EndTyping() {
            IsTyping = false;
        }

        #endregion 
    }
}
