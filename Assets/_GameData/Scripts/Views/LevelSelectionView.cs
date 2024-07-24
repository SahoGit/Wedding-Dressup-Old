//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class LevelSelectionView : MonoBehaviour {

//	#region Variables, Constants & Initializers
//	public GameObject levelImage;
//	public RectTransform levelImageEndPoint;
//	public RectTransform [] buttonPositions;
//	public GameObject [] buttons;
//	public GameObject[] buttonlock;
//	public GameObject bg;
//	public RectTransform spazoomposition,makeupzoomposition,dressupzoomposition,partnerzoomposition,boydressupzoomposition,newstvzoomposition,realitytvzoomposition;
//	public GameObject levelImageParent;
//	public GameObject levels_Child;
//	public GameObject transitionImage;

//	#endregion

//	#region Lifecycle Methods

//	// Use this for initialization
//	void Start () {
//		Invoke ("SetViewContents", 0.1f);
//	}

//	// Update is called once per frame
//	void Update () {
		
//	}

//	#endregion

//	#region Callback Methods

//	private void SetViewContents() {
//		transitionImage.GetComponent<Animator> ().enabled = true;
//		resetBackGround ();
//		MoveActionloop (levelImage, levelImageEndPoint, 2.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);
//		//PlayerPrefs.SetInt ("levelselection", 0);
//		print ("value of level selection is:"+PlayerPrefs.GetInt("levelselection"));
//		levelOpen ();
//		selectedButtonMovement (PlayerPrefs.GetInt ("levelselection"));
//		transitionImage.SetActive (false);
//	}
//	private void MoveAction(GameObject obj,RectTransform pos,float time,iTween.EaseType type)
//	{
//		Hashtable tweenParams = new Hashtable();
//		tweenParams.Add ("x", pos.position.x);
//		tweenParams.Add ("y", pos.position.y);
//		tweenParams.Add ("time", time);
//		tweenParams.Add ("easetype", type);
//		iTween.MoveTo (obj, tweenParams);
//	}

//	private void ScaleAction (GameObject obj, float ScaleFactor, float time, iTween.EaseType type)
//	{
//		Hashtable tweenParams = new Hashtable ();
//		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
//		tweenParams.Add ("time", 0.5f);
//		tweenParams.Add ("easetype", type);
//		iTween.ScaleTo (obj, tweenParams);
//	}
//	private void ScaleActionloop(GameObject obj, float ScaleFactor, float time, iTween.EaseType type, iTween.LoopType loop)
//	{
//		Hashtable tweenParams = new Hashtable ();
//		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
//		tweenParams.Add ("time", 0.5f);
//		tweenParams.Add ("easetype", type);
//		tweenParams.Add ("looptype", loop);
//		iTween.ScaleTo (obj, tweenParams);
//	}
//	private void MoveActionloop(GameObject obj,RectTransform pos,float time,iTween.EaseType type,iTween.LoopType loop)
//	{
//		Hashtable tweenParams = new Hashtable();
//		tweenParams.Add ("x", pos.position.x);
//		tweenParams.Add ("y", pos.position.y);
//		tweenParams.Add ("time", time);
//		tweenParams.Add ("easetype", type);
//		tweenParams.Add ("looptype",loop);
//		iTween.MoveTo (obj, tweenParams);
//	}
//	private void resetBackGround()
//	{
//		bg.GetComponent<RectTransform> ().position = new Vector3 (0,0,0);
//		bg.GetComponent<RectTransform> ().localScale = new Vector3(1.0f,1.0f,1.0f); 

//	}
//	private void openSpaScene()
//	{
//		NavigationManager.instance.ReplaceScene (GameScene.SALON);

//	}
//	private void openMakeupScene()
//	{
//		NavigationManager.instance.ReplaceScene (GameScene.MAKEUP);

//	}
//	private void openDressupScene()
//	{
//		NavigationManager.instance.ReplaceScene (GameScene.DRESSUP);

