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

namespace SceneSpace {
public class Scene_Entry_OpeningLogos : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public TMP_Text[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private RectTransform LoadingBar;

	[SerializeField] private TMP_Text VersionText;
	
// --------------- PRIVATE VARIABLES ---------------
	Color OriginalColorImage = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorPinkText = new Color(0.678f, 0.349f, 0.898f, 1.0f);
	Color OriginalColorDarkText = new Color(0.106f, 0.024f, 0.161f, 1.0f);

	Color AlphaColorImage = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorPinkText = new Color(0.678f, 0.349f, 0.898f, 0.0f);
	Color AlphaColorDarkText = new Color(0.106f, 0.024f, 0.161f, 0.0f);
	
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

		// Set Loading Bar Width
		LoadingBar.offsetMax = new Vector2(-950,0);

		// Set Version Text
		VersionText.text = "Version: " + Application.version;

		Scene_UpperBanner.IsMainSceneTransition = false;
	
		// Start Coroutines
		StartCoroutine(AllFadeIn());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		CheckLoadingStatus();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_Entry_OpeningLogos: " + "All objects fading in begin");

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
		
		Debug.Log("Scene_Entry_OpeningLogos: " + "All objects fading in end");
		StartCoroutine(CheckStatuses());
	}

	private IEnumerator CheckStatuses() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_Entry_OpeningLogos: " + "Checking statuses for data download");

		while (ElapsedTime < 2.0f) {
			ElapsedTime += Time.deltaTime;
			yield return null;
		}

		Constant_Controller.Instance.SetAllConstantDataPieces();

		ElapsedTime = 0.0f;
		while (ElapsedTime < 1.0f) {
			ElapsedTime += Time.deltaTime;
			yield return null;
		}

		if (LoadingBar.offsetMax.x >= 0) {
			StartCoroutine(AllFadeOut());
		}

		else {
			StartCoroutine(CheckStatuses());
		}
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_Entry_OpeningLogos: " + "All objects fading out begin");

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

		Debug.Log("Scene_Entry_OpeningLogos: " + "All objects fading out end");

		DetermineFirstTimeUser();
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void DetermineFirstTimeUser() {
		Debug.Log("Scene_Entry_OpeningLogos: " + "Determining if this is the first time app is run");

		int IntAppHasRun = PlayerPrefs.GetInt("TheFerryman_AppHasRun");

		if (IntAppHasRun == 0) {
			Debug.Log("Scene_Entry_OpeningLogos: " + "App is being run for the first time");
			PlayerPrefs.SetInt("TheFerryman_AppHasRun", 1);

			Debug.Log("Scene_Entry_OpeningLogos: " + "Change scenes to 00_Tutorial_Opening");
			SceneManager.LoadScene(Core_Controller.Instance.Tutorial_00);
		}

		else {
			Debug.Log("Scene_Entry_OpeningLogos: " + "App has been run before");

			Debug.Log("Scene_Entry_OpeningLogos: " + "Change scenes to 01_Entry_LogInSignUp");
			SceneManager.LoadScene(Core_Controller.Instance.Entry_01);
		}
	}

	private void CheckLoadingStatus() {
		if (LoadingBar.offsetMax.x < 0) {
			LoadingBar.offsetMax = new Vector2(-950.0f + (Data_Controller.Instance.LoadingAmount * 9.5f), 0);
		}

		else {
			LoadingBar.offsetMax = new Vector2(0, 0);
		}
	}
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}