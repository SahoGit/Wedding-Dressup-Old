//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class GardenView : MonoBehaviour {

//	#region Variables,Constants & Initializers
//	private int Background_Count;
//	public Image hand;
//	public Image arm;
//	public Image Background;
//	public GameObject MenuButtons;
//	public RectTransform ButtonsEndPoint;
//	public GameObject Character;
//	public RectTransform CharacterEndPoint;
//	public Image CharacterBody;
//	public Image CharacterEyes;

//	public Image HeadStyle;
//	public Image Dress;
//	public Image Bag;
//	public Image Shoes;
//	public Image Pent;
//	public Image Glases;

//	/// Makeup Items Image Here /// 

//	public Image Hair;
//	public Image Lens;
//	public Image LeftEyeShade;
//	public Image RightEyeShade;
//	public Image LeftEyeLiner;
//	public Image RightEyeLiner;
//	public Image LeftEyeLashes;
//	public Image RightEyeLashes;
//	public Image LeftCheekShade;
//	public Image RightCheekShade;
//	public Image Lips;
//	public Image EarRing;
//	public Image Necklace;
//	public Sprite[] bgsprites;
//	public GameObject Next;

//	public GameObject Background_Button;
//	int modelcounter=0;
//	int bgcounter=0;
//	public GameObject firework1,firework2,firework3;

//	#endregion

//	#region Lifecycle Methods

//	// Use this for initialization
//	void Start ()
//	{

//		Invoke ("SetViewContents", 0.2f);
//	}

//	// Update is called once per frame
//	void Update ()
//	{

//	}

//	void Destroy ()
//	{
//		iTween.Stop ();
//	}

//	#endregion



//	#region Utility Methods
//	private void SetViewContents ()
//	{


//	//	Destroy(firework1,2.0f);
//	//	Destroy(firework2,2.0f);
//	//	Destroy(firework3,2.0f);

//		SetCharacter ();
//		Invoke ("MoveButtonsIn", 5.0f);

//	}

//	private void SetCharacter ()
//	{

//		print ("character selected is:"+GameManager.instance.girlSelected);
//		switch (GameManager.instance.girlSelected) {
//		case 1:
//			GameManager.instance.selectedDressupBody = GameManager.instance.dressupModelBodyDataList [0] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupBody.getInGameImageName ());
//			GameManager.instance.selectedDressupArm = GameManager.instance.dressupModelArmDataList [0] as BaseItem;
//			arm.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupArm.getInGameImageName ());
//			GameManager.instance.selectedDressupHand = GameManager.instance.dressupModelHandDataList [0] as BaseItem;
//			hand.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupHand.getInGameImageName ());
//			GameManager.instance.selectedDressupEyes = GameManager.instance.dressupModelEyesDataList [0] as BaseItem;
//			CharacterEyes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupEyes.getInGameImageName ());
//			GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList [0] as BaseItem;
//			Dress.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			if (GameManager.instance.selectedHair != null) {
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.selectedHair.getInGameImageName ());
//			} else {
//				GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList [2] as BaseItem;
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			}
//			break;
//		case 2:
//			GameManager.instance.selectedDressupBody = GameManager.instance.dressupModelBodyDataList [1] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupBody.getInGameImageName ());
//			GameManager.instance.selectedDressupArm = GameManager.instance.dressupModelArmDataList [1] as BaseItem;
//			arm.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupArm.getInGameImageName ());
//			GameManager.instance.selectedDressupHand = GameManager.instance.dressupModelHandDataList [1] as BaseItem;
//			hand.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupHand.getInGameImageName ());
//			GameManager.instance.selectedDressupEyes = GameManager.instance.dressupModelEyesDataList [1] as BaseItem;
//			CharacterEyes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupEyes.getInGameImageName ());
//			GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList [1] as BaseItem;
//			Dress.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			if (GameManager.instance.selectedHair != null) {
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.selectedHair.getInGameImageName ());
//			} else {
//				GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList [3] as BaseItem;
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			}
//			break;
//		case 3:
//			GameManager.instance.selectedDressupBody = GameManager.instance.dressupModelBodyDataList [2] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupBody.getInGameImageName ());
//			GameManager.instance.selectedDressupArm = GameManager.instance.dressupModelArmDataList [2] as BaseItem;
//			arm.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupArm.getInGameImageName ());
//			GameManager.instance.selectedDressupHand = GameManager.instance.dressupModelHandDataList [2] as BaseItem;
//			hand.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupHand.getInGameImageName ());
//			GameManager.instance.selectedDressupEyes = GameManager.instance.dressupModelEyesDataList [2] as BaseItem;
//			CharacterEyes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupEyes.getInGameImageName ());
//			GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList [2] as BaseItem;
//			Dress.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			if (GameManager.instance.selectedHair != null) {
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.selectedHair.getInGameImageName ());
//			} else {
//				GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList [7] as BaseItem;
//				Hair.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			}
//			break;
//		default:
//			GameManager.instance.selectedDressupBody = GameManager.instance.dressupModelBodyDataList [0] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupBody.getInGameImageName ());
//			GameManager.instance.selectedDressupArm = GameManager.instance.dressupModelArmDataList [0] as BaseItem;
//			arm.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupArm.getInGameImageName ());
//			GameManager.instance.selectedDressupHand = GameManager.instance.dressupModelHandDataList [0] as BaseItem;
//			hand.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupHand.getInGameImageName ());
//			GameManager.instance.selectedDressupEyes = GameManager.instance.dressupModelEyesDataList [0] as BaseItem;
//			CharacterEyes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDressupEyes.getInGameImageName ());
//			GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList [0] as BaseItem;
//			Dress.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
//			break;
//		}
//		SetCharacterMakeupItems ();
//		SetCharacterDressUpItems ();


