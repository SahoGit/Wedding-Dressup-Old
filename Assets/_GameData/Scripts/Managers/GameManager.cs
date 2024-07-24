using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;
    public ArrayList makeuphairDataList;
    public ArrayList lensDataList;
    public ArrayList eyeBrowsDataList;
    public ArrayList eyeLashesDataList;

    public ArrayList dressDataList;
    public ArrayList veilDataList;
    public ArrayList necklaceDataList;
    public ArrayList earringDataList;
    
    public ArrayList flowerDataList;
    public ArrayList headwearDataList;
    public ArrayList shoesDataList;

    public ArrayList fashionShoesDataList;
    public ArrayList fashionEarringDataList;
    public ArrayList fashionHairsDataList;
    public ArrayList fashionDressDataList;
    public ArrayList fashionNecklaceDataList;
    public ArrayList fashionBracletDataList;
    public ArrayList fashionBagsDataList;



	



	//[HideInInspector]
	public bool isGameFirstLoop;
	//[HideInInspector]
	public string currentScene;
	//[HideInInspector]
	public string current_Mode;
	//[HideInInspector]
	public string currentTag;
	//[HideInInspector]
	public bool canMoveScroll;
	//[HideInInspector]
	public int currentActiveScrollChunk;
	//[HideInInspector]
	public bool canDrawMask;
	//[HideInInspector]
	public string maskname;

    public BaseItem CurrentDressupItem;
    /// Makeup Items Base Items

    public BaseItem selectedHair;
	public BaseItem selectedLens;
    public BaseItem selectedEyeBrow;
    public BaseItem selectedEyeLash;
    public BaseItem selectedEyeShade;
	public BaseItem selectedEyeLiner;
	public BaseItem selectedEyeLashes;
	public BaseItem selectedCheekShade;
	public BaseItem selectedLips;

	
	
	//girl dress items
	public BaseItem selectedDress;
	public BaseItem selectedVeil;
    public BaseItem selectedDressupHairs;
    public BaseItem selectedShoes;
    public BaseItem selectedEarRing;
  
    public BaseItem selectedNecklace;
    public BaseItem selectedFlower;
    public BaseItem selectedHeadWear;

    public BaseItem selectedFashionHairs;
    public BaseItem selectedFashionDress;
    public BaseItem selectedFashionNecklace;
    public BaseItem selectedFashionEarring;
    public BaseItem selectedFashionBag;
    public BaseItem selectedFashionShoes;
    public BaseItem selectedFashionBreslet;

    public Player player;


    [HideInInspector]
	public bool isGamePaused;
	
	// persistant singleton
    private static GameManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static GameManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<GameManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		Debug.Log("Awake Called");

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void Start ()
	{
		Debug.Log("Start Called");

		// for any init behavior setup
		this.isGamePaused = false;
		this.isGameFirstLoop = true;
        this.player = new Player();
        this.SetData();
	}
	
	void OnEnable()
	{
		Debug.Log("OnEnable Called");

	}
	
	void OnDisable()
	{
		Debug.Log("OnDisable Called");

	}

	#endregion

	#region Utility Methods 

	private void SetData() {
        this.makeuphairDataList = DataProvider.GetMakeUpHairsDataList();
        this.lensDataList = DataProvider.GetLensDataList();
        this.eyeBrowsDataList = DataProvider.GetEyeBrowsDataList();
		this.eyeLashesDataList = DataProvider.GetMakeUpEyeLashesDataList();
        this.dressDataList = DataProvider.GetDressDataList();
		this.veilDataList = DataProvider.GetVeilDataList();
        this.earringDataList = DataProvider.GetWeddingEarringsDataList();
        
        this.necklaceDataList = DataProvider.GetNecklaceDataList();
		this.shoesDataList = DataProvider.GetShoesDataList();
		this.flowerDataList = DataProvider.GetFlowersDataList();
		this.headwearDataList = DataProvider.GetHeadWearDataList();

        this.fashionDressDataList = DataProvider.GetFashionDressDataList();
        this.fashionBagsDataList = DataProvider.GetFashionBagsDataList();
        this.fashionBracletDataList = DataProvider.GetFashionBracletDataList();
        this.fashionNecklaceDataList = DataProvider.GetFashionNecklaceDataList();
        this.fashionShoesDataList = DataProvider.GetFashionShoesDataList();
        this.fashionEarringDataList = DataProvider.GetFashionEarringsDataList();
        this.fashionHairsDataList = DataProvider.GetFashionHairsDataList();


        //GameManager.instance.selectedCharacter = GameManager.instance.characterBodyDataList [1] as BaseItem;


        canMoveScroll = true;
		canDrawMask = false;
	}

	public void LogDebug(string message) {
		if (ShowDebugLogs)
			Debug.Log ("GameManager >> " + message);
	}
	
	private void LogErrorDebug(string message) {
		if (ShowDebugLogs)
			Debug.LogError ("GameManager >> " + message);
	}

	#endregion

	#region Callback Methods 


	#endregion
}
