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
public class Scene_SailingTime : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public TMP_Text[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private TMP_Text SailingTimeText;
	
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
		if (Scene_UpperBanner.IsMainSceneTransition) {
			foreach (Image Img in allImages)
				Img.color = OriginalColorImage;
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = OriginalColorWhiteText;
			foreach (TMP_Text TxtPink in allPinkTexts)
				TxtPink.color = OriginalColorPinkText;
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = OriginalColorDarkText;
		}

		else {
			foreach (Image Img in allImages)
				Img.color = AlphaColorImage;
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = AlphaColorWhiteText;
			foreach (TMP_Text TxtPink in allPinkTexts)
				TxtPink.color = AlphaColorPinkText;
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = AlphaColorDarkText;
		}

		CheckIfGlobeScenes();
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		SetSailingText();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_SailingTime: " + "All objects fading in begin");

		if (!Scene_UpperBanner.IsMainSceneTransition) {
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
		}
		
		Debug.Log("Scene_SailingTime: " + "All objects fading in end");
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_SailingTime: " + "All objects fading out begin");

		if (!Scene_UpperBanner.IsMainSceneTransition) {
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
		}

		Debug.Log("Scene_SailingTime: " + "All objects fading out end");
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void CheckIfGlobeScenes() {
		if ((SceneManager.GetActiveScene().name != "00_Globe_RiverSelect") && (SceneManager.GetActiveScene().name != "02_Globe_RiverComplete") && (Data_Controller.Instance.PlayerUserData.RiverTraveling != 0)) {
			// Start Coroutine
			StartCoroutine(AllFadeIn());
		}

		else {
			foreach (Image Img in allImages)
				Img.color = AlphaColorImage;
			foreach (TMP_Text TxtWhite in allWhiteTexts)
				TxtWhite.color = AlphaColorWhiteText;
			foreach (TMP_Text TxtPink in allPinkTexts)
				TxtPink.color = AlphaColorPinkText;
			foreach (TMP_Text TxtDark in allDarkTexts)
				TxtDark.color = AlphaColorDarkText;
		}
	}

	private void SetSailingText() {
		// float TimeDifference = float.Parse(Data_Controller.Instance.PlayerUserData.RiverTimeAtEnd) - float.Parse(Data_Controller.Instance.PlayerUserData.RiverTimeStarted);
		float TimeDifference = 0.0f;
		string RiverName = Data_Controller.Instance.PlayerUserData.RiverTraveling.ToString();

		SailingTimeText.text = TimeDifference + " Left Sailing on the " + RiverName;
	}
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}