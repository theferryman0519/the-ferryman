// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies
using ConstantSpace;
using CoreSpace;
using DataSpace;
using FirebaseSpace;

namespace SceneSpace {
public class Scene_Entry_LogInSignUp : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public TMP_Text[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private Button LogInButton;
	[SerializeField] private Button SignUpButton;
	
// --------------- PRIVATE VARIABLES ---------------
	Color OriginalColorImage = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorPinkText = new Color(0.678f, 0.349f, 0.898f, 1.0f);
	Color OriginalColorDarkText = new Color(0.106f, 0.024f, 0.161f, 1.0f);

	Color AlphaColorImage = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorPinkText = new Color(0.678f, 0.349f, 0.898f, 0.0f);
	Color AlphaColorDarkText = new Color(0.106f, 0.024f, 0.161f, 0.0f);

	int OptionInt = 0;
	
// --------------- STATIC VARIABLES ---------------
	
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		// Set Colors
		foreach (Image Img in allImages)
			Img.color = AlphaColorImage;
		foreach (TMP_Text TxtWhite in allWhiteTexts)
			TxtWhite.color = AlphaColorWhiteText;
		foreach (TMP_Text TxtPink in allPinkTexts)
			TxtPink.color = AlphaColorPinkText;
		foreach (TMP_Text TxtDark in allDarkTexts)
			TxtDark.color = AlphaColorDarkText;

		// Set Buttons
		LogInButton.onClick.AddListener(LogInButtonClicking);
		SignUpButton.onClick.AddListener(SignUpButtonClicking);

		// Check Auto Login
		CheckAutoLogin();
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_Entry_LogInSignUp: " + "All objects fading in begin");

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * Constant_Controller.FadingTime;

			foreach (Image Img in allImages)
				Img.color = Color.Lerp(AlphaColorImage, OriginalColorImage, ElapsedTime);
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = Color.Lerp(AlphaColorWhiteText, OriginalColorWhiteText, ElapsedTime);
			foreach (TMP_Text TxtPink in allPinkTexts)
				TxtPink.color = Color.Lerp(AlphaColorPinkText, OriginalColorPinkText, ElapsedTime);
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = Color.Lerp(AlphaColorDarkText, OriginalColorDarkText, ElapsedTime);

			yield return null;
		}
		
		Debug.Log("Scene_Entry_LogInSignUp: " + "All objects fading in end");
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_Entry_LogInSignUp: " + "All objects fading out begin");

		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime * Constant_Controller.FadingTime;

			foreach (Image Img in allImages)
				Img.color = Color.Lerp(OriginalColorImage, AlphaColorImage, ElapsedTime);
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = Color.Lerp(OriginalColorWhiteText, AlphaColorWhiteText, ElapsedTime);
			foreach (TMP_Text TxtPink in allPinkTexts)
				TxtPink.color = Color.Lerp(OriginalColorPinkText, AlphaColorPinkText, ElapsedTime);
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = Color.Lerp(OriginalColorDarkText, AlphaColorDarkText, ElapsedTime);

			yield return null;
		}

		Debug.Log("Scene_Entry_LogInSignUp: " + "All objects fading out end");

		if (OptionInt == 1) {
			Debug.Log("Scene_Entry_LogInSignUp: " + "Change scenes to 02_Entry_LogIn");
			SceneManager.LoadScene(Core_Controller.Instance.Entry_02);
		}

		else if (OptionInt == 2) {
			Debug.Log("Scene_Entry_LogInSignUp: " + "Change scenes to 00_Tutorial_Opening");
			SceneManager.LoadScene(Core_Controller.Instance.Tutorial_00);
		}
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void LogInButtonClicking() {
		Debug.Log("Scene_Entry_LogInSignUp: " + "Log In button has been pressed");
		OptionInt = 1;
		StartCoroutine(AllFadeOut());
	}

	private void SignUpButtonClicking() {
		Debug.Log("Scene_Entry_LogInSignUp: " + "Sign Up button has been pressed");
		OptionInt = 2;
		StartCoroutine(AllFadeOut());
	}

	private void CheckAutoLogin() {
		Debug.Log("Scene_Entry_LogInSignUp: " + "Checking for auto-login");

		string UserUsername = PlayerPrefs.GetString("TheFerryman_LoadUsername");
		string UserPassword = PlayerPrefs.GetString("TheFerryman_LoadPassword");

		if (string.IsNullOrEmpty(UserUsername) || string.IsNullOrEmpty(UserPassword)) {
			StartCoroutine(AllFadeIn());
		}

		else {
			Firebase_Controller.Instance.DownloadMainPlayerData();
		}
	}
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}