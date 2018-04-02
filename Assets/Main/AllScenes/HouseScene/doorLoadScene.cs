using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml;
using AssemblyCSharp;
using UnityEngine.SceneManagement;

public class doorLoadScene : MonoBehaviour {
	private bool showText = false;
	private string text = "";
    public int level;


	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Dhillon Finished UI") {
			showText = true; //set showtext to true when there's a collision with Dhillon
			text = "Press E";
		}
	}

    void OnCollisionStay(Collision collision)
    {
		if (collision.gameObject.name == "Dhillon Finished UI" && Input.GetKeyDown ("e")) {
			Debug.Log ("you changed scene");
			SceneManager.LoadScene ("HomeScene"); //load and change scene to HomeScene
		}
    }

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.name == "Dhillon Finished UI")
		{
			showText = false;
		}
	}

	private void displayGui(bool showtext){
		if (showtext){ //display GUI if showtext is true
			GUI.Label (new Rect (960, 300, 1000, 1000), text);
		}
	}
	void OnGUI(){
		displayGui (showText);
	}
}
