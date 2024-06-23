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
public class Scene_HelmWheelRotation : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public TMP_Text[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private GameObject HelmWheel;
	
// --------------- PRIVATE VARIABLES ---------------
	Color OriginalColorImage = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorPinkText = new Color(0.678f, 0.349f, 0.898f, 1.0f);
	Color OriginalColorDarkText = new Color(0.106f, 0.024f, 0.161f, 1.0f);

	Color AlphaColorImage = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorPinkText = new Color(0.678f, 0.349f, 0.898f, 0.0f);
	Color AlphaColorDarkText = new Color(0.106f, 0.024f, 0.161f, 0.0f);

	Vector3 rotationInitial = new Vector3(0,0,0);
	Vector3 rotationRight = new Vector3(0,0,-20);
	Vector3 rotationLeft = new Vector3(0,0,20);
	Vector3 rotationFarLeft = new Vector3(0,0,1000);
	Vector3 rotationFarRight = new Vector3(0,0,-1000);

	Vector3 currentRotation;
	
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

		HelmWheel.transform.localRotation = Quaternion.Euler(0,0,0);
		
		// Start Coroutine
		StartCoroutine(AllFadeIn());
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		WheelRocking();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_HelmWheelRotation: " + "All objects fading in begin");

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
		
		Debug.Log("Scene_HelmWheelRotation: " + "All objects fading in end");
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_HelmWheelRotation: " + "All objects fading out begin");

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

		Debug.Log("Scene_HelmWheelRotation: " + "All objects fading out end");
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void WheelRocking() {
		if (!Scene_WheelButtons.IsButtonTurningOn) {
			HelmWheel.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(rotationLeft), Quaternion.Euler(rotationRight), (Mathf.Sin(Constant_Controller.RotationSpeed * Time.time) + 1.0f) / 2.0f);

			currentRotation = HelmWheel.transform.localRotation.eulerAngles;
		}

		else {
			if (Scene_WheelButtons.IsTurningLeft) {
				HelmWheel.transform.Rotate(rotationFarLeft * Mathf.Sin(Time.deltaTime * Constant_Controller.WheelTurnSpeed));
			}

			else {
				HelmWheel.transform.Rotate(rotationFarRight * Mathf.Sin(Time.deltaTime * Constant_Controller.WheelTurnSpeed));
			}
		}
	}

// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}