using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	private Queue<string> sentences;
	private bool textRunning;
	private string tempSentence;

	public Animator animator;
	
	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	public void StartDialogue (Dialogue dialogue) {
		animator.SetBool("IsOpen",true);
		
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}

		textRunning = false;
		DisplayNextSentence();
	}
	
	public void DisplayNextSentence() {
		if (!textRunning) {
			if (sentences.Count == 0) {
				EndDialogue();
				return;
			}
			string sentence = sentences.Dequeue();
			tempSentence = sentence;
			// StopAllCoroutines();
			textRunning = true;
			StartCoroutine(TypeSentence(sentence));
		}
		else {
			StopAllCoroutines();
			EndSentence(tempSentence);
			textRunning = false;
		}
		
	}

	public void EndSentence(string sentence) {
		dialogueText.text = sentence;
	}

	IEnumerator TypeSentence (string sentence) {
		textRunning = true;
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
		textRunning = false;
	}

	private void EndDialogue() {
		Debug.Log("End of conversation.");
	}
}
