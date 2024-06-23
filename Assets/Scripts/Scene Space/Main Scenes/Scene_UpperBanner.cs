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
public class Scene_UpperBanner : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public Image[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private TMP_Text GemsText;
	[SerializeField] private TMP_Text CoinsText;

	[SerializeField] private Button MenuButton;
	[SerializeField] private Button GemsButton;
	[SerializeField] private Button CoinsButton;
	[SerializeField] private Button CharonsButton;
	
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
	public static bool IsMainSceneTransition;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		// Set Colors
		if (IsMainSceneTransition) {
			foreach (Image Img in allImages)
				Img.color = OriginalColorImage;
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = OriginalColorWhiteText;
			foreach (Image TxtPink in allPinkTexts)
				TxtPink.color = OriginalColorPinkText;
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = OriginalColorDarkText;
		}

		else {
			foreach (Image Img in allImages)
				Img.color = AlphaColorImage;
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = AlphaColorWhiteText;
			foreach (Image TxtPink in allPinkTexts)
				TxtPink.color = AlphaColorPinkText;
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = AlphaColorDarkText;
		}

		// Set Buttons
		MenuButton.onClick.AddListener(MenuButtonClicking);
		GemsButton.onClick.AddListener(GemsButtonClicking);
		CoinsButton.onClick.AddListener(CoinsButtonClicking);
		CharonsButton.onClick.AddListener(CharonsButtonClicking);

		// Start Coroutine
		StartCoroutine(AllFadeIn());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		GemsText.text = Data_Controller.Instance.PlayerUserData.PlayerGemCount.ToString("n0");
		CoinsText.text = Data_Controller.Instance.PlayerUserData.PlayerCoinCount.ToString("n0");
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_UpperBanner: " + "All objects fading in begin");

		if (!IsMainSceneTransition) {
			while (ElapsedTime < 1.0f) {
				ElapsedTime += Time.deltaTime * Constant_Controller.FadingTime;

				foreach (Image Img in allImages)
					Img.color = Color.Lerp(AlphaColorImage, OriginalColorImage, ElapsedTime);
				foreach (TMP_Text TxtWhite in allWhiteTexts)
					TxtWhite.color = Color.Lerp(AlphaColorWhiteText, OriginalColorWhiteText, ElapsedTime);
				foreach (Image TxtPink in allPinkTexts)
					TxtPink.color = Color.Lerp(AlphaColorPinkText, OriginalColorPinkText, ElapsedTime);
				foreach (TMP_Text TxtDark in allDarkTexts)
					TxtDark.color = Color.Lerp(AlphaColorDarkText, OriginalColorDarkText, ElapsedTime);

				yield return null;
			}
		}
		
		Debug.Log("Scene_UpperBanner: " + "All objects fading in end");

		IsMainSceneTransition = true;
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_UpperBanner: " + "All objects fading out begin");

		if (!IsMainSceneTransition) {
			while (ElapsedTime < 1.0f) {
				ElapsedTime += Time.deltaTime * Constant_Controller.FadingTime;

				foreach (Image Img in allImages)
					Img.color = Color.Lerp(OriginalColorImage, AlphaColorImage, ElapsedTime);
				foreach (TMP_Text TxtWhite in allWhiteTexts)
					TxtWhite.color = Color.Lerp(OriginalColorWhiteText, AlphaColorWhiteText, ElapsedTime);
				foreach (Image TxtPink in allPinkTexts)
					TxtPink.color = Color.Lerp(OriginalColorPinkText, AlphaColorPinkText, ElapsedTime);
				foreach (TMP_Text TxtDark in allDarkTexts)
					TxtDark.color = Color.Lerp(OriginalColorDarkText, AlphaColorDarkText, ElapsedTime);

				yield return null;
			}
		}

		Debug.Log("Scene_UpperBanner: " + "All objects fading out end");

		if (OptionInt == 1) {
		// 	Debug.Log("Scene_UpperBanner: " + "Change scenes to 00_Main_Globe");
		// 	SceneManager.LoadScene(Core_Controller.Instance.Main_00);
		// }

		// else if (OptionInt == 2) {
		// 	PlayerPrefs.DeleteKey("TheFerryman_LoadUsername");
		// 	PlayerPrefs.DeleteKey("TheFerryman_LoadPassword");

		// 	Debug.Log("Scene_UpperBanner: " + "Change scenes to 01_Entry_LogInSignUp");
		// 	SceneManager.LoadScene(Core_Controller.Instance.Entry_01);
		// }

		// else if (OptionInt == 3) {
		// 	Debug.Log("Scene_UpperBanner: " + "Change scenes to 04_Entry_LogInError");
		// 	SceneManager.LoadScene(Core_Controller.Instance.Entry_04);
		}
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void MenuButtonClicking() {
		Debug.Log("Scene_UpperBanner: " + "Menu button has been pressed");
	}

	private void GemsButtonClicking() {
		Debug.Log("Scene_UpperBanner: " + "Gems button has been pressed");
	}

	private void CoinsButtonClicking() {
		Debug.Log("Scene_UpperBanner: " + "Coins button has been pressed");
	}

	private void CharonsButtonClicking() {
		Debug.Log("Scene_UpperBanner: " + "Charon's Competitions button has been pressed");
	}
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}