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
public class Scene_WheelButtons : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	public Image[] allImages;
	public TMP_Text[] allWhiteTexts;
	public TMP_Text[] allPinkTexts;
	public TMP_Text[] allDarkTexts;

	[SerializeField] private TMP_Text TitleText;

	[SerializeField] private Button L2Button;
	[SerializeField] private Button L1Button;
	[SerializeField] private Button MButton;
	[SerializeField] private Button R1Button;
	[SerializeField] private Button R2Button;

	[SerializeField] private Sprite WheelSprite_Globe;
	[SerializeField] private Sprite WheelSprite_Helm;
	[SerializeField] private Sprite WheelSprite_Shipyard;
	[SerializeField] private Sprite WheelSprite_Ledger;
	[SerializeField] private Sprite WheelSprite_TradePost;
	
// --------------- PRIVATE VARIABLES ---------------
	Color OriginalColorImage = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	Color OriginalColorPinkText = new Color(0.678f, 0.349f, 0.898f, 1.0f);
	Color OriginalColorDarkText = new Color(0.106f, 0.024f, 0.161f, 1.0f);

	Color AlphaColorImage = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorWhiteText = new Color(1.0f, 1.0f, 1.0f, 0.0f);
	Color AlphaColorPinkText = new Color(0.678f, 0.349f, 0.898f, 0.0f);
	Color AlphaColorDarkText = new Color(0.106f, 0.024f, 0.161f, 0.0f);

	List<string> ClickingStrings = new();

	IEnumerator CoroutineStart;
	IEnumerator CoroutineRight;
	IEnumerator CoroutineLeft;

	// L2
	Vector2 offsetRightL2 = new Vector2(132,125);
	Vector2 offsetStartL2 = new Vector2(0,0);
	Vector2 offsetLeftL2 = new Vector2(-16,-103);
	Vector2 currentOffsetMinL2;
	Vector2 currentOffsetMaxL2;

	// L1
	Vector2 offsetRightL1 = new Vector2(132,53);
	Vector2 offsetStartL1 = new Vector2(0,0);
	Vector2 offsetLeftL1 = new Vector2(-77,-83);
	Vector2 currentOffsetMinL1;
	Vector2 currentOffsetMaxL1;

	// M
	Vector2 offsetRightM = new Vector2(132,-41);
	Vector2 offsetStartM = new Vector2(0,0);
	Vector2 offsetLeftM = new Vector2(-132,-41);
	Vector2 currentOffsetMinM;
	Vector2 currentOffsetMaxM;

	// R1
	Vector2 offsetRightR1 = new Vector2(77,-83);
	Vector2 offsetStartR1 = new Vector2(0,0);
	Vector2 offsetLeftR1 = new Vector2(-132,53);
	Vector2 currentOffsetMinR1;
	Vector2 currentOffsetMaxR1;

	// R2
	Vector2 offsetRightR2 = new Vector2(16,-103);
	Vector2 offsetStartR2 = new Vector2(0,0);
	Vector2 offsetLeftR2 = new Vector2(-132,125);
	Vector2 currentOffsetMinR2;
	Vector2 currentOffsetMaxR2;

	// Turning
	Vector3 offsetTurnLeft = new Vector3(-2000,0,0);
	Vector3 offsetTurnRight = new Vector3(2000,0,0);

	int OptionInt = 0;
	
// --------------- STATIC VARIABLES ---------------
	public static bool IsButtonTurningOn = false;
	public static bool IsTurningLeft = false;
	
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

		// Set Buttons
		L2Button.onClick.AddListener(L2ButtonClicking);
		L1Button.onClick.AddListener(L1ButtonClicking);
		MButton.onClick.AddListener(MButtonClicking);
		R1Button.onClick.AddListener(R1ButtonClicking);
		R2Button.onClick.AddListener(R2ButtonClicking);

		// Set Wheel Data
		SetWheelData();
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		
	}
	
// --------------- UPDATE FUNCTION ---------------
	void Update() {
		ButtonRocking();
	}
	
// ---------------------------------------- END: INITIAL FUNCTIONS ----------------------------------------
// ---------------------------------------- START: ENUMERATOR FUNCTIONS ----------------------------------------
	private IEnumerator AllFadeIn() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_WheelButtons: " + "All objects fading in begin");

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
		
		Debug.Log("Scene_WheelButtons: " + "All objects fading in end");
	}

	private IEnumerator AllFadeOut() {
		float ElapsedTime = 0.0f;
		Debug.Log("Scene_WheelButtons: " + "All objects fading out begin");

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

		Debug.Log("Scene_WheelButtons: " + "All objects fading out end");

		if (OptionInt == 1) {
			Debug.Log("Scene_WheelButtons: " + "Changing scenes to next main scene");
			SceneManager.LoadScene(ClickingStrings[0]);
		}

		else if (OptionInt == 2) {
			Debug.Log("Scene_WheelButtons: " + "Changing scenes to next main scene");
			SceneManager.LoadScene(ClickingStrings[1]);
		}

		else if (OptionInt == 3) {
			Debug.Log("Scene_WheelButtons: " + "Changing scenes to next main scene");
			SceneManager.LoadScene(ClickingStrings[2]);
		}

		else if (OptionInt == 4) {
			Debug.Log("Scene_WheelButtons: " + "Changing scenes to next main scene");
			SceneManager.LoadScene(ClickingStrings[3]);
		}

		else if (OptionInt == 5) {
			Debug.Log("Scene_WheelButtons: " + "Changing scenes to next main scene");
			SceneManager.LoadScene(ClickingStrings[4]);
		}
	}
	
