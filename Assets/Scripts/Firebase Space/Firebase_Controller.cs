// Main Dependencies
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies
using CoreSpace;
using DataSpace;
using SceneSpace;

namespace FirebaseSpace {
public class Firebase_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Firebase_Controller Instance {
		get {
			return FirebaseControllerInstance;
		}
	}
	
	private static Firebase_Controller FirebaseControllerInstance = null;

	public static string FirebaseDataUrl = "https://the-ferryman-data-default-rtdb.firebaseio.com/";
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((FirebaseControllerInstance != null) && (FirebaseControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			FirebaseControllerInstance = this;
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
	#region Player Data
	#region Main Player Data
	public void DownloadMainPlayerData() {
		Debug.Log("Firebase_Controller: " + "Initializing download of main player data");

		string UserId = PlayerPrefs.GetString("TheFerryman_UserId");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Main Player Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerUserData.PlayerName = SplitJsonData[11].Trim();
				Data_Controller.Instance.PlayerUserData.PlayerEmail = SplitJsonData[3].Trim();
				Data_Controller.Instance.PlayerUserData.PlayerPassword = SplitJsonData[13].Trim();
				Data_Controller.Instance.PlayerUserData.PlayerUsername = SplitJsonData[17].Trim();
				Data_Controller.Instance.PlayerUserData.PlayerShipName = SplitJsonData[15].Trim();
				Data_Controller.Instance.PlayerUserData.PlayerLevel = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerUserData.PlayerCoinCount = System.Int32.Parse(SplitJsonData[1].Trim());
				Data_Controller.Instance.PlayerUserData.PlayerGemCount = System.Int32.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerUserData.PlayerFerriedSoulsCount = System.Int32.Parse(SplitJsonData[5].Trim());

				Data_Controller.Instance.PlayerName = Data_Controller.Instance.PlayerUserData.PlayerName;

				PlayerPrefs.SetString("TheFerryman_LoadUsername", Data_Controller.Instance.PlayerUserData.PlayerUsername);
				PlayerPrefs.SetString("TheFerryman_LoadPassword", Data_Controller.Instance.PlayerUserData.PlayerPassword);

				Debug.Log("Firebase_Controller: " + "Finished the download of main player data");
				DownloadLoginData(UserId);
			});
		}
	}

	#endregion
	#region Login Data
	public void DownloadLoginData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of login data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Login Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerUserData.SevenDayLoginNumber = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerUserData.TotalLoginTimes = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerUserData.TotalLoginDays = System.Int32.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerUserData.LastLoginDate = SplitJsonData[3].Trim();
				Data_Controller.Instance.PlayerUserData.CollectedDailyReward = bool.Parse(SplitJsonData[1].Trim());

				Debug.Log("Firebase_Controller: " + "Finished the download of login data");
				DownloadPlayerAvatarData(UserId);
			});
		}
	}

	#endregion
	#region Player Avatar Data
	public void DownloadPlayerAvatarData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of player avatar data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Player Avatar Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');				
				
				Data_Controller.Instance.PlayerUserData.AvatarHeight = System.Int32.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerUserData.AvatarWeight = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerUserData.AvatarCloakColor = System.Int32.Parse(SplitJsonData[3].Trim());
				Data_Controller.Instance.PlayerUserData.AvatarHeadAccessory = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerUserData.AvatarBodyAccessory = System.Int32.Parse(SplitJsonData[1].Trim());

				Debug.Log("Firebase_Controller: " + "Finished the download of player avatar data");
				DownloadTutorialData(UserId);
			});
		}
	}

	#endregion
	#region Tutorial Data
	public void DownloadTutorialData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of tutorial data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Tutorial Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerUserData.HasCompletedMainTutorial = bool.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedShipyardTutorial = bool.Parse(SplitJsonData[11].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedGlobeTutorial = bool.Parse(SplitJsonData[3].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedHelmTutorial = bool.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedLedgerTutorial = bool.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedTradePostTutorial = bool.Parse(SplitJsonData[13].Trim());
				Data_Controller.Instance.PlayerUserData.HasCompletedCharonsCompetitionsTutorial = bool.Parse(SplitJsonData[1].Trim());			

				Debug.Log("Firebase_Controller: " + "Finished the download of tutorial data");
				DownloadCurrentTravelData(UserId);
			});
		}
	}

	#endregion
	#region Current Travel Data
	public void DownloadCurrentTravelData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of current travel data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Current Travel Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerUserData.RiverTraveling = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerUserData.RiverTimeStarted = SplitJsonData[3].Trim();
				Data_Controller.Instance.PlayerUserData.RiverTimeAtEnd = SplitJsonData[1].Trim();

				Debug.Log("Firebase_Controller: " + "Finished the download of current travel data");
				DownloadFriendData(UserId);
			});
		}
	}

	#endregion
	#region Friend Data
	public void DownloadFriendData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of friend data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Friend" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				if (SplitJsonData.Length > 0) {
					int FriendCount = (SplitJsonData.Length + 1) / 9;

					for (int i = 0; i < FriendCount; i++) {
						Data_FriendData FriendData = new Data_FriendData();

						FriendData.FriendPlayerId = SplitJsonData[(i * 9) + 0].Trim();
						FriendData.LatestMessageSent = SplitJsonData[(i * 9) + 8].Trim();
						FriendData.LatestMessageSender = SplitJsonData[(i * 9) + 6].Trim();
						FriendData.LatestMessageReceiver = SplitJsonData[(i * 9) + 4].Trim();
						FriendData.LatestMessageHasBeenRead = bool.Parse(SplitJsonData[(i * 9) + 2].Trim());

						Data_Controller.Instance.FriendsList.Add(FriendData.FriendPlayerId, FriendData);
					}
				}

				Debug.Log("Firebase_Controller: " + "Finished the download of friend data");
				DownloadShipData(UserId);
			});
		}
	}

	#endregion
	#region Ship Data
	public void DownloadShipData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of ship data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Ship Data" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerShipData.ShipType = System.Int32.Parse(SplitJsonData[13].Trim());
				Data_Controller.Instance.PlayerShipData.MainSailColorA = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerShipData.MainSailColorB = System.Int32.Parse(SplitJsonData[11].Trim());
				Data_Controller.Instance.PlayerShipData.SubSailColor = System.Int32.Parse(SplitJsonData[15].Trim());
				Data_Controller.Instance.PlayerShipData.FigureheadPiece = System.Int32.Parse(SplitJsonData[3].Trim());
				Data_Controller.Instance.PlayerShipData.HelmWheel = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerShipData.CrewCloakColor = System.Int32.Parse(SplitJsonData[1].Trim());
				Data_Controller.Instance.PlayerShipData.HullColor = System.Int32.Parse(SplitJsonData[7].Trim());

				Debug.Log("Firebase_Controller: " + "Finished the download of ship data");
				DownloadLifetimeSoulData(UserId);
			});
		}
	}

	#endregion
	#region Lifetime Soul Data
	public void DownloadLifetimeSoulData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of lifetime soul (career field) data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Lifetime Soul Data" + "/" + "Career Field" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerEducation = System.Int32.Parse(SplitJsonData[13].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerHealthcare = System.Int32.Parse(SplitJsonData[19].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerHumanServices = System.Int32.Parse(SplitJsonData[25].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerManagement = System.Int32.Parse(SplitJsonData[29].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerTechnology = System.Int32.Parse(SplitJsonData[37].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerAutomotive = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerSales = System.Int32.Parse(SplitJsonData[35].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerArchitecture = System.Int32.Parse(SplitJsonData[1].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerCommunication = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerFinance = System.Int32.Parse(SplitJsonData[17].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerHospitality = System.Int32.Parse(SplitJsonData[21].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerHumanResources = System.Int32.Parse(SplitJsonData[23].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerBusiness = System.Int32.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerConstruction = System.Int32.Parse(SplitJsonData[11].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerEngineering = System.Int32.Parse(SplitJsonData[15].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerMedia = System.Int32.Parse(SplitJsonData[33].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerLaw = System.Int32.Parse(SplitJsonData[27].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerMarketing = System.Int32.Parse(SplitJsonData[31].Trim());
				Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountCareerArtsEntertainment = System.Int32.Parse(SplitJsonData[3].Trim());

				Debug.Log("Firebase_Controller: " + "Finished the download of lifetime soul (career field) data");
				Debug.Log("Firebase_Controller: " + "Initializing download of lifetime soul (continent lived) data");

				RestClient.Get(FirebaseDataUrl + UserId + "/" + "Lifetime Soul Data" + "/" + "Continent Lived" + ".json").Then(response => {
					string FullJsonData1 = response.Text.ToString();
					string FullJsonData2 = FullJsonData1.Replace('{',' ');
					string FullJsonData3 = FullJsonData2.Replace('}',' ');
					string FullJsonData4 = FullJsonData3.Replace('"',' ');
					string[] SplitJsonData = FullJsonData4.Split(',',':');

					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentAfrica = System.Int32.Parse(SplitJsonData[1].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentAntarctica = System.Int32.Parse(SplitJsonData[3].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentAsia = System.Int32.Parse(SplitJsonData[5].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentAustralia = System.Int32.Parse(SplitJsonData[7].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentEurope = System.Int32.Parse(SplitJsonData[9].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentNorthAmerica = System.Int32.Parse(SplitJsonData[11].Trim());
					Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountContinentSouthAmerica = System.Int32.Parse(SplitJsonData[13].Trim());

					Debug.Log("Firebase_Controller: " + "Finished the download of lifetime soul (continent lived) data");
					Debug.Log("Firebase_Controller: " + "Initializing download of lifetime soul (destination traveled) data");

					RestClient.Get(FirebaseDataUrl + UserId + "/" + "Lifetime Soul Data" + "/" + "Destination Traveled" + ".json").Then(response => {
						string FullJsonData1 = response.Text.ToString();
						string FullJsonData2 = FullJsonData1.Replace('{',' ');
						string FullJsonData3 = FullJsonData2.Replace('}',' ');
						string FullJsonData4 = FullJsonData3.Replace('"',' ');
						string[] SplitJsonData = FullJsonData4.Split(',',':');

						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationParis = System.Int32.Parse(SplitJsonData[37].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationBarcelona = System.Int32.Parse(SplitJsonData[9].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationNewYorkCity = System.Int32.Parse(SplitJsonData[35].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationRome = System.Int32.Parse(SplitJsonData[39].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationFlorence = System.Int32.Parse(SplitJsonData[21].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationTokyo = System.Int32.Parse(SplitJsonData[45].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationLondon = System.Int32.Parse(SplitJsonData[31].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationAmsterdam = System.Int32.Parse(SplitJsonData[1].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationBangkok = System.Int32.Parse(SplitJsonData[7].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationDubai = System.Int32.Parse(SplitJsonData[19].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationAthens = System.Int32.Parse(SplitJsonData[3].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationKualaLumpur = System.Int32.Parse(SplitJsonData[27].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationSydney = System.Int32.Parse(SplitJsonData[41].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationCapeTown = System.Int32.Parse(SplitJsonData[13].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationCairo = System.Int32.Parse(SplitJsonData[11].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationIstanbul = System.Int32.Parse(SplitJsonData[25].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationCartagena = System.Int32.Parse(SplitJsonData[15].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationAtlanta = System.Int32.Parse(SplitJsonData[5].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationTallinn = System.Int32.Parse(SplitJsonData[43].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationMexicoCity = System.Int32.Parse(SplitJsonData[33].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationToronto = System.Int32.Parse(SplitJsonData[47].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationCleveland = System.Int32.Parse(SplitJsonData[17].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationLasVegas = System.Int32.Parse(SplitJsonData[29].Trim());
						Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountDestinationHokkaido = System.Int32.Parse(SplitJsonData[23].Trim());

						Debug.Log("Firebase_Controller: " + "Finished the download of lifetime soul (destination traveled) data");
						Debug.Log("Firebase_Controller: " + "Initializing download of lifetime soul (eye color) data");

						RestClient.Get(FirebaseDataUrl + UserId + "/" + "Lifetime Soul Data" + "/" + "Eye Color" + ".json").Then(response => {
							string FullJsonData1 = response.Text.ToString();
							string FullJsonData2 = FullJsonData1.Replace('{',' ');
							string FullJsonData3 = FullJsonData2.Replace('}',' ');
							string FullJsonData4 = FullJsonData3.Replace('"',' ');
							string[] SplitJsonData = FullJsonData4.Split(',',':');

							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesBlue = System.Int32.Parse(SplitJsonData[1].Trim());
							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesBrown = System.Int32.Parse(SplitJsonData[3].Trim());
							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesHazel = System.Int32.Parse(SplitJsonData[9].Trim());
							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesGray = System.Int32.Parse(SplitJsonData[5].Trim());
							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesGreen = System.Int32.Parse(SplitJsonData[7].Trim());
							Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountEyesRed = System.Int32.Parse(SplitJsonData[11].Trim());

							Debug.Log("Firebase_Controller: " + "Finished the download of lifetime soul (eye color) data");
							Debug.Log("Firebase_Controller: " + "Initializing download of lifetime soul (kid number) data");

							RestClient.Get(FirebaseDataUrl + UserId + "/" + "Lifetime Soul Data" + "/" + "Kid Number" + ".json").Then(response => {
								string FullJsonData1 = response.Text.ToString();
								string FullJsonData2 = FullJsonData1.Replace('{',' ');
								string FullJsonData3 = FullJsonData2.Replace('}',' ');
								string FullJsonData4 = FullJsonData3.Replace('"',' ');
								string[] SplitJsonData = FullJsonData4.Split(',',':');

								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids0 = System.Int32.Parse(SplitJsonData[1].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids1 = System.Int32.Parse(SplitJsonData[3].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids2 = System.Int32.Parse(SplitJsonData[5].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids3 = System.Int32.Parse(SplitJsonData[7].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids4 = System.Int32.Parse(SplitJsonData[9].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids5 = System.Int32.Parse(SplitJsonData[11].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids6 = System.Int32.Parse(SplitJsonData[13].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids7 = System.Int32.Parse(SplitJsonData[15].Trim());
								Data_Controller.Instance.PlayerSoulDataLifetime.SoulCountKids8 = System.Int32.Parse(SplitJsonData[17].Trim());

								Debug.Log("Firebase_Controller: " + "Finished the download of lifetime soul (kid number) data");
								DownloadWeeklySoulData(UserId);
							});
						});
					});
				});
			});
		}
	}	
	
	#endregion
	#region Weekly Soul Data
	public void DownloadWeeklySoulData(string UserId) {
		Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (career field) data");

		if ((UserId != null) && (UserId != "")) {
			RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "Career Field" + ".json").Then(response => {
				string FullJsonData1 = response.Text.ToString();
				string FullJsonData2 = FullJsonData1.Replace('{',' ');
				string FullJsonData3 = FullJsonData2.Replace('}',' ');
				string FullJsonData4 = FullJsonData3.Replace('"',' ');
				string[] SplitJsonData = FullJsonData4.Split(',',':');

				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerEducation = System.Int32.Parse(SplitJsonData[13].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerHealthcare = System.Int32.Parse(SplitJsonData[19].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerHumanServices = System.Int32.Parse(SplitJsonData[25].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerManagement = System.Int32.Parse(SplitJsonData[29].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerTechnology = System.Int32.Parse(SplitJsonData[37].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerAutomotive = System.Int32.Parse(SplitJsonData[5].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerSales = System.Int32.Parse(SplitJsonData[35].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerArchitecture = System.Int32.Parse(SplitJsonData[1].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerCommunication = System.Int32.Parse(SplitJsonData[9].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerFinance = System.Int32.Parse(SplitJsonData[17].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerHospitality = System.Int32.Parse(SplitJsonData[21].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerHumanResources = System.Int32.Parse(SplitJsonData[23].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerBusiness = System.Int32.Parse(SplitJsonData[7].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerConstruction = System.Int32.Parse(SplitJsonData[11].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerEngineering = System.Int32.Parse(SplitJsonData[15].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerMedia = System.Int32.Parse(SplitJsonData[33].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerLaw = System.Int32.Parse(SplitJsonData[27].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerMarketing = System.Int32.Parse(SplitJsonData[31].Trim());
				Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountCareerArtsEntertainment = System.Int32.Parse(SplitJsonData[3].Trim());

				Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (career field) data");
				Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (continent lived) data");

				RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "Continent Lived" + ".json").Then(response => {
					string FullJsonData1 = response.Text.ToString();
					string FullJsonData2 = FullJsonData1.Replace('{',' ');
					string FullJsonData3 = FullJsonData2.Replace('}',' ');
					string FullJsonData4 = FullJsonData3.Replace('"',' ');
					string[] SplitJsonData = FullJsonData4.Split(',',':');

					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentAfrica = System.Int32.Parse(SplitJsonData[1].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentAntarctica = System.Int32.Parse(SplitJsonData[3].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentAsia = System.Int32.Parse(SplitJsonData[5].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentAustralia = System.Int32.Parse(SplitJsonData[7].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentEurope = System.Int32.Parse(SplitJsonData[9].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentNorthAmerica = System.Int32.Parse(SplitJsonData[11].Trim());
					Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountContinentSouthAmerica = System.Int32.Parse(SplitJsonData[13].Trim());

					Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (continent lived) data");
					Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (destination traveled) data");

					RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "Destination Traveled" + ".json").Then(response => {
						string FullJsonData1 = response.Text.ToString();
						string FullJsonData2 = FullJsonData1.Replace('{',' ');
						string FullJsonData3 = FullJsonData2.Replace('}',' ');
						string FullJsonData4 = FullJsonData3.Replace('"',' ');
						string[] SplitJsonData = FullJsonData4.Split(',',':');

						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationParis = System.Int32.Parse(SplitJsonData[37].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationBarcelona = System.Int32.Parse(SplitJsonData[9].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationNewYorkCity = System.Int32.Parse(SplitJsonData[35].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationRome = System.Int32.Parse(SplitJsonData[39].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationFlorence = System.Int32.Parse(SplitJsonData[21].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationTokyo = System.Int32.Parse(SplitJsonData[45].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationLondon = System.Int32.Parse(SplitJsonData[31].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationAmsterdam = System.Int32.Parse(SplitJsonData[1].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationBangkok = System.Int32.Parse(SplitJsonData[7].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationDubai = System.Int32.Parse(SplitJsonData[19].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationAthens = System.Int32.Parse(SplitJsonData[3].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationKualaLumpur = System.Int32.Parse(SplitJsonData[27].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationSydney = System.Int32.Parse(SplitJsonData[41].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationCapeTown = System.Int32.Parse(SplitJsonData[13].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationCairo = System.Int32.Parse(SplitJsonData[11].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationIstanbul = System.Int32.Parse(SplitJsonData[25].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationCartagena = System.Int32.Parse(SplitJsonData[15].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationAtlanta = System.Int32.Parse(SplitJsonData[5].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationTallinn = System.Int32.Parse(SplitJsonData[43].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationMexicoCity = System.Int32.Parse(SplitJsonData[33].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationToronto = System.Int32.Parse(SplitJsonData[47].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationCleveland = System.Int32.Parse(SplitJsonData[17].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationLasVegas = System.Int32.Parse(SplitJsonData[29].Trim());
						Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountDestinationHokkaido = System.Int32.Parse(SplitJsonData[23].Trim());

						Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (destination traveled) data");
						Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (eye color) data");

						RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "Eye Color" + ".json").Then(response => {
							string FullJsonData1 = response.Text.ToString();
							string FullJsonData2 = FullJsonData1.Replace('{',' ');
							string FullJsonData3 = FullJsonData2.Replace('}',' ');
							string FullJsonData4 = FullJsonData3.Replace('"',' ');
							string[] SplitJsonData = FullJsonData4.Split(',',':');

							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesBlue = System.Int32.Parse(SplitJsonData[1].Trim());
							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesBrown = System.Int32.Parse(SplitJsonData[3].Trim());
							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesHazel = System.Int32.Parse(SplitJsonData[9].Trim());
							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesGray = System.Int32.Parse(SplitJsonData[5].Trim());
							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesGreen = System.Int32.Parse(SplitJsonData[7].Trim());
							Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountEyesRed = System.Int32.Parse(SplitJsonData[11].Trim());

							Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (eye color) data");
							Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (kid number) data");

							RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "Kid Number" + ".json").Then(response => {
								string FullJsonData1 = response.Text.ToString();
								string FullJsonData2 = FullJsonData1.Replace('{',' ');
								string FullJsonData3 = FullJsonData2.Replace('}',' ');
								string FullJsonData4 = FullJsonData3.Replace('"',' ');
								string[] SplitJsonData = FullJsonData4.Split(',',':');

								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids0 = System.Int32.Parse(SplitJsonData[1].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids1 = System.Int32.Parse(SplitJsonData[3].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids2 = System.Int32.Parse(SplitJsonData[5].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids3 = System.Int32.Parse(SplitJsonData[7].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids4 = System.Int32.Parse(SplitJsonData[9].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids5 = System.Int32.Parse(SplitJsonData[11].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids6 = System.Int32.Parse(SplitJsonData[13].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids7 = System.Int32.Parse(SplitJsonData[15].Trim());
								Data_Controller.Instance.PlayerSoulDataWeekly.SoulCountKids8 = System.Int32.Parse(SplitJsonData[17].Trim());

								Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (kid number) data");
								Debug.Log("Firebase_Controller: " + "Initializing download of weekly competition (general) data");

								RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "General" + ".json").Then(response => {
									string FullJsonData1 = response.Text.ToString();
									string FullJsonData2 = FullJsonData1.Replace('{',' ');
									string FullJsonData3 = FullJsonData2.Replace('}',' ');
									string FullJsonData4 = FullJsonData3.Replace('"',' ');
									string[] SplitJsonData = FullJsonData4.Split(',',':');

									Data_Controller.Instance.PlayerSoulDataWeekly.RiversTraveledCount = System.Int32.Parse(SplitJsonData[5].Trim());
									Data_Controller.Instance.PlayerSoulDataWeekly.CoinsCollectedCount = System.Int32.Parse(SplitJsonData[1].Trim());
									Data_Controller.Instance.PlayerSoulDataWeekly.GemsCollectedCount = System.Int32.Parse(SplitJsonData[3].Trim());
									Data_Controller.Instance.PlayerSoulDataWeekly.SoulsFerriedCount = System.Int32.Parse(SplitJsonData[7].Trim());

									Debug.Log("Firebase_Controller: " + "Finished the download of weekly competition (general) data");
									Debug.Log("Firebase_Controller: " + "Initializing download of the rest of weekly competition data");

									RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "EarnsPlacementReward" + ".json").Then(response => {
										string SingleResponse = response.Text.ToString();

										Data_Controller.Instance.PlayerSoulDataWeekly.EarnsPlacementReward = bool.Parse(SingleResponse.Trim());
									});

									RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "HasCollectedLastWeekReward" + ".json").Then(response => {
										string SingleResponse = response.Text.ToString();

										Data_Controller.Instance.PlayerSoulDataWeekly.HasCollectedLastWeekReward = bool.Parse(SingleResponse.Trim());
									});

									RestClient.Get(FirebaseDataUrl + UserId + "/" + "Weekly Competition Data" + "/" + "PlacementLastWeek" + ".json").Then(response => {
										string SingleResponse = response.Text.ToString();

										Data_Controller.Instance.PlayerSoulDataWeekly.PlacementLastWeek = System.Int32.Parse(SingleResponse.Trim());
									});

									Debug.Log("Firebase_Controller: " + "Finished the download of the rest of weekly competition data");
									Debug.Log("Scene_Entry_LogInSignUp: " + "Change scenes to 00_Main_Globe");
									SceneManager.LoadScene(Core_Controller.Instance.Main_00);
								});
							});
						});
					});
				});
			});
		}
	}

	#endregion
	#endregion
	#region Player Log In
	public void PlayerLogInAttempt(string PlayerUsername, string PlayerPassword) {
		Debug.Log("Firebase_Controller: " + "Initializing download of player username and password check");

		RestClient.Get(FirebaseDataUrl + ".json").Then(response => {
			string FullJsonData1 = response.Text.ToString();
			string FullJsonData2 = FullJsonData1.Replace('{',' ');
			string FullJsonData3 = FullJsonData2.Replace('}',' ');
			string FullJsonData4 = FullJsonData3.Replace('"',' ');
			string[] SplitJsonData = FullJsonData4.Split(',',':');

			bool WasUsernameFound = false;

			for (int i = 0; i < SplitJsonData.Length; i++) {
				if (SplitJsonData[i].Trim() == PlayerUsername) {
					if (SplitJsonData[i-1].Trim() == "PlayerUsername") {
						Debug.Log("Firebase_Controller: " + "Successfully found player's username: " + PlayerUsername);
						WasUsernameFound = true;
						CheckPassword(PlayerPassword, SplitJsonData);
					}
				}
			}

			if (!WasUsernameFound) {
				Debug.Log("Firebase_Controller: " + "Could not find the player's username");
				Scene_Controller.Instance.UnsuccessfulLogIn();
			}
		});
	}

	private void CheckPassword(string PlayerPassword, string[] SplitJsonData) {
		bool WasPasswordFound = false;

		for (int j = 0; j < SplitJsonData.Length; j++) {
			if (SplitJsonData[j].Trim() == PlayerPassword) {
				if (SplitJsonData[j-1].Trim() == "PlayerPassword") {
					Debug.Log("Firebase_Controller: " + "Finished the download of player username and password check");
					WasPasswordFound = true;
					Scene_Controller.Instance.SuccessfulLogIn();
				}
			}
		}

		if (!WasPasswordFound) {
			Debug.Log("Firebase_Controller: " + "Could not find the player's password");
			Scene_Controller.Instance.UnsuccessfulLogIn();
		}
	}

	#endregion
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}