//	}
//	private void openCounterScene()
//	{
//		//NavigationManager.instance.ReplaceScene (GameScene.COUNTER);

//	}
//	private void openGardenScene()
//	{
//		//NavigationManager.instance.ReplaceScene (GameScene.GARDEN);

//	}
//	private void openStudioScene()
//	{
//		NavigationManager.instance.ReplaceScene (GameScene.PHOTOSHOOT);

//	}

//	private void spaButtonMovement()
//	{
//		ScaleActionloop (buttons [0], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//		//MoveActionloop (buttons [0], buttonPositions [0], 0.8f, iTween.EaseType.linear, iTween.LoopType.pingPong);

//	}
//	private void dressupButtonMovement()
//	{
//		    ScaleActionloop (buttons [2], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//			//MoveActionloop (buttons [2], buttonPositions [2], 0.8f, iTween.EaseType.linear, iTween.LoopType.pingPong);

//	}
//	private void GardenMovement ()
//	{
//		ScaleActionloop (buttons [4], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//		//MoveActionloop (buttons [4], buttonPositions [4], 0.8f, iTween.EaseType.linear, iTween.LoopType.pingPong);

//	}
//	private void makeupButtonMovement()
//	{
//		ScaleActionloop (buttons [1], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//			//MoveActionloop (buttons [1], buttonPositions [1], 0.8f, iTween.EaseType.linear, iTween.LoopType.pingPong);

//	}

//	private void PhotogarphyMovement ()
//	{
//		ScaleActionloop (buttons [5], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//			//MoveActionloop (buttons [5], buttonPositions [5], 0.8f, iTween.EaseType.linear, iTween.LoopType.pingPong);

//	}

//	private void CounterMovement()
//	{
//		ScaleActionloop (buttons [3], 1.1f, 0.8f, iTween.EaseType.easeInBounce, iTween.LoopType.pingPong);
//		//MoveActionloop(buttons[3],buttonPositions[3],0.8f,iTween.EaseType.linear,iTween.LoopType.pingPong);

//	}

//	private void selectedButtonMovement(int openlevel)
//	{
//		switch (openlevel)
//		{
//		case 0:
//			spaButtonMovement ();

//			break;
//		case 1:
//			makeupButtonMovement ();
//			break;
//		case 2:
//			dressupButtonMovement ();
//			break;
//		case 3:
//			CounterMovement ();
//			//partnerClosetMovement ();
//			break;
//		case 4:
//			GardenMovement ();

//			break;
//		case 5:
//			PhotogarphyMovement ();

//			break;
//		default:
//			print ("Incorrect information");
//			break;
//		}




//	}

//	private void levelOpen()
//	{
//		if (PlayerPrefs.GetInt ("levelselection") == 1) {
			
//			buttons [0].GetComponent<Button> ().enabled = true;
//			buttonlock [0].SetActive (false);
//			buttons [1].GetComponent<Button> ().enabled = true;
//			buttonlock [1].SetActive (false);
	

//		}
//		if (PlayerPrefs.GetInt ("levelselection") == 2) {
			
//			buttons [0].GetComponent<Button> ().enabled = true;
//			buttonlock [0].SetActive (false);
//			buttons [1].GetComponent<Button> ().enabled = true;
//			buttonlock [1].SetActive (false);
//			buttons [2].GetComponent<Button> ().enabled = true;
//			buttonlock [2].SetActive (false);
//		}
//		if (PlayerPrefs.GetInt ("levelselection") == 3) {
			
//			buttons [0].GetComponent<Button> ().enabled = true;
//			buttonlock [0].SetActive (false);
//			buttons [1].GetComponent<Button> ().enabled = true;
//			buttonlock [1].SetActive (false);
//			buttons [2].GetComponent<Button> ().enabled = true;
//			buttonlock [2].SetActive (false);
//			buttons [3].GetComponent<Button> ().enabled = true;
//			buttonlock [3].SetActive (false);

