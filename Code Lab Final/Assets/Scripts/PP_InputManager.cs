using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_InputManager : MonoBehaviour {

	private enum ControllerType {
		NONE,
		XBOX,
		PS4
	}
		
	private ControllerType[] myControllersType = new ControllerType[8];

	void Start () {
		UpdateMyControllersType ();
	}

	public void UpdateMyControllersType () {
		string[] t_names = Input.GetJoystickNames();

		int number = Mathf.Clamp (t_names.Length, 0, 8);

		for (int i = 0; i < number; i++) {
			myControllersType [i] = GetControllerType (t_names [i]);
		}
	}

	private ControllerType GetControllerType (string g_name){
		Debug.Log (g_name);

		if (g_name == "©Microsoft Corporation Xbox 360 Wired Controller" ||
			g_name == "Microsoft Xbox One Wired Controller") {
			Debug.Log ("XBOX!");
			return ControllerType.XBOX;
		}

		if (g_name == "Sony Computer Entertainment Wireless Controller") {
			Debug.Log ("PS4");
			return ControllerType.PS4;
		}

		if (g_name == "Sony PLAYSTATION(R)3 Controller") {
		}

		return ControllerType.NONE;
	}

//	public bool GetButtonUp (string g_buttonName, int g_joystickNumber) {
//		
//	}
//
//	public bool GetButton () {
//		
//	}
//
//	public bool GetButtonDown () {
//		
//	}
}
