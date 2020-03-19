
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Components.DialogueBox.Scripts
{
    /// <summary>
    /// Types text for a <see cref="Text" /> Component for display within a Dialogue Box
    /// </summary>
    public static class DialogueWriter
    {
        /// <summary>
        /// Indicates if the DialogueWriter is currently writing. Only one requested dialogue can be typed at a time.
        /// </summary>
        public static bool IsTyping { get; private set; } = false;
        private static float _textDelayInSeconds = .05f;

        #region Public Section
        /// <summary>
        /// Set desired text speed for the writer. Although not enforced recommended values are from 1-10.
        /// Values less than or equal to 0 result in slowest speed used. 
        /// </summary>
        public static void SetTextSpeed(int textSpeed) {
            if (textSpeed <= 0) textSpeed = 1;
            _textDelayInSeconds = 1 / (float)(7 * textSpeed);
        }

        /// <summary>
        /// A Coroutine to append the letters of a given string to the text of a <see cref="Text" /> Component.
        /// WARNING: Always ensure the DialogueWriter is not currently typing with IsTyping.
        /// </summary>
        public static IEnumerator TypeDialogue(string textToType, Text textComponent) {
            StartTyping();
            textComponent.text = "";
            yield return TypeCurrentDialogue(textToType, textComponent);
            EndTyping();
        }

        #endregion

        #region Private Section
        private static IEnumerator TypeCurrentDialogue(string textToType, Text textComponent) {
            var charactersToType = textToType.ToArray();
            foreach (var letter in charactersToType)
            {
                textComponent.text += letter;
                yield return new WaitForSeconds(_textDelayInSeconds);
            }
        }

        private static void StartTyping() {
            IsTyping = true;
        }

        private static void EndTyping() {
            IsTyping = false;
        }

        #endregion 
    }
}
