//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using System.Collections.Generic;
//using System.Linq;
//using System;

//public class SpaView : MonoBehaviour {


//	#region Variables,Constants & Initializers
//	public GameObject firework1, firework2, firework3;
//	private bool flagShower=true;
//	public GameObject[] Chunks;
//	public MaskCamera MaskGameObject;
//	public GameObject animatedHand;
//	public GameObject Character;
//	public Sprite[] Clothes;
//	public RectTransform CharacterEndPoint;
//	public Image CharacterBody;
//	public Image CharacterEyes;
//	public Image CharacterCloth;
//	public Image CharacterLips;
//	public RectTransform chunksstartposition,chunksendposition,chunksmidposition;
//	public GameObject PimpleRemover;
//	public GameObject HairPlucker;
//	public RectTransform HairPluckerEndPoint;
//	public Image dustlayer;
//	public Image droplayer;
//	public GameObject cucumberTray;
//	public GameObject CucumberLeft;
//	public GameObject CucumberRight;
//	public GameObject CucumberPlate1;
//	public GameObject CucumberPlate2;
//	public RectTransform CucumberPlate1StartPoint;
//	public RectTransform CucumberPlate2StartPoint;
//	public GameObject TubeTool;
//	public GameObject TubeUsed;
//	public GameObject TubeApplicator;
//	public Image Mask;
//	public Image bodyMask;
//	private int pimpleCounter=0;
//	public Sprite SoapMask;
//	public Sprite GreenMask;
//	public Sprite ApricoatMask;
//	public GameObject NextButton;
//	public Image spotLayer;
//	public GameObject removerparticles;
//	public Sprite tableshower;
//	public Sprite usedShower;
//	public GameObject Shower;
//	public GameObject movePoints;
//	#endregion

//	#region Lifecycle Methods

//	// Use this for initialization
//	void Start () {
//		Invoke ("SetViewContents", 0.2f);
//	}

//	// Update is called once per frame
//	void Update () {

//	}

//	void Destroy() {
//		iTween.Stop ();
//	}

//	#endregion

//	#region Utility Methods

//	private void SetViewContents() {

//		GameManager.instance.currentScene = Utils.CURRENT_SCENE_SPA;
//		flagShower = false;
//		SetCharacter (GameManager.instance.girlSelected);
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
//	private void ChunkFourMovement()
//	{
//		print ("-----22");
//		MoveAction (Chunks [3], chunksstartposition, 5.0f, iTween.EaseType.linear);

//	}
//	private void SetCharacter(int selected)
//	{
//		print ("girl selected is"+GameManager.instance.girlSelected);
//		switch (selected)
//		{
//		case 1:
//			GameManager.instance.selectedCharacter = GameManager.instance.characterBodyDataList[0] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedCharacter.getInGameImageName ());
//			break;
//		case 2:
//			GameManager.instance.selectedCharacter = GameManager.instance.characterBodyDataList[1] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedCharacter.getInGameImageName ());
//			break;
//		case 3:
//			GameManager.instance.selectedCharacter = GameManager.instance.characterBodyDataList[2] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedCharacter.getInGameImageName ());
//			break;
//		default:
//			GameManager.instance.selectedCharacter = GameManager.instance.characterBodyDataList [0] as BaseItem;
//			CharacterBody.sprite = Resources.Load <Sprite> (GameManager.instance.selectedCharacter.getInGameImageName ());
//			break;
//		}


//		MoveAction (Character, CharacterEndPoint, 1.5f, iTween.EaseType.easeInOutBack);
//		ClearCurrentMask ();

//		//Invoke ("ShowNextButton", 4.0f);
//	}

//	private void ShowNextButton()
//	{
//		NextButton.SetActive (true);
//	}

//	private void ShowHairPlucker()
//	{
//		//HairPlucker.transform.position = HairPluckerEndPoint.position;
//	    HairPlucker.GetComponent<BoxCollider2D> ().enabled = true;
//		HairPlucker.GetComponent<ApplicatorListener> ().enabled = true;
//		HairPlucker.GetComponent<Image> ().color =Vector4.one;
//		HairPlucker.transform.GetChild (0).gameObject.SetActive (false);

//	}

//	private void ScaleAction(GameObject obj,float ScaleFactor,float time,iTween.EaseType type) {
//		Hashtable tweenParams = new Hashtable();
//		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
//		tweenParams.Add ("time", 0.5f);
//		tweenParams.Add ("easetype",type);
//		iTween.ScaleTo(obj, tweenParams);
//	}
		


