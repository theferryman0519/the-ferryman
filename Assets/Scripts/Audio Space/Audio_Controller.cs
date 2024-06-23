// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies

namespace AudioSpace {
public class Audio_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	[SerializeField]
	private AudioSource BackgroundMusic;
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Audio_Controller Instance {
		get {
			return AudioControllerInstance;
		}
	}
	
	private static Audio_Controller AudioControllerInstance = null;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		SetBackgroundMusic();
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((AudioControllerInstance != null) && (AudioControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			AudioControllerInstance = this;
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
	public void SetBackgroundMusic() {
        BackgroundMusic.loop = true;
        BackgroundMusic.volume = 0.4f;
    }
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}