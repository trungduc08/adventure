using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

using System.Linq;

public class Recognize : MonoBehaviour {

	[Header("Key words")]
	[Tooltip("Controller actions of player")]
	public KeywordRecognizer keywordRecognizer;
	public Dictionary<string, Action> actions = new Dictionary<string, Action>();

	// Use this for initialization
	void Start () {
		actions.Add("down", () =>{
			goCall();
		});
		keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}
	
	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        // word = args.text;
		// Debug.Log("word: "+ args.text);
		// actions[args.text].Invoke();
		Action keywordAction;
		if(actions.TryGetValue(args.text, out keywordAction)){
			keywordAction.Invoke();
		}
    }

	void goCall(){
		Debug.Log("go call");
	}
}