//	IEnumerator FadeOutAction (Image img)
//	{
//		if (img.color.a >0) {
//			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.1f);
//			yield return new WaitForSeconds (0.1f);
//			StartCoroutine (FadeOutAction (img));
//		} else if (img.color.a < 0) {
//			//Debug.Log ("Fade Out ACTION Stopped");
//			StopCoroutine (FadeOutAction (img));

//		//	ParticleManger.instance.showStarParticle ();

//			ClearCurrentMask ();
//			img.color = new Vector4 (img.color.r,img.color.g,img.color.b,1);
//		}
//	}
//	IEnumerator alphaDecreases (Image img)
//	{
//		if (img.color.a >0) {
//			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.05f);
//			yield return new WaitForSeconds (0.1f);
//			StartCoroutine (alphaDecreases (img));
//		} else if (img.color.a < 0) {
//			//Debug.Log ("Fade Out ACTION Stopped");
//			StopCoroutine (alphaDecreases (img));

		
//		}
//	}
//	#endregion

//	#region Callback Methods

//	public void onTouchBeganMaskApplicator()
//	{
//		cucumberFallDown ();

//		GameManager.instance.canDrawMask = true;

//		if (GameManager.instance.maskname == "SpongeSoap") {
//			bodyMask.gameObject.SetActive (false);
//			Mask.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.maskname == "MaskBrush") {
//			bodyMask.gameObject.SetActive (false);
//			Mask.gameObject.SetActive (true);
//		}
//		if (GameManager.instance.maskname == "AppricotCreamBrush") {
//			bodyMask.gameObject.SetActive (false);
//			Mask.gameObject.SetActive (true);
//		}
//		if(GameManager.instance.maskname == "TubeApplicator")
//		{
//			animatedHand.SetActive (false);
//			TubeUsed.SetActive (false);
//			TubeTool.SetActive (true);
//			Mask.gameObject.SetActive (false);
//			bodyMask.gameObject.SetActive (true);

//		}
//	}

//	public void onTouchEndMaskApplicator()
//	{
//		GameManager.instance.canDrawMask = false;
//		if(GameManager.instance.maskname == "TubeApplicator")
//		{
//			TubeApplicator.SetActive (false);

//		}
//		flagShower = true;
//	}

//	public void ClearCurrentMask()
//	{
//		MaskGameObject.shouldClearRender = true;
//		SetFaceMask ();
//	}

//	public void OnTouchBeganShower()
//	{
//		cucumberFallDown ();
//		if (GameManager.instance.Showerused.name == "Shower1") {
//			droplayer.gameObject.SetActive (true);
//		}
//		GameManager.instance.Showerused.GetComponent<Image> ().sprite = tableshower;
//		GameManager.instance.Showerused.GetComponent<Image> ().SetNativeSize ();
//		SoundManager.instance.PlayShowerMusic (true);
//		GameManager.instance.canDrawMask = false;
//	}

//	public void OnTouchEndShower()
//	{
//		SoundManager.instance.PlayShowerMusic (false);
//		GameManager.instance.Showerused.GetComponent<Image> ().sprite = usedShower;
//		GameManager.instance.Showerused.GetComponent<Image> ().SetNativeSize ();
//		Debug.Log (Mask.color.a);
//		if (Mask.color.a == 0) {
//			SetFaceMask ();
//		}
//	}

//	public void OnCollisionShowerWithMask()
//	{
//		if (flagShower && (Mask.color.a>0)) {
//			StartCoroutine(FadeOutAction (Mask));
//			flagShower = false;
//		}
//	}
//	public void OnCollisionShowerWithSpotRemover()
//	{
//		if (spotLayer.color.a> 0) {
//			StartCoroutine(alphaDecreases (spotLayer));

//		}
//	}
//	public void OnCollisionShowerWithDust()
//	{
//		if (dustlayer.color.a> 0) {
//			StartCoroutine(alphaDecreases (dustlayer));

//		}
//	}
//	public void OnCollisionSteamerWithDropsLayer()
//	{
//		if (droplayer.color.a> 0) {
//			StartCoroutine(alphaDecreases (droplayer));

//		}
//	}
//	public void OnCollisionPimpleRemover()
//	{
//	       ++pimpleCounter;
//		if (pimpleCounter == 1) {
//			SoundManager.instance.PlayouchClickSound ();
//		}
//		if (pimpleCounter == 5) {
//			SoundManager.instance.PlayouchClickSound ();
//		}




//	}

//	public void OnCollisionHairPlucker()
//	{
//		SoundManager.instance.PlaypluckerClickSound ();
//		HairPlucker.GetComponent<Image> ().color =Vector4.zero;
//		HairPlucker.transform.GetChild (0).gameObject.SetActive (true);
//		Invoke ("ShowHairPlucker", 0.5f);
//	}

