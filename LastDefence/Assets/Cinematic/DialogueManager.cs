using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Character/images in the hierarchy has to be named according to their Name in dialogue
// To create dialogue, copy template and put lines in allDialogues
public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public Text continueButton;
	public GameObject allDialogues;
	private GameObject currCharacter;

	private allDialogue allDialoguesScript;
	public Queue<Dialogue> characterlines;
	private Queue<string> sentences;
	
	private bool cutsceneDone = false;
	private bool textRunning;
	private string tempSentence;

	public Animator dialogueBoxAnimator;
	public Animator char1Animator;
	public Animator char2Animator;
	private Animator currCharAnimator;

    public string nextScene;
	
	// Use this for initialization
	void Start () {
		// Grab all dialogues and queue them into characterlines
		allDialoguesScript = allDialogues.GetComponent<allDialogue>();
		sentences = new Queue<string>();
		characterlines = new Queue<Dialogue>();
		foreach (Dialogue dialogue in allDialoguesScript.dialogues) {
			characterlines.Enqueue(dialogue);
		}
		StartDialogue(characterlines.Dequeue());
	}

	// private IEnumerator DelayStart() {
	// 	yield return new WaitForSeconds(1);	// Waits one second
	// 	StartDialogue(characterlines.Dequeue());
	// }

	public void StartDialogue (Dialogue dialogue) {
		dialogueBoxAnimator.SetBool("IsOpen",true);
		char1Animator.SetBool("CharacterFadeIn",true);
		char2Animator.SetBool("CharacterFadeIn",true);
		StartNextDialogue(dialogue);
	}

	public void StartNextDialogue (Dialogue dialogue) {
		nameText.text = dialogue.name;
		currCharacter = GameObject.Find(dialogue.name);
		currCharAnimator = currCharacter.GetComponent<Animator>();

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
				if (characterlines.Count == 0) {
					changeScene();
				}
				else {
					StartNextDialogue(characterlines.Dequeue());
				}
				return;
				
			}
			string sentence = sentences.Dequeue();
			tempSentence = sentence;
			textRunning = true;
			currCharAnimator.SetBool("CharacterTalking",true);
			if (sentences.Count == 0 && characterlines.Count == 0) {
				StartCoroutine(TypeSentence(sentence, true));
			}
			else {
				StartCoroutine(TypeSentence(sentence, false));
			}
		}
		else {
			StopAllCoroutines();
			EndSentence(tempSentence);
			currCharAnimator.SetBool("CharacterTalking",false);
			textRunning = false;
		}
		
	}

	public void EndSentence(string sentence) {
		dialogueText.text = sentence;
		if (sentences.Count == 0 && characterlines.Count == 0) {
			currCharAnimator.SetBool("CharacterTalking",false);
			continueButton.text = "EXIT >>";
			cutsceneDone = true;
		}
	}

	IEnumerator TypeSentence (string sentence, bool last) {
		textRunning = true;
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
		currCharAnimator.SetBool("CharacterTalking",false);
		textRunning = false;
		if(last){
			EndDialogue();
		}
	}

	private void EndDialogue() {
		currCharAnimator.SetBool("CharacterTalking",false);
		continueButton.text = "EXIT >>";
		cutsceneDone = true;
	}

	public void changeScene() {
		if (cutsceneDone) {
			SceneManager.LoadScene(nextScene);
		}
	}
}
