// Main Dependencies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Game Dependencies
using DataSpace;

namespace ConstantSpace {
public class Constant_Controller : MonoBehaviour {
		
// ---------------------------------------- START: LIST OF VARIABLES ----------------------------------------
// --------------- PUBLIC & SERIALIZED VARIABLES ---------------
	// Game Variables
	public const float FadingTime = 1.5f;
	public const float RotationSpeed = 0.35f;
	public const float ShiftingSpeed = 0.3f;
	public const float WheelTurnSpeed = 0.1f;
	public const float TransitionSpeed = 5.0f;

	// Game Sections
	public const string MainGameSection = "MainGame";
	public const string ShipyardSection = "Shipyard";
	public const string GlobeSection = "Globe";
	public const string HelmSection = "Helm";
	public const string LedgerSection = "Ledger";
	public const string TradePostSection = "TradePost";
	public const string CharonsCompetitionsSection = "CharonsCompetitions";

	// Game Characters
	public const string DakotaName = "Dakota";
	public const string CharonName = "Charon";
	public const string UserName = "You";

	// Unusable Ship Name List
	public List<string> UnusableShipNames = new();

	// Bad Word List
	public List<string> BadWords = new();

	// Ship Types
	public enum ShipTypes {
		Catboat = 0,
		Schuyt = 1,
		Dhow = 2,
		Sloop = 3,
		Ketch = 4,
		Brigantine = 5,
		Caravel = 6,
		Carrack = 7,
		Galley = 8,
		Barque = 9,
		Galleon = 10,
		Frigate = 11,
		ManOWar = 12,
		ShipOfTheLine = 13
	}

	// Player Levels
	public enum PlayerLevels {
		Level1 = 0,
		Level2 = 1,
		Level3 = 2,
		Level4 = 3,
		Level5 = 4,
		Level6 = 5,
		Level7 = 6,
		Level8 = 7,
		Level9 = 8,
		Level10 = 9,
		Level11 = 10,
		Level12 = 11,
		Level13 = 12,
		Level14 = 13,
		Level15 = 14,
		Lieutenant = 15,
		Captain = 16,
		Admiral = 17,
		Master = 18
	}

	// Soul Experiences - Eye Color
	public List<string> SoulExperienceEyeColor = new();

	// Soul Experiences - Continents Lived
	public List<string> SoulExperienceContinents = new();

	// Soul Experiences - Number of Kids
	public List<string> SoulExperienceKidsCount = new();

	// Soul Experiences - Career Fields
	public List<string> SoulExperienceCareerFields = new();

	// Soul Experiences - Favorite Destinations
	public List<string> SoulExperienceDestinations = new();

	// Friend Messages
	public List<string> FriendMessages = new();

	// Rivers
	public List<Data_RiverData> Rivers = new();

	// Dialogue Pieces
	public Dictionary<(string Section, int Order), (string Speaker, string Message)> DialogueDict = new();
	
// --------------- PRIVATE VARIABLES ---------------
	
	
// --------------- STATIC VARIABLES ---------------
	public static Constant_Controller Instance {
		get {
			return ConstantControllerInstance;
		}
	}
	
