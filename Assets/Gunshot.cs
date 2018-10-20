using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Gunshot : MonoBehaviour
{
	public PostProcessProfile flashInvertProf;
	public PostProcessProfile basicProf;
	Camera mainCamera;

	// Update is called once per frame
	void Start()
	{
		mainCamera = Camera.main; 
		FlashInvert();
	}
	public void FlashInvert()
	{
		mainCamera.GetComponent<PostProcessVolume>().profile = flashInvertProf;
		Invoke("returnToBasicProf", .1f);
	}

	public void returnToBasicProf()
	{
		mainCamera.GetComponent<PostProcessVolume>().profile = basicProf;
	}
}