//		MoveAction (Character, CharacterEndPoint, 1.5f, iTween.EaseType.easeInOutBack);
//		//Invoke ("MoveButtonsIn", 1.5f);
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
//	private void RotateActionloop(GameObject obj,float rotationAmout,float time,iTween.EaseType actionType,iTween.LoopType loop)
//	{
//		Hashtable tweenParams = new Hashtable();
//		tweenParams.Add ("z", rotationAmout);
//		tweenParams.Add ("time", time);
//		tweenParams.Add ("easetype", actionType);
//		tweenParams.Add ("looptype", loop);
//		iTween.RotateTo(obj, tweenParams);

//	}
//	private void SetCharacterMakeupItems ()
//	{

//		if (GameManager.instance.selectedGirlHair != null) {
//			Hair.sprite = Resources.Load <Sprite> (GameManager.instance.selectedGirlHair.getInGameImageName ());
//			Hair.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedLens != null) {
//			Lens.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLens.getInGameImageName ());
//			Lens.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedLeftEyeShade != null) {
//			LeftEyeShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeShade.getInGameImageName ());
//			LeftEyeShade.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedRightEyeShade != null) {
//			RightEyeShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeShade.getInGameImageName ());
//			RightEyeShade.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedLeftEyeLiner != null) {
//			LeftEyeLiner.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeLiner.getInGameImageName ());
//			LeftEyeLiner.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedRightEyeLiner != null) {
//			RightEyeLiner.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeLiner.getInGameImageName ());
//			RightEyeLiner.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedLeftEyeLashTypeOne != null) {
//			LeftEyeLashes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeLashTypeOne.getInGameImageName ());	
//			LeftEyeLashes.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedRightEyeLashTypeOne != null) {
//			RightEyeLashes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeLashTypeOne.getInGameImageName ());	
//			RightEyeLashes.gameObject.SetActive (true);

//		}
//		if (GameManager.instance.selectedLeftCheekShade != null) {
//			LeftCheekShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftCheekShade.getInGameImageName ());
//			LeftCheekShade.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedRightCheekShade != null) {
//			RightCheekShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightCheekShade.getInGameImageName ());
//			RightCheekShade.gameObject.SetActive (true);

//		}
//		if (GameManager.instance.selectedLips != null) {
//			Lips.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLips.getInGameImageName ());
//			Lips.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedEarRing != null) {
//			EarRing.sprite = Resources.Load <Sprite> (GameManager.instance.selectedEarRing.getInGameImageName ());
//			EarRing.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedNecklace != null) {
//			Necklace.sprite = Resources.Load <Sprite> (GameManager.instance.selectedNecklace.getInGameImageName ());
//			Necklace.gameObject.SetActive (true);
//		}
//		//if (GameManager.instance.selectedhairband != null) {
//		//	HeadStyle.sprite = Resources.Load <Sprite> (GameManager.instance.selectedhairband.getInGameImageName ());
//		//	HeadStyle.gameObject.SetActive (true);
//		//}

