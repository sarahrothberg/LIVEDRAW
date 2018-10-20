using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MainController : MonoBehaviour
{
	public GameObject[] brushes;

	public AudioClip bell;
	public AudioClip transition; 

	public PostProcessProfile flashInvertProf;
	public PostProcessProfile basicProf;
	public bool brushSwitchingEnabled;
	public AudioSource MainAudio; 

	public GameObject[] lines;

	public GameObject lineRenderer;
	public Camera mainCamera;

	public Animator fadePanel;

	// Update is called once per frame
	void Update()
	{
		#region brush selection 
		lines = GameObject.FindGameObjectsWithTag("Line");

		if (brushSwitchingEnabled)
		{
			if (Input.GetKeyDown("1"))
			{
				lineRenderer = brushes[0];
			}
			if (Input.GetKeyDown("2"))
			{
				lineRenderer = brushes[1];
			}
			if (Input.GetKeyDown("3"))
			{
				lineRenderer = brushes[2];
			}
			if (Input.GetKeyDown("4"))
			{
				lineRenderer = brushes[3];
			}
			if (Input.GetKeyDown("5"))
			{
				lineRenderer = brushes[4];
			}
			if (Input.GetKeyDown("6"))
			{
				lineRenderer = brushes[5];
			}
		}
		else
		{
			lineRenderer = brushes[0];
		}

		#endregion

		#region sound selection
		if (Input.GetKeyDown("a"))
		{
			MainAudio.clip = bell;
			MainAudio.loop = true;
			MainAudio.Play();
		}

		if (Input.GetKeyDown("s"))
		{
			MainAudio.clip = transition;
			MainAudio.loop = true;
			MainAudio.Play(); 
			StartCoroutine(AudioController.FadeIn(MainAudio, 2f));
		}

		if (Input.GetKeyDown("d"))
		{
			StartCoroutine(AudioController.FadeOut(MainAudio, 2f));
		}

		#endregion

		#region deleting stuff
		if (Input.GetKeyDown("d"))
		{
			Destroy(lines[lines.Length - 1]);
		}

		if (Input.GetKeyDown("space")) {
			fadePanel.SetTrigger("fade");
			Invoke ("deleteEverything", 2); 
		}

		#endregion


		Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("mouse down");
			Instantiate(lineRenderer, rayCast.GetPoint(10), Quaternion.identity);
		}
	}

	void deleteEverything()
	{
		for (var i = 0; i < lines.Length; i++)
		{
			Destroy(lines[i]);
		}
	}
}