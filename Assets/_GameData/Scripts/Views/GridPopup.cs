using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridPopup : MonoBehaviour {

	#region Variables, Constants & Initializers

	public GameObject scrollView;
	public Image hat;
	public Image glasses;
	public Image beardStyle;

	private RectTransform rectTransform;
	private Vector3 startPosition;

	#endregion

	#region Lifecycle Methods

	// Use this for initialization
	void Start () {
		rectTransform = this.gameObject.GetComponent<RectTransform> ();
		startPosition = this.rectTransform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#endregion

	#region Utility Methods

	private void SetScrollViewItems(ArrayList itemsList) {
		GameObject itemObject;
		for (int i = 0; i < scrollView.transform.childCount; i++) {
			itemObject = scrollView.transform.GetChild (i).gameObject;
			if (itemObject != null) {
				if (i >= itemsList.Count) {
					itemObject.SetActive (false);
				} else {
					itemObject.SetActive (true);

					itemObject.GetComponent<Button> ().onClick.RemoveAllListeners ();

					BaseItem item = itemsList [i] as BaseItem;
					itemObject.GetComponent<Button> ().onClick.AddListener (() => OnGridItemSelected(item));
					itemObject.transform.Find ("Image").GetComponent<Image> ().sprite = Resources.Load <Sprite>(item.getGridImagePath());
				}
			}
		}
	}

	#endregion

	#region Callback Methods

	public void ShowGridView(ArrayList itemsList) {
		if (this.rectTransform.localPosition != startPosition) {
			return;
		}

		SetScrollViewItems (itemsList);

		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("position", Vector3.zero);
		tweenParams.Add ("time", 0.5f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInOutQuad);
		iTween.MoveTo(this.gameObject, tweenParams);
	}

	public void HideGridView() {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", -10f);
		tweenParams.Add ("time", 0.5f);
		tweenParams.Add ("easetype", iTween.EaseType.easeInOutQuad);
		tweenParams.Add ("oncompletetarget", gameObject);
		tweenParams.Add ("oncomplete", "MoveToStratPoint");
		iTween.MoveTo(this.gameObject, tweenParams);
	}

	public void MoveToStratPoint() {
		this.rectTransform.localPosition = startPosition;
	}

	public void OnGridItemSelected(BaseItem selectedItem) {
		switch (selectedItem.baseName) {
		case "Hat":
			Debug.Log (selectedItem.getInGameImageName ());
			hat.sprite = Resources.Load <Sprite> (selectedItem.getInGameImageName ());
			hat.gameObject.SetActive (true);
			break;
		case "Glasses":
			glasses.sprite = Resources.Load <Sprite> (selectedItem.getInGameImageName ());
			glasses.gameObject.SetActive (true);
			break;
		case "BeardStyle":
			beardStyle.sprite = Resources.Load <Sprite> (selectedItem.getInGameImageName ());
			beardStyle.gameObject.SetActive (true);
			break;
		}

	

		HideGridView ();
	}

	#endregion
}
