using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml;
using AssemblyCSharp;
using UnityEngine.SceneManagement;

public class loadClass : MonoBehaviour {
	private bool showText = false;
	private string text = "";
	public int level;


	void OnCollisionEnter(Collision col){
		/*When Dhillon runs into house door, prompt to press E*/
		if (col.gameObject.name == "Dhillon Finished UI") {
			showText = true; //set showtext true when there is a collision with Dhillon
			text = "Press E";
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.name == "Dhillon Finished UI" && Input.GetKeyDown ("e")) {
			/*Change scene to classroom*/
			Debug.Log ("you changed scenes");
			SceneManager.LoadScene ("Classroom Scene"); //this line here loads and changes scene
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
		if (showtext){ // display GUI when showtext is true
			GUI.Label (new Rect (960, 300, 1000, 1000), text);
		}
	}
	void OnGUI(){
		displayGui (showText);
	}

}
