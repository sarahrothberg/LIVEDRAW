using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDraw : MonoBehaviour {

	bool lifted = true; 

	void Update () {
		if (Input.GetMouseButton(0) && lifted)
		{
				Debug.Log("hi");

				Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

				Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);

				float rayDistance;
				if (objPlane.Raycast(mRay, out rayDistance))
					this.transform.position = mRay.GetPoint(rayDistance);
		}

		if (Input.GetMouseButtonUp(0))
		{
			lifted = false; 
		}
	}
}
