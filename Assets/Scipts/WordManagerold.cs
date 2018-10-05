using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManagerold : MonoBehaviour {
	public List<Word> words;

    private bool hasActiveWord;
    private Word activeWord;

		// Use this for initialization
	private void Start () {
		AddWord();
		AddWord();
		AddWord();
    }
	public void AddWord () {

        //Word word = new Word(WordGenerator.GetRandomWord());
		//Debug.Log(word.word);

        //words.Add(word);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(words[0]);
	}

    public void TypeLetter (char letter)
    {
        if(hasActiveWord) {
            if(activeWord.GetNextLetter() == letter) {
                activeWord.TypeLetter();
            }
            //Check if letter was next
            //Remove it from the word
        }
        else {
            foreach(Word word in words) {
                if(word.GetNextLetter() == letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if(hasActiveWord && activeWord.WordTyped()) {
            hasActiveWord=false;
            words.Remove(activeWord);
        }
    }
}
