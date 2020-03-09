using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assets.Components.DialogueBox.Scripts
{
    public static class DialogueCardRetriever
    {
        private const string textPath = @"D:\Projects\Git_Dioscuri\Dioscuri\Assets\Components\DialogueBox\Files\ch1_grp1.txt";

        #region Public Section
        /// <summary>
        /// Gets specific Dialogue Card using its unique CardId
        /// </summary>
        public static DialogueCard GetDialogueCardById(string cardId) {
            return GetDialogueCards().FirstOrDefault(card => card.DialogueCardId == cardId);
        }

        /// <summary>
        /// Gets all Dialogue Cards for a given character; Probably would change param to Character object later and get Id from that
        /// so nothing else in the system needs to know about a character Id
        /// </summary>
        public static IEnumerable<DialogueCard> GetDialogueCardsByCharacterId(int characterId) {
            return GetDialogueCards().Where(card => card.CharacterId == characterId);
        }

        #endregion

        #region Private Section
        private static IEnumerable<DialogueCard> GetDialogueCards() {
            // Currently reads all data every call, that would need to change. Discuss potential file 
            // strategy and organization with others. Could load all required dialogue cards at once when
            // scene loads and store in memory until scene switch?
            var commaSeparatedLines = File.ReadAllLines(textPath).ToList();

            return commaSeparatedLines.Select(line => {
                var lineValues = line.Split(':');
                return new DialogueCard
                {
                    DialogueCardId = lineValues[0],
                    CharacterId = int.Parse(lineValues[1]),
                    DialogueText = lineValues[2]
                };
            }).ToList();
        }
        #endregion
    }
}
