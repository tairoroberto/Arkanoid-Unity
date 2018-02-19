using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

	public Text txtScore;
	public static int score;

	void Update()
	{   
		txtScore.text = ScoreScript.score.ToString();

		if (score == 7) {
			SceneManager.LoadScene ("start-scene");
		}
	}
}
