using UnityEngine;
using System.Collections;
using System;

public class HandAnimatorManager : MonoBehaviour
{
	public StateModel[] stateModels;
	Animator handAnimator;

	public int currentState = 100;
	int lastState = -1;

	int action = 0;

	// Use this for initialization
	void Start ()
	{
		handAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			currentState = 0;
		} else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			currentState = 1;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			currentState = 2;
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			currentState = 3;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			currentState = 4;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			currentState = 5;
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			currentState = 6;
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			currentState = 7;
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			currentState = 8;
		} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			currentState = 9;
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			currentState = 10;
		} else if (Input.GetKeyDown (KeyCode.I)) {	
			currentState = 100;
		}

		if (lastState != currentState) {
			lastState = currentState;
			handAnimator.SetInteger ("State", currentState);
			TurnOnState (currentState);
		}

		handAnimator.SetBool ("Action", Input.GetMouseButton (0));
		handAnimator.SetBool ("Hold", Input.GetMouseButton (1));

		if (Input.GetMouseButton(0)) {
			action++;
			StartCoroutine(Punching());
		}

		/*
		if (action > 0)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, -0.06f, 0), 0.05f);
		}
		else {
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, -0.4f, 0), 0.05f);
		}
		*/
	}

	private IEnumerator Punching()
	{
		yield return new WaitForSeconds(2f);
		action--;
	}

	void TurnOnState (int stateNumber)
	{
		foreach (var item in stateModels) {
			if (item.stateNumber == stateNumber && !item.go.activeSelf)
				item.go.SetActive (true);
			else if (item.go.activeSelf)
				item.go.SetActive (false);
		}
	}


}

[Serializable]
public class StateModel
{
	public int stateNumber;
	public GameObject go;
}