//	public void OnCollisionCucumber()
//	{
//		SoundManager.instance.PlaycucumberClickSound ();

//		int cucumberTag=Int32.Parse(GameManager.instance.currentTag);

//		Debug.Log (cucumberTag);

//		CucumberPlate1.transform.position = CucumberPlate1StartPoint.position;
//		CucumberPlate2.transform.position = CucumberPlate2StartPoint.position;
//		if (cucumberTag == 0) {
//			CucumberLeft.SetActive (true);
//		} if (cucumberTag == 1) {
//			CucumberRight.SetActive (true);
//		}

//		//ParticleManger.instance.showStarParticle ();
//	}
//	public void SetFaceMask()
//	{
		
//		Mask.color = new Vector4 (1, 1, 1, 1);

//		if (GameManager.instance.maskname == "SpongeSoap") {
//			Mask.sprite = SoapMask;
//		}
//		if (GameManager.instance.maskname == "MaskBrush") {
//			Mask.sprite = GreenMask;
//		}
//		if (GameManager.instance.maskname == "AppricotCreamBrush") {
//			Mask.sprite = ApricoatMask;
//		}
//		if (GameManager.instance.maskname == "TubeApplicator") {
//			Mask.sprite = null;
//		}
//		print ("the name of the mask is:"+GameManager.instance.maskname);
//	}
//	public void cucumberFallDown()
//	{
//		if (CucumberLeft.activeSelf && CucumberRight.activeSelf) {
//			CucumberLeft.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
//			CucumberLeft.GetComponent<Rigidbody2D> ().gravityScale = 1;
//			CucumberRight.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
//			CucumberRight.GetComponent<Rigidbody2D> ().gravityScale = 1;
//			Invoke ("CucumberPositioning", 2.0f);
//		}

//	}
//	public void CucumberPositioning()
//	{
//		CucumberPlate1.GetComponent<RectTransform> ().position = new Vector3(CucumberPlate1StartPoint.position.x,CucumberPlate1StartPoint.position.y,CucumberPlate1StartPoint.position.z);
//		CucumberPlate2.GetComponent<RectTransform> ().position =  new Vector3(CucumberPlate2StartPoint.position.x,CucumberPlate2StartPoint.position.y,CucumberPlate2StartPoint.position.z);;
//		CucumberPlate1.SetActive (true);
//		CucumberPlate1.transform.SetParent (cucumberTray.transform);
//		CucumberPlate2.SetActive (true);
//		CucumberPlate2.transform.SetParent (cucumberTray.transform);
//		CucumberPlate1.GetComponent<ApplicatorListener> ().enabled = false;
//		CucumberPlate2.GetComponent<ApplicatorListener> ().enabled = false;
//	}
//	public void onClickTubeTool()
//	{
//		movePoints.transform.SetAsLastSibling ();
//		cucumberFallDown ();
//		TubeTool.SetActive (false);
//		TubeUsed.SetActive (true);
//		animatedHand.SetActive (true);
//		TubeApplicator.SetActive (true);

//	}
//	public void spotremoverBeginDrag()
//	{
//		removerparticles.SetActive (true);

//	}
//	public void spotremoverEndDrag()
//	{
//		removerparticles.SetActive (false);


//	}
//	public void steamerbeginDrag()
//	{
//		SoundManager.instance.PlaySteamerMusic (true);

//	}
//	public void steamerEndDrag()
//	{

//		SoundManager.instance.PlaySteamerMusic (false);

//	}
//	public void OnNextClick()
//	{
//	 	SoundManager.instance.PlayButtonClickSound ();
//		NextButton.GetComponent<Image> ().enabled = false;
//		firework1.SetActive (true);
//		firework2.SetActive (true);
//		firework3.SetActive (true);

//		if (PlayerPrefs.GetInt ("levelselection") < 1) {
//			PlayerPrefs.SetInt ("levelselection", 1);
//			print ("value of the opened level"+PlayerPrefs.GetInt ("levelselection"));
//		}
//		Invoke ("LoadScene", 4.0f);
//	}
//	public void LoadScene()
//	{
//		NextButton.SetActive (false);
//		firework1.GetComponent<ParticleSystem> ().Stop ();
//		firework2.GetComponent<ParticleSystem> ().Stop ();
//		firework3.GetComponent<ParticleSystem> ().Stop ();
//		NavigationManager.instance.ReplaceScene (GameScene.MAKEUP);
//	}
//	#endregion
//}
