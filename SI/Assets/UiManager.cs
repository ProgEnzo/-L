using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    GameObject[] pauseObjects;
	GameObject[] finishObjects;
	PlayerController playerController;
	void Start () 
	{
		Time.timeScale = 1;

		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");			
		finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");			


		hidePaused();
		hideFinished();

		if(Application.loadedLevelName == "SampleScene")
			playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1 /*&& playerController.SO_Controller.alive == true*/)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0 /*&& playerController.SO_Controller.alive == true*/)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}

		if (playerController.alive == false)
		{
			showFinished();
		}
	}

	public void Reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void pauseControl()
	{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	public void showPaused()
	{
		foreach(GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	public void hidePaused()
	{
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	public void showFinished()
	{
		foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
	}

	public void hideFinished()
	{
		foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
	}

	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}
}
