using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour {

	private int playerLives;
	private int enemyLives;
	private int randomNumber;

	//Buttons enabled?
	private bool buttonsEnabled;

	public Text gameOutputText;
	public Text playerLivesCounter;
	public Text enemyLivesCounter;

	// Use this for initialization
	void Start () {
		playerLives = 3;
		enemyLives = 3;
		//Button enabler
		buttonsEnabled = true;
		SetUpGame ();
	}

	private void SetUpGame(){
		//Change the text of the textbox
		gameOutputText.text = "Choose a move to make: Rock, Paper, or Scissors";
		playerLivesCounter.text = playerLives.ToString ();
		enemyLivesCounter.text = enemyLives.ToString ();
	}

	public void ClickButton(int buttonClicked){
		if (buttonsEnabled == true) {
			//Random.range returns a random number between a min [in
			randomNumber = Random.Range (1, 4);
			if (buttonClicked == 1) {
				gameOutputText.text = "You chose Rock";
			} else if (buttonClicked == 2) {
				gameOutputText.text = "You chose Paper";
			} else if (buttonClicked == 3) {
				gameOutputText.text = "You chose Scissors";
			}
			DoBattle (buttonClicked, randomNumber);
		}
	}

	//Debug game enders
	public void DebugButton(int debugButton){
		if (buttonsEnabled == true) {
			if (debugButton == 1) {
				enemyLives = 1;
				DoBattle (1, 3);
			} else if (debugButton == 2) {
				playerLives = 1;
				DoBattle (3, 1);
			}
		}
	}

	private void DoBattle(int playerChoice, int enemyChoice){
		if (playerChoice == enemyChoice) {
			gameOutputText.text += "\nThe enemy chose the same and you have drawn!";
		} else if (playerChoice == 2 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have won!";
			enemyLives--;
		} else if (playerChoice == 3 && enemyChoice == 2) {
			gameOutputText.text += "\nThe enemy chose Paper and you have won!";
			enemyLives--;
		} else if (playerChoice == 1 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have won!";
			enemyLives--;
		} else if (playerChoice == 1 && enemyChoice == 2) {
			gameOutputText.text += "\nThe enemy chose Paper and you have FAILED!";
			playerLives--;
		} else if (playerChoice == 2 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have LOST!";
			playerLives--;
		} else if (playerChoice == 3 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have GOOFED!";
			playerLives--;
		}
		//Update the UI to reflect the new values.
		//Win/loss messages based on current scores added
		//Disabling of buttons added
		if (playerLives > 0 && enemyLives > 0) {
			gameOutputText.text += "\n\nChoose a move to make: Rock, Paper, or Scissors";
			playerLivesCounter.text = playerLives.ToString ();
			enemyLivesCounter.text = enemyLives.ToString ();
		} else if (playerLives > 0 && enemyLives == 0) {
			gameOutputText.text = "You have won completely.\nCongratulations, you beat a computer.\nI hope you feel good about yourself.";
			buttonsEnabled = false;
			playerLivesCounter.text = playerLives.ToString ();
			enemyLivesCounter.text = enemyLives.ToString ();
		} else if (playerLives == 0 && enemyLives > 0) {
			gameOutputText.text = "You have failed so you get nothing!\nYou lose!\nGood day, sir!";
			buttonsEnabled = false;
			playerLivesCounter.text = playerLives.ToString ();
			enemyLivesCounter.text = enemyLives.ToString ();
		}
	}
}
