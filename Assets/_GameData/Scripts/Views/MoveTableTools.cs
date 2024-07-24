//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using System.Collections.Generic;
//public class MoveTableTools : MonoBehaviour {

//	#region Variables, Constants & Initializers

//	private int Chunk_Forward_Count;
//	private int Chunk_Backward_Count;
//	private int Chunk_Current;
//	private int LastClickGrid;

//	public List<GameObject> Total_No_Of_Chunks;
//	public RectTransform ChunkStartPoint;
//	public RectTransform ChunkMidPoint;
//	public RectTransform ChunkEndPoint;
//	public GameObject ChunkCollider;

//	public GameObject DotBar;
//	public GameObject Dot;
//	public List<RectTransform> DotPositions;

//	public List <GameObject> Total_No_Of_Grids;
//	public RectTransform GirdStartPoint;
//	public RectTransform GirdEndPoint;

//	public GameObject Applicators;
//	public GameObject CharacterItems;
//	public GameObject CharacterFaceItems;
//	public List <GameObject> TableItems;

////	public SpaView SpaViewObject;

//	public GameObject NextButton;

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

//	private void SetViewContents()
//	{
//		///// sets the Scrolls Count /////////

//		GameManager.instance.currentActiveScrollChunk = 0;
//		Chunk_Forward_Count = Total_No_Of_Chunks.Count-1;
//		Chunk_Backward_Count = 0;
//		Chunk_Current = 0;
//		LastClickGrid = -1;
//		Invoke ("StartMoveChunksIn", 1.0f);
//	}

//	/// <summary>
//	/// Moves Table Items In 
//	/// </summary>

//	private void StartMoveChunksIn()
//	{
//		StartCoroutine (MoveChunksIn());
//	}

//	IEnumerator MoveChunksIn()
//	{
//		Debug.Log ("In Move Chunks In");
//		for (int i = Total_No_Of_Chunks.Count-1; i >=0; i--) {
//			if (i == 0) {
//				MoveAction (Total_No_Of_Chunks [i], ChunkMidPoint, 0.3f, iTween.EaseType.linear);
//			} else {
//				MoveAction (Total_No_Of_Chunks [i], ChunkStartPoint, 0.4f, iTween.EaseType.linear);
//			}
//			yield return new WaitForSeconds(0.5f);
//		}

//		StopCoroutine (MoveChunksIn());
//		EnableChunkColliders ();


//		Debug.Log ("Move Chunks In Couroutine Stopped");
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


//	private void EnableChunkColliders()
//	{
//		DotBar.SetActive (true);
//		if (ChunkCollider != null) {
//			ChunkCollider.SetActive (true);
//		}
//		EnableCurrentChunkListener ();
//	}

//	private void EnableCurrentChunkListener()
//	{
//		///// Enable the Scrolls Listener and BOX COllider 2D /////////
 
//		Total_No_Of_Chunks [Chunk_Current].GetComponent<ApplicatorListener> ().enabled = true;
//		Total_No_Of_Chunks [Chunk_Current].GetComponent<BoxCollider2D> ().enabled = true;
//	}

//	private void HidePreviousChunk()
//	{
//		///// Hides Previous Scroll /////////

//		Total_No_Of_Chunks [Chunk_Current - 1].SetActive (false);
//	}

//	private void ShowCurrentChunk()
//	{
//		///// Shows Current Active Scroll /////////

//		Total_No_Of_Chunks [Chunk_Current].SetActive (true);
//	}

//	private void DestoryCharacterChilds(GameObject obj)
//	{
//		int childs = obj.transform.childCount;
//		for (int i = childs - 1; i >= 0; i--)
//		{
//			if (obj != null) {
//				GameObject.Destroy (obj.transform.GetChild (i).gameObject);
//			}
//		}
//	}
//	private void HideApplicators(GameObject obj)
//	{
//		int childs = obj.transform.childCount;
//		for (int i = childs - 1; i >= 0; i--)
//		{
//			obj.transform.GetChild(i).gameObject.SetActive(false);
//		}
//	}
//	private void ShowTableItems()
//	{
//		for (int i = 0; i <TableItems.Count;i++)
//		{
//			TableItems[i].gameObject.SetActive(true);
//		}
//	}