//	}
//	private void SetCharacterDressUpItems ()
//	{

//		if (GameManager.instance.selectedDress != null) {
//			Dress.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDress.getInGameImageName ());
//			Dress.gameObject.SetActive (true);
//			print ("name of image is "+Dress.sprite.name);
//		}
//		if (GameManager.instance.selectedPent != null) {
//			Pent.sprite = Resources.Load <Sprite> (GameManager.instance.selectedPent.getInGameImageName ());
//			Pent.gameObject.SetActive (true);
//			print ("name of image is "+Pent.sprite.name);
//		}
//		if (GameManager.instance.selectedShoes != null) {
//			Shoes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedShoes.getInGameImageName ());
//			print ("name of image is "+Shoes.sprite.name);
//			Shoes.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.selectedGirlNecklace != null) {
//			Necklace.sprite = Resources.Load <Sprite> (GameManager.instance.selectedGirlNecklace.getInGameImageName ());
//			Necklace.gameObject.SetActive (true);
//			print ("name of image is "+Necklace.sprite.name);
//		}
//		if (GameManager.instance.selectedGlases != null) {
//			Glases.sprite = Resources.Load <Sprite> (GameManager.instance.selectedGlases.getInGameImageName ());
//			Glases.gameObject.SetActive (true);
//			print ("name of image is "+Glases.sprite.name);
//		}
//		if (GameManager.instance.selectedHandBag != null) {
//			Bag.sprite = Resources.Load <Sprite> (GameManager.instance.selectedHandBag.getInGameImageName ());
//			Bag.gameObject.SetActive (true);
//			print ("name of image is "+Bag.sprite.name);
//		}

//	}


//	private void MoveButtonsIn ()
//	{
//		firework1.GetComponent<ParticleSystem> ().Stop ();
//		firework2.GetComponent<ParticleSystem> ().Stop ();
//		firework3.GetComponent<ParticleSystem> ().Stop ();

//		MoveAction (MenuButtons, ButtonsEndPoint, 1.0f, iTween.EaseType.easeInOutBounce);
//	}

//	private void ScaleAction (GameObject obj, float ScaleFactor, float time, iTween.EaseType type)
//	{
//		Hashtable tweenParams = new Hashtable ();
//		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
//		tweenParams.Add ("time", 0.5f);
//		tweenParams.Add ("easetype", type);
//		iTween.ScaleTo (obj, tweenParams);
//	}
//	private void setbackgrounds ()
//	{
//		Background.sprite = bgsprites [0];
//		bgsprites [0] = bgsprites [1];
//		bgsprites [1] = bgsprites [2];
//		bgsprites [2] = bgsprites [0];

//	}

//	#endregion

//	#region Callback Methods
//	public void girlModelingClick()
//	{
//		SoundManager.instance.PlayButtonClickSound ();
//		modelcounter = modelcounter % 2;

//		if (modelcounter == 0) {
//			Character.transform.eulerAngles = new Vector3 (180.0f, 0.0f, 180.0f);
//		}
//		if(modelcounter==1){
//			Character.transform.eulerAngles = new Vector3 (0.0f,0.0f,0.0f);

//		} 
//		modelcounter++;
//	}
//	public void onClickBg()
//	{
//		SoundManager.instance.PlayButtonClickSound ();
//		Background.sprite = bgsprites [bgcounter];
//		if (bgcounter >= 2) {
//			bgcounter = 0;
//		} else {
//			bgcounter ++;
//		}

//	}
//	public void onClickNext()
//	{
//		SoundManager.instance.PlayButtonClickSound ();
//		if (PlayerPrefs.GetInt ("levelselection") < 5) {
//			PlayerPrefs.SetInt ("levelselection", 5);
//			print ("value of the opened level"+PlayerPrefs.GetInt ("levelselection"));
//		}
//		NavigationManager.instance.ReplaceScene (GameScene.PHOTOSHOOT);

//	}
//	#endregion
//}