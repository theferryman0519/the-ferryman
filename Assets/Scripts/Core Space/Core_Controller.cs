// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies

namespace CoreSpace {
public class Core_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	// Entry Scenes
	public string Entry_00 = "00_Entry_OpeningLogos";
	public string Entry_01 = "01_Entry_LogInSignUp";
	public string Entry_02 = "02_Entry_LogIn";
	public string Entry_03 = "03_Entry_SignUp";
	public string Entry_04 = "04_Entry_LogInError";
	public string Entry_05 = "05_Entry_SignUpError";
	
	// Tutorial Scenes
	public string Tutorial_00 = "00_Tutorial_Opening";
	public string Tutorial_01 = "01_Tutorial_AvatarCreation";
	public string Tutorial_02 = "02_Tutorial_OpeningContinued";
	public string Tutorial_03 = "03_Tutorial_Shipyard";
	public string Tutorial_04 = "04_Tutorial_GlobeMain";
	public string Tutorial_05 = "05_Tutorial_GlobeRiverMain";
	public string Tutorial_06 = "06_Tutorial_GlobeRiverStart";
	public string Tutorial_07 = "07_Tutorial_GlobeRiverMiddle";
	public string Tutorial_08 = "08_Tutorial_GlobeRiverEnd";
	public string Tutorial_09 = "09_Tutorial_GlobeSharedExperiences";
	public string Tutorial_10 = "10_Tutorial_Helm";
	public string Tutorial_11 = "11_Tutorial_Ledger";
	public string Tutorial_12 = "12_Tutorial_TradePost";
	public string Tutorial_13 = "13_Tutorial_CharonsCompetitions";

	// Main Scenes
	public string Main_00 = "00_Main_Globe";
	public string Main_01 = "01_Main_Helm";
	public string Main_02 = "02_Main_Ledger";
	public string Main_03 = "03_Main_Shipyard";
	public string Main_04 = "04_Main_TradePost";
	public string Main_05 = "05_Main_CharonsCompetitions";

	// Globe Scenes
	public string Globe_00 = "00_Globe_RiverSelect";
	public string Globe_01 = "01_Globe_RiverSailing";
	public string Globe_02 = "02_Globe_RiverComplete";

	// Helm Scenes
	public string Helm_00 = "00_Helm_Friends";
	public string Helm_01 = "01_Helm_Avatar";

	// Ledger Scenes
	public string Ledger_00 = "00_Ledger_SoulsMainLook";
	public string Ledger_01 = "01_Ledger_SoulsInsideLook";

	// Shipyard Scenes
	public string Shipyard_00 = "00_Shipyard_PurchaseNew";
	public string Shipyard_01 = "01_Shipyard_Customize";
	public string Shipyard_02 = "02_Shipyard_TradeWithFriends";

	// Trade Post Scenes
	public string TradePost_00 = "00_TradePost_AvatarPurchases";
	public string TradePost_01 = "01_TradePost_Enhancements";
	public string TradePost_02 = "02_TradePost_CoinsAndGems";
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Core_Controller Instance {
		get {
			return CoreControllerInstance;
		}
	}
	
	private static Core_Controller CoreControllerInstance = null;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((CoreControllerInstance != null) && (CoreControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			CoreControllerInstance = this;
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