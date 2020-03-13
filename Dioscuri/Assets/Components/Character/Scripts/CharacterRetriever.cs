
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class CharacterRetriever {

    public static List<Character> Characters = new List<Character> {
        new Character(){ Id = 0, Name = "Markus"},
        new Character(){ Id = 1, Name = "Viktor"},
        new Character(){ Id = 2, Name = "Bartender"}
    };

    public static Character RetrieveCharacterById(int characterId) {
        return Characters.FirstOrDefault(c => c.Id == characterId);
    }
}