// ---------------------------------------- END: ENUMERATOR FUNCTIONS ----------------------------------------
// ---------------------------------------- START: VOID FUNCTIONS ----------------------------------------
	private void L2ButtonClicking() {
		Debug.Log("Scene_WheelButtons: " + "Left 2nd button has been pressed");
		OptionInt = 1;
		IsTurningLeft = true;
		Turning();
	}

	private void L1ButtonClicking() {
		Debug.Log("Scene_WheelButtons: " + "Left 1st button has been pressed");
		OptionInt = 2;
		IsTurningLeft = true;
		Turning();
	}

	private void MButtonClicking() {
		Debug.Log("Scene_WheelButtons: " + "Middle button has been pressed - no movement needed");
	}

	private void R1ButtonClicking() {
		Debug.Log("Scene_WheelButtons: " + "Right 1st button has been pressed");
		OptionInt = 4;
		IsTurningLeft = false;
		Turning();
	}

	private void R2ButtonClicking() {
		Debug.Log("Scene_WheelButtons: " + "Right 2nd button has been pressed");
		OptionInt = 5;
		IsTurningLeft = false;
		Turning();
	}

	private void ButtonRocking() {
		if (!IsButtonTurningOn) {
			ButtonRock(L2Button, offsetLeftL2, offsetRightL2);
			ButtonRock(L1Button, offsetLeftL1, offsetRightL1);
			ButtonRock(MButton, offsetLeftM, offsetRightM);
			ButtonRock(R1Button, offsetLeftR1, offsetRightR1);
			ButtonRock(R2Button, offsetLeftR2, offsetRightR2);
		}

		else {
			ButtonsTurning();
		}
	}

	private void ButtonRock(Button button, Vector2 offsetInitial, Vector2 offsetEnding) {
		button.gameObject.GetComponent<RectTransform>().offsetMin = Vector2.Lerp(offsetInitial, offsetEnding, (Mathf.Sin(Constant_Controller.RotationSpeed * Time.time) + 1.0f) / 2.0f);
		button.gameObject.GetComponent<RectTransform>().offsetMax = Vector2.Lerp(offsetInitial, offsetEnding, (Mathf.Sin(Constant_Controller.RotationSpeed * Time.time) + 1.0f) / 2.0f);

		if (button == L2Button) {
			currentOffsetMinL2 = button.gameObject.GetComponent<RectTransform>().offsetMin;
			currentOffsetMaxL2 = button.gameObject.GetComponent<RectTransform>().offsetMax;
		}

		else if (button == L1Button) {
			currentOffsetMinL1 = button.gameObject.GetComponent<RectTransform>().offsetMin;
			currentOffsetMaxL1 = button.gameObject.GetComponent<RectTransform>().offsetMax;
		}

		else if (button == MButton) {
			currentOffsetMinM = button.gameObject.GetComponent<RectTransform>().offsetMin;
			currentOffsetMaxM = button.gameObject.GetComponent<RectTransform>().offsetMax;
		}

		else if (button == R1Button) {
			currentOffsetMinR1 = button.gameObject.GetComponent<RectTransform>().offsetMin;
			currentOffsetMaxR1 = button.gameObject.GetComponent<RectTransform>().offsetMax;
		}

		else if (button == R2Button) {
			currentOffsetMinR2 = button.gameObject.GetComponent<RectTransform>().offsetMin;
			currentOffsetMaxR2 = button.gameObject.GetComponent<RectTransform>().offsetMax;
		}
	}

	private void ButtonsTurning() {
		if (IsTurningLeft) {
			L2Button.transform.position = Vector3.MoveTowards(L2Button.transform.position, new Vector3(-2500, L2Button.transform.position.y, L2Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			L1Button.transform.position = Vector3.MoveTowards(L1Button.transform.position, new Vector3(-2500, L1Button.transform.position.y, L1Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			MButton.transform.position = Vector3.MoveTowards(MButton.transform.position, new Vector3(-2500, MButton.transform.position.y, MButton.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			R1Button.transform.position = Vector3.MoveTowards(R1Button.transform.position, new Vector3(-2500, R1Button.transform.position.y, R1Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			R2Button.transform.position = Vector3.MoveTowards(R2Button.transform.position, new Vector3(-2500, R2Button.transform.position.y, R2Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			TitleText.transform.position = Vector3.MoveTowards(TitleText.transform.position, new Vector3(-2500, TitleText.transform.position.y, TitleText.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
		}

		else {
			L2Button.transform.position = Vector3.MoveTowards(L2Button.transform.position, new Vector3(2500, L2Button.transform.position.y, L2Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			L1Button.transform.position = Vector3.MoveTowards(L1Button.transform.position, new Vector3(2500, L1Button.transform.position.y, L1Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			MButton.transform.position = Vector3.MoveTowards(MButton.transform.position, new Vector3(2500, MButton.transform.position.y, MButton.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			R1Button.transform.position = Vector3.MoveTowards(R1Button.transform.position, new Vector3(2500, R1Button.transform.position.y, R1Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			R2Button.transform.position = Vector3.MoveTowards(R2Button.transform.position, new Vector3(2500, R2Button.transform.position.y, R2Button.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
			TitleText.transform.position = Vector3.MoveTowards(TitleText.transform.position, new Vector3(2500, TitleText.transform.position.y, TitleText.transform.position.z), Time.time * Constant_Controller.ShiftingSpeed);
		}
	}

	private void Turning() {
		Debug.Log("Scene_WheelButtons: " + "Initializing the turn");

		IsButtonTurningOn = true;
		StartCoroutine(AllFadeOut());
	}

	private void SetWheelData() {
		string CurrentMainScene = SceneManager.GetActiveScene().name;

		// L2
		L2Button.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		L2Button.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		// L1
		L1Button.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		L1Button.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		// M
		MButton.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		MButton.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		// R1
		R1Button.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		R1Button.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		// R2
		R2Button.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		R2Button.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		// Title Text
		TitleText.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		TitleText.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0,0);

		IsButtonTurningOn = false;

		switch (CurrentMainScene) {
			case "00_Main_Globe":
				L2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Shipyard;
				L1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Helm;
				MButton.gameObject.GetComponent<Image>().sprite = WheelSprite_Globe;
				R1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Ledger;
				R2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_TradePost;

				ClickingStrings.Add(Core_Controller.Instance.Main_03);
				ClickingStrings.Add(Core_Controller.Instance.Main_01);
				ClickingStrings.Add(Core_Controller.Instance.Main_00);
				ClickingStrings.Add(Core_Controller.Instance.Main_02);
				ClickingStrings.Add(Core_Controller.Instance.Main_04);

				TitleText.text = "The Globe";

				break;
			case "01_Main_Helm":
				L2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_TradePost;
				L1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Shipyard;
				MButton.gameObject.GetComponent<Image>().sprite = WheelSprite_Helm;
				R1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Globe;
				R2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Ledger;

				ClickingStrings.Add(Core_Controller.Instance.Main_04);
				ClickingStrings.Add(Core_Controller.Instance.Main_03);
				ClickingStrings.Add(Core_Controller.Instance.Main_01);
				ClickingStrings.Add(Core_Controller.Instance.Main_00);
				ClickingStrings.Add(Core_Controller.Instance.Main_02);

				TitleText.text = "The Helm";

				break;
			case "02_Main_Ledger":
				L2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Helm;
				L1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Globe;
				MButton.gameObject.GetComponent<Image>().sprite = WheelSprite_Ledger;
				R1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_TradePost;
				R2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Shipyard;

				ClickingStrings.Add(Core_Controller.Instance.Main_01);
				ClickingStrings.Add(Core_Controller.Instance.Main_00);
				ClickingStrings.Add(Core_Controller.Instance.Main_02);
				ClickingStrings.Add(Core_Controller.Instance.Main_04);
				ClickingStrings.Add(Core_Controller.Instance.Main_03);

				TitleText.text = "The Ledger";

				break;
			case "03_Main_Shipyard":
				L2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Ledger;
				L1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_TradePost;
				MButton.gameObject.GetComponent<Image>().sprite = WheelSprite_Shipyard;
				R1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Helm;
				R2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Globe;

				ClickingStrings.Add(Core_Controller.Instance.Main_02);
				ClickingStrings.Add(Core_Controller.Instance.Main_04);
				ClickingStrings.Add(Core_Controller.Instance.Main_03);
				ClickingStrings.Add(Core_Controller.Instance.Main_01);
				ClickingStrings.Add(Core_Controller.Instance.Main_00);

				TitleText.text = "The Shipyard";

				break;
			case "04_Main_TradePost":
				L2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Globe;
				L1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Ledger;
				MButton.gameObject.GetComponent<Image>().sprite = WheelSprite_TradePost;
				R1Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Shipyard;
				R2Button.gameObject.GetComponent<Image>().sprite = WheelSprite_Helm;

				ClickingStrings.Add(Core_Controller.Instance.Main_00);
				ClickingStrings.Add(Core_Controller.Instance.Main_02);
				ClickingStrings.Add(Core_Controller.Instance.Main_04);
				ClickingStrings.Add(Core_Controller.Instance.Main_03);
				ClickingStrings.Add(Core_Controller.Instance.Main_01);

				TitleText.text = "The Trade Post";

				break;
			default:
				break;
		}

		// Start Coroutine
		StartCoroutine(AllFadeIn());
	}

// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}