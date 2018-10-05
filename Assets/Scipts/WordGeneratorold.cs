using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGeneratorold : MonoBehaviour {

		private static string[] wordList = { "mew",
"welcome", "learned", "sort", "grab", "hug", "tramp", "learned", "comment", "sneak", "eye", "harmony", "collect", "watery", "crowd", "heavenly",
"awake", "convers", "gusty", "dead", "hour", "fold", "cactus", "incandescent", "bubble", "continue", "write", "railway", "parcel", "comfortable",
"inform", "giddy", "knotty", "letter", "preserve", "seek", "violent", "boot", "adventurous", "father", "faulty", "suit", "wander", "agonizing",
"inquisitive", "changeable,", "word", "goat", "contrast", "superficial", "kick", "destroy", "blow", "include", "shut", "screw", "bun",
"camp", "recur", "deeply","alight","two","children","abhorrent","ruddy","flight","carriage","profuse",
"return","ruthless","fish","tell","apple","determined","meat","chain","awesome","ticket","moldy","statement",
"hoax","obey","imported","mute","room","swell","authority","hissing","crowd","lucky","venomous",
"press","shivering","education","lackadaisical","dazzling","ill-fated","allow","snap"};

	public static string GetRandomWord () {
		int randomIndex = Random.Range(0,wordList.Length);

		string randomWord = wordList[randomIndex];

		return randomWord;

	}

}
