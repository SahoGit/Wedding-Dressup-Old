using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameScene { MAINMENU = 0, SELECTIONVIEW = 1, MAKEUP = 2, DRESSUP = 3, FASHIONMAKEUP = 4, FASHIONDRESSUP = 5, WEDDINGSHOOT = 6, FASHIONSHOOT = 7, CAREERMODEMAKEUP = 8, CAREERMODEDRESSUP = 9 }

public class NavigationManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;

	private Dictionary<string, Stack> navigationStacks = new Dictionary<string, Stack>();
	public Stack navigationStack;
	public GameScene launchScene;

	public GameObject mainMenu;
	public GameObject selectionView;
	public GameObject makeup;
	public GameObject dressup;
    public GameObject fashionMakeup;
    public GameObject fashionDressup;
	public GameObject weddingShoot;
    public GameObject fashionShoot;
    public GameObject careerModeMakeUp;
    public GameObject careerModeDressUp;

    private GameObject runningScene;

	// persistant singleton
    private static NavigationManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static NavigationManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<NavigationManager>();

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
		OnBackKeyPressed ();
	}

	void Start ()
	{
        //Debug.Log("Start Called");

        // for any init behavior setup
		runningScene = null;
        navigationStack = new Stack();
		SetGameScene (launchScene);
    }
	

	#endregion

	#region Utility Methods 

	private void SetGameScene(GameScene scene) {
		if(runningScene != null) {
			Destroy (runningScene);
		}

		switch (scene) {
		case GameScene.MAINMENU:
			runningScene = GetGameSceneInstance (mainMenu);
			break;
        case GameScene.SELECTIONVIEW:
             runningScene = GetGameSceneInstance(selectionView);
            break;
        case GameScene.MAKEUP:
			runningScene = GetGameSceneInstance (makeup);
			break;
		case GameScene.DRESSUP:
			runningScene = GetGameSceneInstance (dressup);
			break;
		case GameScene.FASHIONMAKEUP:
			runningScene = GetGameSceneInstance (fashionMakeup);
			break;
		case GameScene.FASHIONDRESSUP:
			runningScene = GetGameSceneInstance (fashionDressup);
			break;
		case GameScene.WEDDINGSHOOT:
			runningScene = GetGameSceneInstance (weddingShoot);
			break;
        case GameScene.FASHIONSHOOT:
            runningScene = GetGameSceneInstance(fashionShoot);
            break;
        case GameScene.CAREERMODEMAKEUP:
            runningScene = GetGameSceneInstance(careerModeMakeUp);
            break;
        case GameScene.CAREERMODEDRESSUP:
            runningScene = GetGameSceneInstance(careerModeDressUp);
            break;

        }

		navigationStack.Push (scene);

		runningScene.SetActive (true);
	}

	private GameObject GetGameSceneInstance(GameObject prefab) {
		GameObject gameScene = GameObject.Instantiate(prefab) as GameObject;
		gameScene.name = prefab.name;
		gameScene.GetComponent<Canvas>().worldCamera = Camera.main;

		return gameScene;
	}

	public void ReplaceScene(GameScene scene) {
		SetGameScene (scene);
	}

	public void ReplaceSceneWithClear(GameScene scene) {
		navigationStack.Clear();
		SetGameScene (scene);
	}

	#endregion

	#region Callback Methods 

	private void OnBackKeyPressed() {
#if UNITY_ANDROID || UNITY_WP8
		if (Input.GetKeyDown(KeyCode.Escape) && (!GameManager.instance.isGamePaused)) 
		{ 
			switch ((GameScene) navigationStack.Peek()) {
			case GameScene.MAINMENU:
				//Application.Quit();
				break;
			case GameScene.SELECTIONVIEW:
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.MAKEUP:
				ReplaceScene(GameScene.SELECTIONVIEW);
				break;
			case GameScene.DRESSUP:
				ReplaceScene(GameScene.SELECTIONVIEW);
				break;
			case GameScene.FASHIONMAKEUP:
				ReplaceScene(GameScene.SELECTIONVIEW);
				break;
			case GameScene.FASHIONDRESSUP:
				ReplaceScene(GameScene.SELECTIONVIEW);
				break;
			case GameScene.WEDDINGSHOOT:
				ReplaceScene(GameScene.SELECTIONVIEW);
				break;
            case GameScene.FASHIONSHOOT:
                 ReplaceScene(GameScene.SELECTIONVIEW);
                 break;
            case GameScene.CAREERMODEMAKEUP:
                 ReplaceScene(GameScene.SELECTIONVIEW);
                 break;
            case GameScene.CAREERMODEDRESSUP:
                 ReplaceScene(GameScene.SELECTIONVIEW);
                 break;

            }
		}
#endif
    }

    #endregion
}
