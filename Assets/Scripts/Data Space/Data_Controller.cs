// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies

namespace DataSpace {
public class Data_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	// Loading Data
	public float LoadingAmount = 0.0f;

	// Player Data
	public string PlayerName;

	// Friend Data
	public Dictionary<string, Data_FriendData> FriendsList = new();

	// Set Data Classes
	public Data_RiverData PlayerRiverData = new();
	public Data_ShipData PlayerShipData = new();
	public Data_SoulData_Lifetime PlayerSoulDataLifetime = new();
	public Data_SoulData_Weekly PlayerSoulDataWeekly = new();
	public Data_UserData PlayerUserData = new();
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Data_Controller Instance {
		get {
			return DataControllerInstance;
		}
	}
	
	private static Data_Controller DataControllerInstance = null;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((DataControllerInstance != null) && (DataControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			DataControllerInstance = this;
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
	
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}