using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text dialogueText;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		sentences.Enqueue("Darn, the monsters are still chasing us. We've already set up our camp and we don't really have time to start running away.");
		sentences.Enqueue("Is there any other way out?");
		sentences.Enqueue("Looks like I'll have to fend off the monsters instead. I'm the only person capable to fight the monsters. Protect the camp!");
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
    {
		if (sentences.Count == 0)
        {
			EndDialogue();
			return;
        }

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
    }

	void EndDialogue()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
