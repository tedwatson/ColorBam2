using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiHandling : MonoBehaviour {
	public GameObject startUI;
	//for toggeling the UI panels
	public void toggleUI(){
		startUI.SetActive (!startUI.activeSelf);
	}

}
