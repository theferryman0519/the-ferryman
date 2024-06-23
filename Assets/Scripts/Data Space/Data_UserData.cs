// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies
using ConstantSpace;

namespace DataSpace {
public class Data_UserData {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Data_UserData() {}

	// Main Player Data
	public string PlayerName { get; set; }
	public string PlayerEmail { get; set; }
	public string PlayerPassword { get; set; }
	public string PlayerUsername { get; set; }
	public string PlayerShipName { get; set; }

	public int PlayerLevel { get; set; }
	public int PlayerCoinCount { get; set; }
	public int PlayerGemCount { get; set; }
	public int PlayerFerriedSoulsCount { get; set; }

	// Login Data
	public int SevenDayLoginNumber { get; set; }
	public int TotalLoginTimes { get; set; }
	public int TotalLoginDays { get; set; }

	public string LastLoginDate { get; set; }

	public bool CollectedDailyReward { get; set; }

	// Player Avatar
	public int AvatarHeight { get; set; }
	public int AvatarWeight { get; set; }
	public int AvatarCloakColor { get; set; }
	public int AvatarHeadAccessory { get; set; }
	public int AvatarBodyAccessory { get; set; }

	// Tutorial Data
	public bool HasCompletedMainTutorial { get; set; }
	public bool HasCompletedShipyardTutorial { get; set; }
	public bool HasCompletedGlobeTutorial { get; set; }
	public bool HasCompletedHelmTutorial { get; set; }
	public bool HasCompletedLedgerTutorial { get; set; }
	public bool HasCompletedTradePostTutorial { get; set; }
	public bool HasCompletedCharonsCompetitionsTutorial { get; set; }

	// Current Travel Data
	public int RiverTraveling { get; set; }

	public string RiverTimeStarted { get; set; }
	public string RiverTimeAtEnd { get; set; }
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
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