//	/// <summary>
//	/// Hides the Active Grids 
//	/// </summary>

//	private void MoveGridOut()
//	{
//		if (TableItems.Count!=0) {
//			ShowTableItems ();
//		}
//		if (Applicators != null) {
//			HideApplicators (Applicators);
//		}
//		if (CharacterItems != null) {
//			DestoryCharacterChilds (CharacterItems);
//		}
//		if (CharacterFaceItems != null && Chunk_Current>2) {
//			CharacterFaceItems.GetComponent<Image> ().color = new Vector4 (1, 1, 1, 0);
//		}
//		if (SpaViewObject != null) {
//			SpaViewObject.ClearCurrentMask ();
//		}

//		if (NextButton != null) {
//			if (Chunk_Current == Total_No_Of_Chunks.Count-1) {
//					NextButton.SetActive (true);
//				}
//		}

//		if (LastClickGrid == -1) {
			
//		} else {
//			MoveAction (Total_No_Of_Grids [LastClickGrid], GirdStartPoint, 0.5f, iTween.EaseType.easeInOutSine);
//		}
//	}
		
//	#endregion

//	#region Callback Methods

//	public void MoveChunkForward()
//	{
//		///// Move Scrolls To the Left Direction Of the Screen If Possbile OtherWise Move Back to the Center/////////

//		Debug.Log (Chunk_Forward_Count);
//		if (Chunk_Forward_Count > 0) {
//			MoveAction (Total_No_Of_Chunks [Chunk_Current], ChunkEndPoint, 0.3f, iTween.EaseType.linear);
//			Chunk_Current++;
//			MoveAction (Total_No_Of_Chunks [Chunk_Current], ChunkMidPoint, 0.3f, iTween.EaseType.linear);

//			GameManager.instance.currentActiveScrollChunk = Chunk_Current;
//			Dot.transform.localPosition = DotPositions [Chunk_Current].localPosition;

//			Chunk_Forward_Count--;
//			Chunk_Backward_Count++;
//			MoveGridOut ();
//			ShowCurrentChunk ();
//			Invoke ("EnableCurrentChunkListener", 0.5f);
//			Invoke ("HidePreviousChunk", 0.5f);
//		} else {
//			OnTouchEnd ();
//		}
//	}

//	public void MoveChunkBackward()
//	{
//		///// Move Scrolls To the Right Direction Of the Screen If Possbile OtherWise Move Back to the Center/////////

//		if (Chunk_Backward_Count > 0) {
//			MoveAction (Total_No_Of_Chunks [Chunk_Current], ChunkStartPoint, 0.3f, iTween.EaseType.linear);
//			Chunk_Current--;
//			MoveAction (Total_No_Of_Chunks [Chunk_Current], ChunkMidPoint, 0.3f, iTween.EaseType.linear);

//			GameManager.instance.currentActiveScrollChunk = Chunk_Current;
//			Dot.transform.localPosition = DotPositions [Chunk_Current].localPosition;

//			Chunk_Forward_Count++;
//			Chunk_Backward_Count--;
//			MoveGridOut ();
//			ShowCurrentChunk ();
//			Invoke ("EnableCurrentChunkListener", 0.5f);
//		} else {
//			OnTouchEnd ();
//		}
//	}

//	public void OnTouchEnd()
//	{
//		///// Move Scrolls Back to the Center When Touch is Released/////////

//         MoveAction (Total_No_Of_Chunks[Chunk_Current],ChunkMidPoint,0.3f,iTween.EaseType.linear);
//		Invoke ("EnableCurrentChunkListener", 0.3f);
//	}

//	/// <summary>
//	/// Move Selected Grid In /// 
//	/// </summary>

//	public void MoveGirdIn(int tag)
//	{
//		if (tag != LastClickGrid) {
//			SoundManager.instance.PlayButtonClickSound ();
//			MoveGridOut ();
//			Total_No_Of_Grids [tag].SetActive (true);
//			MoveAction (Total_No_Of_Grids [tag], GirdEndPoint, 0.5f, iTween.EaseType.easeInOutSine);
//			LastClickGrid = tag;

//		}
//	}


//	#endregion
//}