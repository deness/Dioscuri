
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Components.DialogueBox.Scripts
{
    public static class DialogueCardRetriever
    {
        private static int CardTextLimit = 70;
        #region Public Section

        /// <summary>
        /// Gets a sequence of Dialogue Cards from a provided text file
        /// </summary>
        public static IEnumerable<DialogueCard> GetDialogueCardsBySequenceId(TextAsset textFile, string sequenceId) {
            var sequenceLines = ParseTextFile(textFile).GoToSequence(sequenceId).TakeUntilSequenceEnd();
            return ParseDialogueCards(sequenceLines);
        }

        /// <summary>
        /// Gets a specific Dialogue Card from provided text file
        /// </summary>
        public static DialogueCard GetDialogueCardById(TextAsset textFile, string cardId) {
            var cardLines = ParseTextFile(textFile).GoToCard(cardId).TakeUntilCardEnd().ToList();
            return ParseDialogueCards(cardLines).SingleOrDefault();
        }

        /// <summary>
        /// Gets a specific Dialogue Cards from provided text file
        /// </summary>
        public static IEnumerable<DialogueCard> GetDialogueCardsByIds(TextAsset textFile, IEnumerable<string> cardIds) {
            var fileLines = ParseTextFile(textFile);
            var cardLines = cardIds.SelectMany(x => fileLines.GoToCard(x).TakeUntilCardEnd());

            return ParseDialogueCards(cardLines);
        }
        #endregion

        #region Private Section
        private static IEnumerable<string> ParseTextFile(TextAsset textAsset) {
            if (textAsset == null) 
                throw new ArgumentNullException($"{nameof(DialogueCardRetriever)} cannot parse a null {nameof(TextAsset)}.");
            if (string.IsNullOrEmpty(textAsset.text)) 
                throw new ArgumentNullException($"{textAsset.name} is an empty text file and cannot be parsed");

            return textAsset.text.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static IEnumerable<string> GoToSequence(this IEnumerable<string> fileLines, string sequenceId) {
            return fileLines.SkipWhile(x => !x.Replace(" ", "").StartsWith("::"+sequenceId)).Skip(1);
        }

        private static IEnumerable<string> GoToCard(this IEnumerable<string> fileLines, string cardId) {
            return fileLines.SkipWhile(x => !x.Replace(" ", "").StartsWith("--" + cardId));
        }
        
        private static IEnumerable<string> TakeUntilSequenceEnd(this IEnumerable<string> fileLines) {
            return fileLines.TakeWhile(x => !x.StartsWith("::"));
        }
        
        private static IEnumerable<string> TakeUntilCardEnd(this IEnumerable<string> fileLines) {
            return fileLines.TakeWhileIncludeFirst(x => !x.StartsWith("--") && !x.StartsWith("::"));
        }

        private static IEnumerable<string> TakeWhileIncludeFirst(this IEnumerable<string> fileLines, Func<string, bool> predicate) {
            var firstLine = fileLines.First();
            var takeLines = fileLines.Skip(1).TakeWhile(predicate).ToList();
            takeLines.Insert(0, firstLine);
            return takeLines;
        }

        private static IEnumerable<DialogueCard> SplitDialogueCard(this DialogueCard dialogueCardToSplit) {
            var dialogueText = dialogueCardToSplit.DialogueText;
            var splitCards = new List<DialogueCard>();
            
            // TODO: Can this be converted to a yield return?
            for (var i = 0; i < dialogueText.Length; i += CardTextLimit) {
                var clonedCard = new DialogueCard {
                    CharacterPortrait = dialogueCardToSplit.CharacterPortrait,
                    CharacterName = dialogueCardToSplit.CharacterName,
                    DialogueText = dialogueText.Substring(i, Math.Min(CardTextLimit, dialogueText.Length - i))
                };
                splitCards.Add(clonedCard);
            }
            return splitCards;
        }

        // TODO: This needs split apart otherwise adding more sytax symbols for writers will become increasingly difficult.
        public static IEnumerable<DialogueCard> ParseDialogueCards(IEnumerable<string> fileLines) {
            var dialogueCard = new DialogueCard();
            var dialogueCards = new List<DialogueCard>();

            foreach (var line in fileLines) {
                if (line.StartsWith("//")) continue;
                else if (line.StartsWith("--"))
                {
                    if (!string.IsNullOrEmpty(dialogueCard.DialogueText) && dialogueCard.DialogueText.Length > 20)
                    {
                        var splitCards = dialogueCard.SplitDialogueCard();
                        dialogueCards.AddRange(splitCards);
                    }
                    else
                        dialogueCards.Add(dialogueCard);

                    dialogueCard = new DialogueCard();
                    var metaData = line.Split(',');
                    // TODO: Fetch approriate objects by Ids parsed from text
                    //dialogueCard.DialogueCardId = metaData[0].Remove(0,2);
                    //dialogueCard.CharacterId = int.Parse(metaData[1]);
                    //dialogueCard.EmotionId = int.Parse(metaData[2]);
                }
                else dialogueCard.DialogueText = line;
            }
            return dialogueCards;
        }
        #endregion
    }
}