//		}
//		if (PlayerPrefs.GetInt ("levelselection") == 4) {
			
//			buttons [0].GetComponent<Button> ().enabled = true;
//			buttonlock [0].SetActive (false);
//			buttons [1].GetComponent<Button> ().enabled = true;
//			buttonlock [1].SetActive (false);
//			buttons [2].GetComponent<Button> ().enabled = true;
//			buttonlock [2].SetActive (false);
//			buttons [3].GetComponent<Button> ().enabled = true;
//			buttonlock [3].SetActive (false);
//			buttons [4].GetComponent<Button> ().enabled = true;
//			buttonlock [4].SetActive (false);


//		}
//		if (PlayerPrefs.GetInt ("levelselection") == 5) {
			
//			buttons [0].GetComponent<Button> ().enabled = true;
//			buttonlock [0].SetActive (false);
//			buttons [1].GetComponent<Button> ().enabled = true;
//			buttonlock [1].SetActive (false);
//			buttons [2].GetComponent<Button> ().enabled = true;
//			buttonlock [2].SetActive (false);
//			buttons [3].GetComponent<Button> ().enabled = true;
//			buttonlock [3].SetActive (false);
//			buttons [4].GetComponent<Button> ().enabled = true;
//			buttonlock [4].SetActive (false);
//			buttons [5].GetComponent<Button> ().enabled = true;
//			buttonlock [5].SetActive (false);


//		}

//	}

//	#endregion


//	#region Callback Methods
//	public void onLevelSelectedClick(int tag)
//	{
//		switch (tag)
//		{
//		case 1:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg,spazoomposition,0.5f,iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons [0]);
//			Invoke ("openSpaScene",1.5f);

//			break;
//		case 2:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg, makeupzoomposition, 0.5f, iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//			buttons [1].GetComponent<RectTransform> ().localPosition = new Vector3 (-100f,buttons [1].GetComponent<RectTransform> ().localPosition.y,buttons [1].GetComponent<RectTransform> ().localPosition.z );
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons[1]);
//			Invoke ("openMakeupScene",1.5f);
//			break;
//		case 3:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg,dressupzoomposition,0.5f,iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//			buttons [2].GetComponent<RectTransform> ().localPosition = new Vector3 (103f,buttons [2].GetComponent<RectTransform> ().localPosition.y,buttons [2].GetComponent<RectTransform> ().localPosition.z );
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons[2]);
//			Invoke ("openDressupScene",1.5f);
//			break;
//		case 4:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg,partnerzoomposition,0.5f,iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//			buttons [3].GetComponent<RectTransform> ().localPosition = new Vector3 (-85f,buttons [3].GetComponent<RectTransform> ().localPosition.y,buttons [3].GetComponent<RectTransform> ().localPosition.z );
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons[3]);
//		    Invoke ("openCounterScene",1.5f);
//			break;
//		case 5:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg,boydressupzoomposition,0.5f,iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//		    buttons [4].GetComponent<RectTransform> ().localPosition = new Vector3 (107f,buttons [4].GetComponent<RectTransform> ().localPosition.y,buttons [4].GetComponent<RectTransform> ().localPosition.z );
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons[4]);
//			Invoke ("openGardenScene",1.5f);
//			break;
//		case 6:
//			levels_Child.transform.SetParent (levelImageParent.transform);
//			MoveAction (bg,newstvzoomposition,0.5f,iTween.EaseType.linear);
//			ScaleAction (bg, 1.4f, 1.0f, iTween.EaseType.linear);
//			SoundManager.instance.PlayButtonClickSound ();
//			ParticleManger.instance.showSelectionParticle (buttons[5]);
//			Invoke ("openStudioScene",1.5f);
//			break;
//		default:
//			print ("Incorrect information");
//			break;
//		}

//	}

//	#endregion
//}