	private static Constant_Controller ConstantControllerInstance = null;
	
// ---------------------------------------- END: LIST OF VARIABLES ----------------------------------------
// ---------------------------------------- START: CALLING OTHER SCRIPTS ----------------------------------------
	
	
// ---------------------------------------- END: CALLING OTHER SCRIPTS ----------------------------------------
// ---------------------------------------- START: INITIAL FUNCTIONS ----------------------------------------
// --------------- START FUNCTION ---------------
	void Start() {
		
	}
	
// --------------- AWAKE FUNCTION ---------------
	void Awake() {
		if ((ConstantControllerInstance != null) && (ConstantControllerInstance != this)) {
			Destroy(this.gameObject);
			return;
		}
		
		else {
			ConstantControllerInstance = this;
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
	public void SetAllConstantDataPieces() {
		SetUnusableShipsList();
		SetBadWordsList();
		SetFriendMessagesList();
		SetRiversList();
		SetSoulExperiences();
		SetDialoguePieces();
	}

	private void SetUnusableShipsList() {
		Debug.Log("Constant_Controller: " + "Setting list of unusable ship names");

		UnusableShipNames.Add("Queen Anne’s Revenge");
		UnusableShipNames.Add("Queen Annes Revenge");
		UnusableShipNames.Add("Queen Anne Revenge");
		UnusableShipNames.Add("Titanic");
		UnusableShipNames.Add("Bismarck");
		UnusableShipNames.Add("Santa Maria");
		UnusableShipNames.Add("Niña");
		UnusableShipNames.Add("Nina");
		UnusableShipNames.Add("Pinta");
		UnusableShipNames.Add("Mayflower");
		UnusableShipNames.Add("Beagle");
		UnusableShipNames.Add("Enterprise");
		UnusableShipNames.Add("Royal Fortune");
		UnusableShipNames.Add("Revenge");
		UnusableShipNames.Add("Whydah");
		UnusableShipNames.Add("Adventure Galley");
		UnusableShipNames.Add("Golden Hind");
		UnusableShipNames.Add("Black Pearl");
		UnusableShipNames.Add("Flying Dutchman");
		UnusableShipNames.Add("Burning Dragon");
		UnusableShipNames.Add("Satisfaction");
		UnusableShipNames.Add("Quedagh Merchant");

		Data_Controller.Instance.LoadingAmount += 10.0f;
	}

	private void SetBadWordsList() {
		Debug.Log("Constant_Controller: " + "Setting list of bad words");

		BadWords.Add("2g1c");
		BadWords.Add("2 girls 1 cup");
		BadWords.Add("acrotomophilia");
		BadWords.Add("alabama hot pocket");
		BadWords.Add("alaskan pipeline");
		BadWords.Add("anal");
		BadWords.Add("anilingus");
		BadWords.Add("anus");
		BadWords.Add("apeshit");
		BadWords.Add("arsehole");
		BadWords.Add("ass");
		BadWords.Add("asshole");
		BadWords.Add("assmunch");
		BadWords.Add("auto erotic");
		BadWords.Add("autoerotic");
		BadWords.Add("babeland");
		BadWords.Add("baby batter");
		BadWords.Add("baby juice");
		BadWords.Add("ball gag");
		BadWords.Add("ball gravy");
		BadWords.Add("ball kicking");
		BadWords.Add("ball licking");
		BadWords.Add("ball sack");
		BadWords.Add("ball sucking");
		BadWords.Add("bangbros");
		BadWords.Add("bangbus");
		BadWords.Add("bareback");
		BadWords.Add("barely legal");
		BadWords.Add("barenaked");
		BadWords.Add("bastard");
		BadWords.Add("bastardo");
		BadWords.Add("bastinado");
		BadWords.Add("bbw");
		BadWords.Add("bdsm");
		BadWords.Add("beaner");
		BadWords.Add("beaners");
		BadWords.Add("beaver cleaver");
		BadWords.Add("beaver lips");
		BadWords.Add("beastiality");
		BadWords.Add("bestiality");
		BadWords.Add("big black");
		BadWords.Add("big breasts");
		BadWords.Add("big knockers");
		BadWords.Add("big tits");
		BadWords.Add("bimbos");
		BadWords.Add("birdlock");
		BadWords.Add("bitch");
		BadWords.Add("bitches");
		BadWords.Add("black cock");
		BadWords.Add("blonde action");
		BadWords.Add("blonde on blonde action");
		BadWords.Add("blowjob");
		BadWords.Add("blow job");
		BadWords.Add("blow your load");
		BadWords.Add("blue waffle");
		BadWords.Add("blumpkin");
		BadWords.Add("bollocks");
		BadWords.Add("bondage");
		BadWords.Add("boner");
		BadWords.Add("boob");
		BadWords.Add("boobs");
		BadWords.Add("booty call");
		BadWords.Add("brown showers");
		BadWords.Add("brunette action");
		BadWords.Add("bukkake");
		BadWords.Add("bulldyke");
		BadWords.Add("bullet vibe");
		BadWords.Add("bullshit");
		BadWords.Add("bung hole");
		BadWords.Add("bunghole");
		BadWords.Add("busty");
		BadWords.Add("butt");
		BadWords.Add("buttcheeks");
		BadWords.Add("butthole");
		BadWords.Add("camel toe");
		BadWords.Add("camgirl");
		BadWords.Add("camslut");
		BadWords.Add("camwhore");
		BadWords.Add("carpet muncher");
		BadWords.Add("carpetmuncher");
		BadWords.Add("chocolate rosebuds");
		BadWords.Add("cialis");
		BadWords.Add("circlejerk");
		BadWords.Add("cleveland steamer");
		BadWords.Add("clit");
		BadWords.Add("clitoris");
		BadWords.Add("clover clamps");
		BadWords.Add("clusterfuck");
		BadWords.Add("cock");
		BadWords.Add("cocks");
		BadWords.Add("coprolagnia");
		BadWords.Add("coprophilia");
		BadWords.Add("cornhole");
		BadWords.Add("coon");
		BadWords.Add("coons");
		BadWords.Add("creampie");
		BadWords.Add("cum");
		BadWords.Add("cumming");
		BadWords.Add("cumshot");
		BadWords.Add("cumshots");
		BadWords.Add("cunnilingus");
		BadWords.Add("cunt");
		BadWords.Add("darkie");
		BadWords.Add("date rape");
		BadWords.Add("daterape");
		BadWords.Add("deep throat");
		BadWords.Add("deepthroat");
		BadWords.Add("dendrophilia");
		BadWords.Add("dick");
		BadWords.Add("dildo");
		BadWords.Add("dingleberry");
		BadWords.Add("dingleberries");
		BadWords.Add("dirty pillows");
		BadWords.Add("dirty sanchez");
		BadWords.Add("doggie style");
		BadWords.Add("doggiestyle");
		BadWords.Add("doggy style");
		BadWords.Add("doggystyle");
		BadWords.Add("dog style");
		BadWords.Add("dolcett");
		BadWords.Add("domination");
		BadWords.Add("dominatrix");
		BadWords.Add("dommes");
		BadWords.Add("donkey punch");
		BadWords.Add("double dong");
		BadWords.Add("double penetration");
		BadWords.Add("dp action");
		BadWords.Add("dry hump");
		BadWords.Add("dvda");
		BadWords.Add("eat my ass");
		BadWords.Add("ecchi");
		BadWords.Add("ejaculation");
		BadWords.Add("erotic");
		BadWords.Add("erotism");
		BadWords.Add("escort");
		BadWords.Add("eunuch");
		BadWords.Add("fag");
		BadWords.Add("faggot");
		BadWords.Add("fecal");
		BadWords.Add("felch");
		BadWords.Add("fellatio");
		BadWords.Add("feltch");
		BadWords.Add("female squirting");
		BadWords.Add("femdom");
		BadWords.Add("figging");
		BadWords.Add("fingerbang");
		BadWords.Add("fingering");
		BadWords.Add("fisting");
		BadWords.Add("foot fetish");
		BadWords.Add("footjob");
		BadWords.Add("frotting");
		BadWords.Add("fuck");
		BadWords.Add("fuck buttons");
		BadWords.Add("fuckin");
		BadWords.Add("fucking");
		BadWords.Add("fucktards");
		BadWords.Add("fudge packer");
		BadWords.Add("fudgepacker");
		BadWords.Add("futanari");
		BadWords.Add("gangbang");
		BadWords.Add("gang bang");
		BadWords.Add("gay sex");
		BadWords.Add("genitals");
		BadWords.Add("giant cock");
		BadWords.Add("girl on");
		BadWords.Add("girl on top");
		BadWords.Add("girls gone wild");
		BadWords.Add("goatcx");
		BadWords.Add("goatse");
		BadWords.Add("god damn");
		BadWords.Add("gokkun");
		BadWords.Add("golden shower");
		BadWords.Add("goodpoop");
		BadWords.Add("goo girl");
		BadWords.Add("goregasm");
		BadWords.Add("grope");
		BadWords.Add("group sex");
		BadWords.Add("g-spot");
		BadWords.Add("guro");
		BadWords.Add("hand job");
		BadWords.Add("handjob");
		BadWords.Add("hard core");
		BadWords.Add("hardcore");
		BadWords.Add("hentai");
		BadWords.Add("homoerotic");
		BadWords.Add("honkey");
		BadWords.Add("hooker");
		BadWords.Add("horny");
		BadWords.Add("hot carl");
		BadWords.Add("hot chick");
		BadWords.Add("how to kill");
		BadWords.Add("how to murder");
		BadWords.Add("huge fat");
		BadWords.Add("humping");
		BadWords.Add("incest");
		BadWords.Add("intercourse");
		BadWords.Add("jack off");
		BadWords.Add("jail bait");
		BadWords.Add("jailbait");
		BadWords.Add("jelly donut");
		BadWords.Add("jerk off");
		BadWords.Add("jigaboo");
		BadWords.Add("jiggaboo");
		BadWords.Add("jiggerboo");
		BadWords.Add("jizz");
		BadWords.Add("juggs");
		BadWords.Add("kike");
		BadWords.Add("kinbaku");
		BadWords.Add("kinkster");
		BadWords.Add("kinky");
		BadWords.Add("knobbing");
		BadWords.Add("leather restraint");
		BadWords.Add("leather straight jacket");
		BadWords.Add("lemon party");
		BadWords.Add("livesex");
		BadWords.Add("lolita");
		BadWords.Add("lovemaking");
		BadWords.Add("make me come");
		BadWords.Add("male squirting");
		BadWords.Add("masturbate");
		BadWords.Add("masturbating");
		BadWords.Add("masturbation");
		BadWords.Add("menage a trois");
		BadWords.Add("milf");
		BadWords.Add("missionary position");
		BadWords.Add("mong");
		BadWords.Add("motherfucker");
		BadWords.Add("mound of venus");
		BadWords.Add("mr hands");
		BadWords.Add("muff diver");
		BadWords.Add("muffdiving");
		BadWords.Add("nambla");
		BadWords.Add("nawashi");
		BadWords.Add("negro");
		BadWords.Add("neonazi");
		BadWords.Add("nigga");
		BadWords.Add("nigger");
		BadWords.Add("nig nog");
		BadWords.Add("nimphomania");
		BadWords.Add("nipple");
		BadWords.Add("nipples");
		BadWords.Add("nsfw");
		BadWords.Add("nsfw images");
		BadWords.Add("nude");
		BadWords.Add("nudity");
		BadWords.Add("nutten");
		BadWords.Add("nympho");
		BadWords.Add("nymphomania");
		BadWords.Add("octopussy");
		BadWords.Add("omorashi");
		BadWords.Add("one cup two girls");
		BadWords.Add("one guy one jar");
		BadWords.Add("orgasm");
		BadWords.Add("orgy");
		BadWords.Add("paedophile");
		BadWords.Add("paki");
		BadWords.Add("panties");
		BadWords.Add("panty");
		BadWords.Add("pedobear");
		BadWords.Add("pedophile");
		BadWords.Add("pegging");
		BadWords.Add("penis");
		BadWords.Add("phone sex");
		BadWords.Add("piece of shit");
		BadWords.Add("pikey");
		BadWords.Add("pissing");
		BadWords.Add("piss pig");
		BadWords.Add("pisspig");
		BadWords.Add("playboy");
		BadWords.Add("pleasure chest");
		BadWords.Add("pole smoker");
		BadWords.Add("ponyplay");
		BadWords.Add("poof");
		BadWords.Add("poon");
		BadWords.Add("poontang");
		BadWords.Add("punany");
		BadWords.Add("poop chute");
		BadWords.Add("poopchute");
		BadWords.Add("porn");
		BadWords.Add("porno");
		BadWords.Add("pornography");
		BadWords.Add("prince albert piercing");
		BadWords.Add("pthc");
		BadWords.Add("pubes");
		BadWords.Add("pussy");
		BadWords.Add("queaf");
		BadWords.Add("queef");
		BadWords.Add("quim");
		BadWords.Add("raghead");
		BadWords.Add("raging boner");
		BadWords.Add("rape");
		BadWords.Add("raping");
		BadWords.Add("rapist");
		BadWords.Add("rectum");
		BadWords.Add("reverse cowgirl");
		BadWords.Add("rimjob");
		BadWords.Add("rimming");
		BadWords.Add("rosy palm");
		BadWords.Add("rosy palm and her 5 sisters");
		BadWords.Add("rusty trombone");
		BadWords.Add("sadism");
		BadWords.Add("santorum");
		BadWords.Add("scat");
		BadWords.Add("schlong");
		BadWords.Add("scissoring");
		BadWords.Add("semen");
		BadWords.Add("sex");
		BadWords.Add("sexcam");
		BadWords.Add("sexo");
		BadWords.Add("sexy");
		BadWords.Add("sexual");
		BadWords.Add("sexually");
		BadWords.Add("sexuality");
		BadWords.Add("shaved beaver");
		BadWords.Add("shaved pussy");
		BadWords.Add("shemale");
		BadWords.Add("shibari");
		BadWords.Add("shit");
		BadWords.Add("shitblimp");
		BadWords.Add("shitty");
		BadWords.Add("shota");
		BadWords.Add("shrimping");
		BadWords.Add("skeet");
		BadWords.Add("slanteye");
		BadWords.Add("slut");
		BadWords.Add("s&m");
		BadWords.Add("smut");
		BadWords.Add("snatch");
		BadWords.Add("snowballing");
		BadWords.Add("sodomize");
		BadWords.Add("sodomy");
		BadWords.Add("spastic");
		BadWords.Add("spic");
		BadWords.Add("splooge");
		BadWords.Add("splooge moose");
		BadWords.Add("spooge");
		BadWords.Add("spread legs");
		BadWords.Add("spunk");
		BadWords.Add("strap on");
		BadWords.Add("strapon");
		BadWords.Add("strappado");
		BadWords.Add("strip club");
		BadWords.Add("style doggy");
		BadWords.Add("suck");
		BadWords.Add("sucks");
		BadWords.Add("suicide girls");
		BadWords.Add("sultry women");
		BadWords.Add("swastika");
		BadWords.Add("swinger");
		BadWords.Add("tainted love");
		BadWords.Add("taste my");
		BadWords.Add("tea bagging");
		BadWords.Add("threesome");
		BadWords.Add("throating");
		BadWords.Add("thumbzilla");
		BadWords.Add("tied up");
		BadWords.Add("tight white");
		BadWords.Add("tit");
		BadWords.Add("tits");
		BadWords.Add("titties");
		BadWords.Add("titty");
		BadWords.Add("tongue in a");
		BadWords.Add("topless");
		BadWords.Add("tosser");
		BadWords.Add("towelhead");
		BadWords.Add("tranny");
		BadWords.Add("tribadism");
		BadWords.Add("tub girl");
		BadWords.Add("tubgirl");
		BadWords.Add("tushy");
		BadWords.Add("twat");
		BadWords.Add("twink");
		BadWords.Add("twinkie");
		BadWords.Add("two girls one cup");
		BadWords.Add("undressing");
		BadWords.Add("upskirt");
		BadWords.Add("urethra play");
		BadWords.Add("urophilia");
		BadWords.Add("vagina");
		BadWords.Add("venus mound");
		BadWords.Add("viagra");
		BadWords.Add("vibrator");
		BadWords.Add("violet wand");
		BadWords.Add("vorarephilia");
		BadWords.Add("voyeur");
		BadWords.Add("voyeurweb");
		BadWords.Add("voyuer");
		BadWords.Add("vulva");
		BadWords.Add("wank");
		BadWords.Add("wetback");
		BadWords.Add("wet dream");
		BadWords.Add("white power");
		BadWords.Add("whore");
		BadWords.Add("worldsex");
		BadWords.Add("wrapping men");
		BadWords.Add("wrinkled starfish");
		BadWords.Add("xx");
		BadWords.Add("xxx");
		BadWords.Add("yaoi");
		BadWords.Add("yellow showers");
		BadWords.Add("yiffy");
		BadWords.Add("zoophilia");
		BadWords.Add("🖕");

		Data_Controller.Instance.LoadingAmount += 18.0f;
	}

	private void SetFriendMessagesList() {
		Debug.Log("Constant_Controller: " + "Setting list of friend messages");

		FriendMessages.Add("Good day, friend!");
		FriendMessages.Add("Hope you are doing well!");
		FriendMessages.Add("Want to trade ships?");
		FriendMessages.Add("Oh well, maybe next time!");
		FriendMessages.Add("Thank you for the trade!");
		FriendMessages.Add("I would like to be friends!");
		FriendMessages.Add("Good luck on Charon’s Competition!");
		FriendMessages.Add("Ahoy, fellow ferryman!");
		FriendMessages.Add("See you down river!");

		Data_Controller.Instance.LoadingAmount += 18.0f;
	}

	private void SetRiversList() {
		Debug.Log("Constant_Controller: " + "Setting list of rivers and river data");

		List<(string name, string location, int duration, int minSouls, int maxSouls, int level)> RiverData = new();

		RiverData.Add(("Rhine", "Germany, France, Switzerland, Austria, Italy", 2, 2, 4, 0));
		RiverData.Add(("Warburton", "Australia", 3, 2, 8, 0));
		RiverData.Add(("Ili", "China", 3, 2, 8, 0));
		RiverData.Add(("Benue", "Nigeria, Cameroon", 3, 2, 8, 0));
		RiverData.Add(("Dniester", "Ukraine", 5, 2, 12, 0));
		RiverData.Add(("Marañón", "Peru", 7, 2, 15, 0));
		RiverData.Add(("Cooper", "Australia", 10, 15, 30, 1));
		RiverData.Add(("Belaya", "Russia", 10, 15, 30, 1));
		RiverData.Add(("Guapay", "Bolivia", 15, 15, 45, 1));
		RiverData.Add(("Colorado", "United States", 20, 15, 60, 1));
		RiverData.Add(("Godavari", "India", 30, 15, 90, 1));
		RiverData.Add(("Yenisei", "Russia, Mongolia", 30, 15, 90, 1));
		RiverData.Add(("Pecos", "United States", 45, 90, 120, 2));
		RiverData.Add(("Oka", "Russia", 60, 90, 140, 2));
		RiverData.Add(("Lomami", "Democratic Republic of the Congo", 60, 90, 140, 2));
		RiverData.Add(("Han", "China", 75, 90, 160, 2));
		RiverData.Add(("Magdalena", "Colombia", 90, 90, 180, 2));
		RiverData.Add(("Içá", "Brazil, Peru, Colombia", 105, 90, 200, 2));
		RiverData.Add(("Jubba", "Ethiopia, Somalia", 120, 200, 220, 3));
		RiverData.Add(("Tobol", "Kazakhstan, Russia", 135, 200, 235, 3));
		RiverData.Add(("Platte", "United States", 150, 200, 255, 3));
		RiverData.Add(("Beni", "Bolivia", 165, 200, 280, 3));
		RiverData.Add(("Volta", "Ghana, Burkina Faso, Togo", 180, 280, 300, 4));
		RiverData.Add(("Okavango", "Namibia, Angola, Botswana", 180, 280, 300, 4));
		RiverData.Add(("Khatanga", "Russia", 180, 280, 300, 4));
		RiverData.Add(("Churchill", "Canada", 180, 280, 300, 4));
		RiverData.Add(("Blue Nile", "Ethiopia, Sudan", 180, 280, 300, 4));
		RiverData.Add(("Uruguay", "Uruguay, Argentina, Brazil", 195, 280, 330, 4));
		RiverData.Add(("Senegal", "Senegal, Mali, Mauritania", 210, 280, 355, 4));
		RiverData.Add(("Snake", "United States", 225, 280, 370, 4));
		RiverData.Add(("Limpopo", "Mozambique, Zimbabwe, South Africa", 240, 370, 425, 5));
		RiverData.Add(("Tigris", "Turkey, Iraq, Syria, Iran", 255, 370, 440, 5));
		RiverData.Add(("Orinoco", "Venezuela, Colombia", 270, 370, 465, 5));
		RiverData.Add(("Red", "United States", 285, 370, 485, 5));
		RiverData.Add(("Pearl", "China", 300, 370, 510, 5));
		RiverData.Add(("Columbia", "United States, Canada", 315, 370, 535, 5));
		RiverData.Add(("Aldan", "Russia", 330, 370, 560, 5));
		RiverData.Add(("Arkansas", "United States", 345, 370, 590, 5));
		RiverData.Add(("Ural", "Russia, Kazakhstan", 360, 590, 640, 6));
		RiverData.Add(("Ganges", "India, Bangladesh", 360, 590, 640, 6));
		RiverData.Add(("Paraguay", "Brazil, Paraguay, Bolivia, Argentina", 390, 590, 680, 6));
		RiverData.Add(("Nelson", "Canada, United States", 390, 590, 680, 6));
		RiverData.Add(("Japurá", "Brazil, Colombia", 420, 590, 730, 6));
		RiverData.Add(("Araguaia", "Brazil", 420, 590, 730, 6));
		RiverData.Add(("Zambezi", "Zambia, Angola, Zimbabwe, Mozambique", 450, 590, 775, 6));
		RiverData.Add(("Tocantins", "Brazil", 450, 590, 775, 6));
		RiverData.Add(("Danube", "Romania, Hungary, Austria, Serbia", 480, 775, 850, 7));
		RiverData.Add(("Brahmaputra", "India, China, Nepal", 480, 775, 850, 7));
		RiverData.Add(("Tunguska", "Russia", 510, 775, 900, 7));
		RiverData.Add(("Rio Grande", "United States, Mexico", 510, 775, 900, 7));
		RiverData.Add(("Saint Lawrence", "Canada, United States", 540, 775, 940, 7));
		RiverData.Add(("Salween", "China, Myanmar, Thailand", 540, 775, 940, 7));
		RiverData.Add(("Syr Darya", "Kazakhstan, Kyrgyzstan, Uzbekistan", 540, 775, 940, 7));
		RiverData.Add(("São Francisco", "Brazil", 540, 775, 940, 7));
		RiverData.Add(("Indus", "Pakistan, China, India", 570, 775, 1000, 7));
		RiverData.Add(("Yukon", "United States, Canada", 570, 775, 1000, 7));
		RiverData.Add(("Madeira", "Brazil, Bolivia, Peru", 570, 775, 1000, 7));
		RiverData.Add(("Murray", "Australia", 570, 775, 1000, 7));
		RiverData.Add(("Purus", "Brazil, Peru", 600, 1000, 1700, 8));
		RiverData.Add(("Euphrates", "Iraq, Turkey, Iran, Syria", 600, 1000, 1700, 8));
		RiverData.Add(("Volga", "Russia", 600, 1000, 1700, 8));
		RiverData.Add(("Río de la Plata", "Brazil, Argentina, Paraguay, Uruguay", 600, 1000, 1700, 8));
		RiverData.Add(("Niger", "Nigeria, Mali, Niger, Algeria", 630, 1000, 2300, 8));
		RiverData.Add(("Mackenzie", "Canada", 630, 1000, 2300, 8));
		RiverData.Add(("Mekong", "Laos, Thailand, China, Cambodia, Vietnam, Myanmar", 630, 1000, 2300, 8));
		RiverData.Add(("Lena", "Russia", 630, 1000, 2300, 8));
		RiverData.Add(("Amur", "Russia, China, Mongolia", 660, 1000, 2800, 8));
		RiverData.Add(("Congo", "Democratic Republic of the Congo, Central African Republic", 660, 1000, 2800, 8));
		RiverData.Add(("Ob", "Russia, Kazakhstan, Mongolia", 660, 1000, 2800, 8));
		RiverData.Add(("Yellow", "China", 660, 1000, 2800, 8));
		RiverData.Add(("Angara", "Russia, Mongolia", 690, 1000, 3400, 8));
		RiverData.Add(("Mississippi", "United States", 690, 1000, 3400, 8));
		RiverData.Add(("Yangtze", "China", 690, 1000, 3400, 8));
		RiverData.Add(("Amazon", "Brazil, Peru, Bolivia, Colombia, Ecuador", 720, 3400, 4000, 9));
		RiverData.Add(("Nile", "Ethiopia, Sudan, Uganda, Tanzania, Kenya, Egypt", 720, 3400, 4000, 9));
		RiverData.Add(("Sanzu", "n/a", 780, 4000, 5000, 10));
		RiverData.Add(("Pishon", "n/a", 840, 4000, 6000, 10));
		RiverData.Add(("Moving Sands", "n/a", 900, 6000, 7300, 11));
		RiverData.Add(("Sillas", "n/a", 960, 6000, 8500, 11));
		RiverData.Add(("Iardanus", "n/a", 1020, 8500, 10000, 12));
		RiverData.Add(("Celadon", "n/a", 1080, 8500, 12000, 12));
		RiverData.Add(("Eridanos", "n/a", 1140, 12000, 15000, 14));
		RiverData.Add(("Lethe", "n/a", 1200, 12000, 19000, 14));
		RiverData.Add(("Cocytus", "n/a", 1260, 19000, 24000, 15));
		RiverData.Add(("Phlegethon", "n/a", 1320, 19000, 30000, 15));
		RiverData.Add(("Acheron", "n/a", 1380, 30000, 38000, 18));
		RiverData.Add(("Styx", "n/a", 1440, 30000, 50000, 18));

		foreach (var river in RiverData) {
			Data_RiverData NewRiverData = new();

			NewRiverData.RiverName = river.name;
			NewRiverData.RiverLocation = river.location;
			NewRiverData.RiverMinuteDuration = river.duration;
			NewRiverData.RiverMinSoulCount = river.minSouls;
			NewRiverData.RiverMaxSoulCount = river.maxSouls;
			NewRiverData.RiverLevelUnlock = (PlayerLevels)river.level;

			Rivers.Add(NewRiverData);
		}

		Data_Controller.Instance.LoadingAmount += 18.0f;
	}

	private void SetSoulExperiences() {
		Debug.Log("Constant_Controller: " + "Setting list of soul experiences");

		// Eye Color
		SoulExperienceEyeColor.Add("Blue");
		SoulExperienceEyeColor.Add("Brown");
		SoulExperienceEyeColor.Add("Gray");
		SoulExperienceEyeColor.Add("Green");
		SoulExperienceEyeColor.Add("Hazel");
		SoulExperienceEyeColor.Add("Red");

		// Continents Lived
		SoulExperienceContinents.Add("Africa");
		SoulExperienceContinents.Add("Antarctica");
		SoulExperienceContinents.Add("Asia");
		SoulExperienceContinents.Add("Australia");
		SoulExperienceContinents.Add("Europe");
		SoulExperienceContinents.Add("North America");
		SoulExperienceContinents.Add("South America");

		// Number of Kids
		SoulExperienceKidsCount.Add("0 Kids");
		SoulExperienceKidsCount.Add("1 Kid");
		SoulExperienceKidsCount.Add("2 Kids");
		SoulExperienceKidsCount.Add("3 Kids");
		SoulExperienceKidsCount.Add("4 Kids");
		SoulExperienceKidsCount.Add("5 Kids");
		SoulExperienceKidsCount.Add("6 Kids");
		SoulExperienceKidsCount.Add("7 Kids");
		SoulExperienceKidsCount.Add("8 Kids");

		// Career Fields
		SoulExperienceCareerFields.Add("Architecture");
		SoulExperienceCareerFields.Add("Arts & Entertainment");
		SoulExperienceCareerFields.Add("Automotive");
		SoulExperienceCareerFields.Add("Business");
		SoulExperienceCareerFields.Add("Communication");
		SoulExperienceCareerFields.Add("Construction");
		SoulExperienceCareerFields.Add("Education");
		SoulExperienceCareerFields.Add("Engineering");
		SoulExperienceCareerFields.Add("Finance");
		SoulExperienceCareerFields.Add("Healthcare");
		SoulExperienceCareerFields.Add("Hospitality");
		SoulExperienceCareerFields.Add("Human Resources");
		SoulExperienceCareerFields.Add("Human Services");
		SoulExperienceCareerFields.Add("Law");
		SoulExperienceCareerFields.Add("Management");
		SoulExperienceCareerFields.Add("Marketing");
		SoulExperienceCareerFields.Add("Media");
		SoulExperienceCareerFields.Add("Sales");
		SoulExperienceCareerFields.Add("Technology");

		// Favorite Destinations
		SoulExperienceDestinations.Add("Amsterdam, Netherlands");
		SoulExperienceDestinations.Add("Athens, Greece");
		SoulExperienceDestinations.Add("Atlanta, Georgia, United States");
		SoulExperienceDestinations.Add("Bangkok, Thailand");
		SoulExperienceDestinations.Add("Barcelona, Spain");
		SoulExperienceDestinations.Add("Cairo, Egypt");
		SoulExperienceDestinations.Add("Cape Town, South Africa");
		SoulExperienceDestinations.Add("Cartagena, Colombia");
		SoulExperienceDestinations.Add("Cleveland, Ohio, United States");
		SoulExperienceDestinations.Add("Dubai, United Arab Emirates");
		SoulExperienceDestinations.Add("Florence, Italy");
		SoulExperienceDestinations.Add("Hokkaido, Japan");
		SoulExperienceDestinations.Add("Istanbul, Turkey");
		SoulExperienceDestinations.Add("Kuala Lumpur, Malaysia");
		SoulExperienceDestinations.Add("Las Vegas, Nevada, United States");
		SoulExperienceDestinations.Add("London, United Kingdom");
		SoulExperienceDestinations.Add("Mexico City, Mexico");
		SoulExperienceDestinations.Add("New York City, New York, United States");
		SoulExperienceDestinations.Add("Paris, France");
		SoulExperienceDestinations.Add("Rome, Italy");
		SoulExperienceDestinations.Add("Sydney, Australia");
		SoulExperienceDestinations.Add("Tallinn, Estonia");
		SoulExperienceDestinations.Add("Tokyo, Japan");
		SoulExperienceDestinations.Add("Toronto, Canada");

		Data_Controller.Instance.LoadingAmount += 18.0f;
	}

	private void SetDialoguePieces() {
		Debug.Log("Constant_Controller: " + "Setting dictionary of dialogue pieces");

		// Main Game Tutorial
		DialogueDict.Add((MainGameSection, 1), (DakotaName, "Oh, hi there. Are you new to the program, too?"));
		DialogueDict.Add((MainGameSection, 2), (UserName, "Yes."));
		DialogueDict.Add((MainGameSection, 3), (UserName, "What program?"));
		DialogueDict.Add((MainGameSection, 4), (DakotaName, "I’m excited! I am a fourth-generation ferryman."));
		DialogueDict.Add((MainGameSection, 5), (DakotaName, "To become a ferryman, of course! I am the fourth generation of a long line of ferrymen."));
		DialogueDict.Add((MainGameSection, 6), (DakotaName, "The name’s Dakota. Why don’t you tell me about yourself?"));
		DialogueDict.Add((MainGameSection, 7), (DakotaName, "It’s nice to meet you, " + Data_Controller.Instance.PlayerName + "! What are you most excited about in becoming a ferryman?"));
		DialogueDict.Add((MainGameSection, 8), (UserName, "I want to learn about people’s lives and experiences."));
		DialogueDict.Add((MainGameSection, 9), (UserName, "I get to sail a boat full of ghosts!"));
		DialogueDict.Add((MainGameSection, 10), (DakotaName, "Me too! Mom says that’s the most rewarding thing about ferrying those who have passed."));
		DialogueDict.Add((MainGameSection, 11), (DakotaName, "They are not ghosts, have some respect!"));
		DialogueDict.Add((MainGameSection, 12), (DakotaName, "Now, the first thing we need is a ship in order to ferry souls to their next venture."));
		DialogueDict.Add((MainGameSection, 13), (DakotaName, "Follow me to the Shipyard!"));

		// Shipyard Tutorial
		DialogueDict.Add((ShipyardSection, 1), (DakotaName, "This is where you will be able to build, purchase, and upgrade ships."));
		DialogueDict.Add((ShipyardSection, 2), (DakotaName, "You can only sail one ship at a time, so any prior vessel gets broken down for scraps."));
		DialogueDict.Add((ShipyardSection, 3), (DakotaName, "Since we are beginners, we are given these to start."));
		DialogueDict.Add((ShipyardSection, 4), (DakotaName, "I know it’s not much, but do well and you could have a ship like Charon, himself!"));
		DialogueDict.Add((ShipyardSection, 5), (UserName, "That would be awesome."));
		DialogueDict.Add((ShipyardSection, 6), (UserName, "Who?"));
		DialogueDict.Add((ShipyardSection, 7), (DakotaName, "I know! But baby steps first."));
		DialogueDict.Add((ShipyardSection, 8), (DakotaName, "Ha ha, what a great joke...right?"));
		DialogueDict.Add((ShipyardSection, 9), (DakotaName, "Go ahead and name your ship, captain!"));
		DialogueDict.Add((ShipyardSection, 10), (DakotaName, "Perfect! Follow me to the Globe."));
		DialogueDict.Add((ShipyardSection, 11), (DakotaName, "That’s already a famous ship, why not be more unique?"));
		DialogueDict.Add((ShipyardSection, 12), (DakotaName, "Don’t name your ship that!"));

		// Globe Tutorial
		DialogueDict.Add((GlobeSection, 1), (DakotaName, "Here is where this world meets the next via rivers."));
		DialogueDict.Add((GlobeSection, 2), (DakotaName, "As a ferryman, we must help the souls from this world travel to the next."));
		DialogueDict.Add((GlobeSection, 3), (DakotaName, "Souls wait on the shore of whichever river they desire, from the shortest tributary to the lengthy River Styx."));
		DialogueDict.Add((GlobeSection, 4), (UserName, "Why not use one river?"));
		DialogueDict.Add((GlobeSection, 5), (DakotaName, "Great question! Instead of the Styx jamming up with a lot of traffic, Charon opened up soul-ferrying to dozens of other rivers to counter the traffic."));
		DialogueDict.Add((GlobeSection, 6), (DakotaName, "Souls wanting to just get across might want shorter rivers while others could want to prolong starting their next chapter."));
		DialogueDict.Add((GlobeSection, 7), (DakotaName, "In those cases, Charon wanted them to be comfortable. More elaborate and extravagant ships sail longer rivers."));
		DialogueDict.Add((GlobeSection, 8), (UserName, "Oh, so our little dinghies are only good for short rivers?"));
		DialogueDict.Add((GlobeSection, 9), (DakotaName, "Correct! It’s sort of the tier system for ferrymen: more skilled ferrymen work the longer rivers, leaving shorter ones for rookies."));
		DialogueDict.Add((GlobeSection, 10), (DakotaName, "Shorter ones like this one: The Rhine, which flows through several countries, including Germany, Italy, France, and Austria."));
		DialogueDict.Add((GlobeSection, 11), (UserName, "Cool. I’ve heard of the Rhine."));
		DialogueDict.Add((GlobeSection, 12), (UserName, "Neat. It sounds like a nice river."));
		DialogueDict.Add((GlobeSection, 13), (DakotaName, "It might be shorter than most, but it’s famous! Perfect for rookies like us."));
		DialogueDict.Add((GlobeSection, 14), (DakotaName, "Now let me see...we have our ships and we have a river. Great! Let’s go meet some souls!"));
		DialogueDict.Add((GlobeSection, 15), (UserName, "Awesome."));
		DialogueDict.Add((GlobeSection, 16), (DakotaName, "Just click here to Set Sail, and we’ll have our heading!"));
		DialogueDict.Add((GlobeSection, 17), (DakotaName, "Great! We are sailing away down the Rhine."));
		DialogueDict.Add((GlobeSection, 18), (DakotaName, "And we’re sailing..."));
		DialogueDict.Add((GlobeSection, 19), (DakotaName, "And sailing..."));
		DialogueDict.Add((GlobeSection, 20), (DakotaName, "You get the idea. This isn’t a jet, it’s a slow-going ship. These sails will take time depending on the length of the river."));
		DialogueDict.Add((GlobeSection, 21), (UserName, "That makes sense."));
		DialogueDict.Add((GlobeSection, 22), (DakotaName, "Good, then this will be even better: You have coins collected from souls, but you also have a handful of gems."));
		DialogueDict.Add((GlobeSection, 23), (DakotaName, "Gems are very rare, but they are also a valuable currency for ferrymen."));
		DialogueDict.Add((GlobeSection, 24), (UserName, "How so?"));
		DialogueDict.Add((GlobeSection, 25), (DakotaName, "If you go away to do other things, you’ll get a notification letting you know the voyage has completed. Just make sure notifications are on."));
		DialogueDict.Add((GlobeSection, 26), (DakotaName, "If you want to quicken the journey, using a gem will instantly complete the trek down river!"));
		DialogueDict.Add((GlobeSection, 27), (UserName, "Oh neat. So I can choose how quickly I want to sail each trip?"));
		DialogueDict.Add((GlobeSection, 28), (DakotaName, "Precisely! You’re getting the hang of it."));
		DialogueDict.Add((GlobeSection, 29), (DakotaName, "The Rhine is a short river and has a 2-minute travel time. This trip is just about complete already."));
		DialogueDict.Add((GlobeSection, 33), (DakotaName, "There we go, you successfully ferried a couple of souls down the Rhine River to their next chapter of life! How are you feeling?"));
		DialogueDict.Add((GlobeSection, 34), (UserName, "Great, I’m getting the hang of it. What is all this?"));
		DialogueDict.Add((GlobeSection, 35), (UserName, "I think I’ll get the hang of it with more traveling. What is all this?"));
		DialogueDict.Add((GlobeSection, 36), (DakotaName, "These are your ferry stats. Charon let’s all ferrymen know how each journey went with various information."));
		DialogueDict.Add((GlobeSection, 37), (DakotaName, "Oh and look! One of the souls decided to share some of their life experiences with you!"));
		DialogueDict.Add((GlobeSection, 38), (DakotaName, "Every now and then, souls might want to share pieces of their life. These would include their profession, continent they lived, eye color, favorite travel destination, or number of kids."));
		DialogueDict.Add((GlobeSection, 39), (UserName, "That’s really interesting. It’s nice getting to learn about other people’s experiences."));
		DialogueDict.Add((GlobeSection, 40), (DakotaName, "It is! That’s a huge reason why I wanted to be a ferryman, and I’m sure why you wanted to, as well."));
		DialogueDict.Add((GlobeSection, 41), (DakotaName, "We can talk more about those experiences later when we get to Charon’s Competitions. You’ll love those!"));
		DialogueDict.Add((GlobeSection, 42), (DakotaName, "For now, go ahead and explore. Sail some more along the Rhine to get some more coins, and maybe you’ll hear more life stories!"));
		DialogueDict.Add((GlobeSection, 43), (DakotaName, "Once you’re ready, I can give you some pointers with the Helm, Ledger, Trade Post, Charon’s Competitions, and some other interesting features used by the ferrymen."));
		DialogueDict.Add((GlobeSection, 44), (DakotaName, "Have fun!"));

		// Helm Tutorial
		DialogueDict.Add((HelmSection, 1), (DakotaName, "Welcome to the helm, captain!"));
		DialogueDict.Add((HelmSection, 2), (DakotaName, "As a ferryman, you are not alone like old texts and stories used to portray Charon."));
		DialogueDict.Add((HelmSection, 3), (DakotaName, "Instead, he has built up an entire community of those driven by learning about the lives and experiences of the people of the world."));
		DialogueDict.Add((HelmSection, 4), (DakotaName, "At the helm, you get to communicate with those in this great community!"));
		DialogueDict.Add((HelmSection, 5), (UserName, "Awesome. It’s good to never be alone."));
		DialogueDict.Add((HelmSection, 6), (DakotaName, "Exactly. Add as many friends from our community as you wish!"));
		DialogueDict.Add((HelmSection, 7), (DakotaName, "When you have friends, you can view their recent travels, send them encouraging messages, or even trade ships!"));
		DialogueDict.Add((HelmSection, 8), (DakotaName, "You can also customize your appearance to bring your own flair and personality to the community of ferrymen."));
		DialogueDict.Add((HelmSection, 9), (UserName, "Thanks, Dakota. You’re a good friend."));

		// Ledger Tutorial
		DialogueDict.Add((LedgerSection, 1), (DakotaName, "Ah, I see you found the ship’s ledger. Someone’s inquisitive."));
		DialogueDict.Add((LedgerSection, 2), (DakotaName, "Ha, just kidding! The ledger is something you should get to know and frequently reference."));
		DialogueDict.Add((LedgerSection, 3), (DakotaName, "It holds the various experiences from all the souls you have ferried over the course of your tenure as a ferryman."));
		DialogueDict.Add((LedgerSection, 4), (UserName, "Every experience?"));
		DialogueDict.Add((LedgerSection, 5), (DakotaName, "Of course! You can see how many ferried souls worked as lawyers, or lived in Australia, or had three kids, or have green eyes."));
		DialogueDict.Add((LedgerSection, 6), (DakotaName, "These lists can be broken down into weekly collections of experiences and lifetime collections."));
		DialogueDict.Add((LedgerSection, 7), (UserName, "Why would we need both?"));
		DialogueDict.Add((LedgerSection, 8), (DakotaName, "Great question! The weekly lists are used for Charon’s weekly competitions."));
		DialogueDict.Add((LedgerSection, 9), (DakotaName, "One week could have a competition with whoever has ferried the most blue-eyed souls or most people who loved visiting Florence..."));
		DialogueDict.Add((LedgerSection, 10), (DakotaName, "Regardless, you would be able to see instantly how many of those souls you have ferried that week."));
		DialogueDict.Add((LedgerSection, 11), (UserName, "Got it, that makes sense."));
		DialogueDict.Add((LedgerSection, 12), (DakotaName, "The lifetime collections are more just for friendly competitions between you and your friends."));
		DialogueDict.Add((LedgerSection, 13), (DakotaName, "Be sure to keep referencing your ledger to see how it increases over time the more you ferry!"));

		// Trade Post Tutorial
		DialogueDict.Add((TradePostSection, 1), (DakotaName, "Welcome, " + Data_Controller.Instance.PlayerName + "! This is the trade post."));
		DialogueDict.Add((TradePostSection, 2), (UserName, "Hi, Dakota. What is the trade post?"));
		DialogueDict.Add((TradePostSection, 3), (DakotaName, "The trade post is where we do our shopping."));
		DialogueDict.Add((TradePostSection, 4), (DakotaName, "Here, you can purchase various accessories for some cosmetic flair, ship enhancements that might bring more rewards, or gems for extreme purchases."));
		DialogueDict.Add((TradePostSection, 5), (DakotaName, "Gems, if you remember, can instantly complete any river journey."));
		DialogueDict.Add((TradePostSection, 6), (UserName, "I remember. Not really sure why that would be important, though."));
		DialogueDict.Add((TradePostSection, 7), (UserName, "Seems like I could just keep my gems."));
		DialogueDict.Add((TradePostSection, 8), (DakotaName, "You can, absolutely! However, here is a thought..."));
		DialogueDict.Add((TradePostSection, 9), (DakotaName, "It’s the end of the week for one of Charon’s competitions. You find yourself in a close second place."));
		DialogueDict.Add((TradePostSection, 10), (DakotaName, "The top five places will receive various prizes, but that first place prize is what you truly want."));
		DialogueDict.Add((TradePostSection, 11), (UserName, "Of course, who doesn’t want to be number one?"));
		DialogueDict.Add((TradePostSection, 12), (DakotaName, "That’s the spirit! Now, you’re in second place and you’re holding several gems."));
		DialogueDict.Add((TradePostSection, 13), (DakotaName, "Using those gems will let you travel rivers instantaneously!"));
		DialogueDict.Add((TradePostSection, 14), (UserName, "Oh, so that would let me travel many rivers instead of having to wait for hours at a time."));
		DialogueDict.Add((TradePostSection, 15), (DakotaName, "Yes! That’s exactly correct!"));
		DialogueDict.Add((TradePostSection, 16), (UserName, "That makes sense. Now I want to make sure I’m number one each week."));
		DialogueDict.Add((TradePostSection, 17), (DakotaName, "Good luck! Just between us, here are a handful more gems to help!"));
		DialogueDict.Add((TradePostSection, 18), (UserName, "Thanks, Dakota."));

		// Charon's Competitions Tutorial
		DialogueDict.Add((CharonsCompetitionsSection, 1), (CharonName, Data_Controller.Instance.PlayerName + ". I hope you have been enjoying your time as a ferryman so far."));
		DialogueDict.Add((CharonsCompetitionsSection, 2), (UserName, "Umm, hi?"));
		DialogueDict.Add((CharonsCompetitionsSection, 3), (CharonName, "I am Charon. I’m sure you’ve heard of me."));
		DialogueDict.Add((CharonsCompetitionsSection, 4), (UserName, "Yes, I have."));
		DialogueDict.Add((CharonsCompetitionsSection, 5), (UserName, "Dakota might have mentioned your name."));
		DialogueDict.Add((CharonsCompetitionsSection, 6), (UserName, "No clue."));
		DialogueDict.Add((CharonsCompetitionsSection, 7), (CharonName, "Good. It is great having you here as part of this growing community."));
		DialogueDict.Add((CharonsCompetitionsSection, 8), (CharonName, "Please, do not try being humorous with me."));
		DialogueDict.Add((CharonsCompetitionsSection, 9), (CharonName, "Now, Dakota must have mentioned my weekly competitions."));
		DialogueDict.Add((CharonsCompetitionsSection, 10), (CharonName, "Each week, I create a new competition amongst all ferrymen. Friendly competition, of course. No need adding to the souls."));
		DialogueDict.Add((CharonsCompetitionsSection, 11), (CharonName, "These competitions can range from who has ferried the most brown-eyed souls, sailed on the most rivers, spent the longest time sailing, or spent the most coins at the trade post."));
		DialogueDict.Add((CharonsCompetitionsSection, 12), (CharonName, "Everyone’s numbers will restart each week for each competition."));
		DialogueDict.Add((CharonsCompetitionsSection, 13), (CharonName, "This way, everyone will have a chance to win."));
		DialogueDict.Add((CharonsCompetitionsSection, 14), (UserName, "That’s very generous and inclusive of you."));
		DialogueDict.Add((CharonsCompetitionsSection, 15), (CharonName, "Yes. I’ve had many years to learn and many souls have guided me along the way."));
		DialogueDict.Add((CharonsCompetitionsSection, 16), (CharonName, "This week’s competition is already in progress, but good luck, " + Data_Controller.Instance.PlayerName + "."));
		DialogueDict.Add((CharonsCompetitionsSection, 17), (CharonName, "Until we meet next time..."));

		Data_Controller.Instance.LoadingAmount += 18.0f;
	}
	
// ---------------------------------------- END: VOID FUNCTIONS ----------------------------------------
}}