// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies

namespace SceneSpace {
public class Scene_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Vector3 ParalaxBackgroundPos;
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Scene_Controller Instance {
		get {
			return SceneControllerInstance;
		}
	}
	
	private static Scene_Controller SceneControllerInstance = null;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((SceneControllerInstance != null) && (SceneControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			SceneControllerInstance = this;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	#region Entry Scenes
	public void SuccessfulLogIn() {
        if (SceneManager.GetActiveScene().name == "02_Entry_LogIn") {
            Debug.Log("Scene_Controller: " + "User has successfully been able to log in");
            GameObject.Find("MainFunctions").GetComponentInChildren<Scene_Entry_LogIn>().SuccessfullyLoggedIn();
        }
    }

	public void UnsuccessfulLogIn() {
        if (SceneManager.GetActiveScene().name == "02_Entry_LogIn") {
            Debug.Log("Scene_Controller: " + "User could not successfully log in");
            GameObject.Find("MainFunctions").GetComponentInChildren<Scene_Entry_LogIn>().UnsuccessfullyLoggedIn();
        }
    }

	#endregion
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}