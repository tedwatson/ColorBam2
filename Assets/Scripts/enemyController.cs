using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class enemyController : MonoBehaviour {

    //public Material[] materials;//Allows input of material colors in a set size of array;
    private Renderer Rend; //What are we rendering? Input object(Sphere,Cylinder,...) to render.

    private int index = 1;//Initialize at 1, otherwise you have to hit the object twice to change colors at first.

	public Material greyMaterial;
	public GameObject target;//reference for target object
	public Text countText;//refernece for Score Text
	private static int count; //Keeping the score static so that changes are reflected everywhere 
	public AudioClip[] soundFiles;//reference to audio files to be used
	public AudioSource soundSource;//reference to Audio Source
	private List<string> doneColors = new List<string>(); //A list to store the colors that have been already matched
	private Material originalMaterial;
    // Use this for initialization
    void Start()
    {
        Rend = GetComponent<Renderer>();//Gives functionality for the renderer
        Rend.enabled = true;//Makes the rendered 3d object visable if enabled;
		count = 0;//initializing the count to zero
		SetCountText();//Setting the score in UI

		// Save the enemy's original material, then set it to grey
		originalMaterial = Rend.material;
		Rend.material = greyMaterial;
    }


    void OnTriggerEnter(Collider c) {
		string bulletTag = c.GetComponent<Renderer> ().material.name.Replace ("(Instance)", "").ToString ().Trim();//A bullet's tag would be the name of the material of the renderer
		Debug.Log (bulletTag);
		// if the bullet is the same color, we've scored!
		if (bulletTag == target.gameObject.tag) {
			//if one color is done then hitting the same target wont increase the score.
			if (!doneColors.Contains(bulletTag))
			{
				doneColors.Add (bulletTag);//Matched colors are added to the list of colors that are done
				target.GetComponent<Renderer> ().material = originalMaterial; //c.GetComponent<Renderer> ().material;//Giving the target the same color as the color matched.
				//poof sound
				//soundSource.PlayOneShot(soundFiles[0]);
				Debug.Log ("collided");
				count = count + 1;//Incrementing the count
				Debug.Log (count);
				SetCountText ();// Setting the score on the score board
			}

		} 
		else {
			//bullet hitting a hard surface sound 
			//soundSource.PlayOneShot(soundFiles[0]);
			//Debug.Log ("Not collided");
		}
    }

	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
		//Winning score
		if (count == 7)
			//"You win!"
			//Restart?
			//SceneManager.LoadScene("Main Scene");
		{

		}
	}
}
