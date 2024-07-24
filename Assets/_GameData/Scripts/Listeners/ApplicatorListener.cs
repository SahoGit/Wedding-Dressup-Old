using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ApplicatorListener : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	#region Variables, Constants & Initializers
	public GameObject nextBtn;
	public GameObject skipBtn;


	public Button.ButtonClickedEvent onEnterCollider;
	public Button.ButtonClickedEvent onExitCollider;
	public Button.ButtonClickedEvent onStayingCollider;
	public Button.ButtonClickedEvent onTouchBegan;
	public Button.ButtonClickedEvent onTouchEnd;

	private RectTransform rectTransform;
	private Image image;

	private bool isStayingInCollider;
	private Transform parent;
	private Vector2 anchorPos;
	private RectTransform rectTrans;

	private Vector3 startPosition;
	private Vector3 startRotation;

	#endregion
    // Use this for initialization
    void Start () {
		rectTransform = gameObject.GetComponent<RectTransform> ();
		startPosition = rectTransform.localPosition;
		startRotation = rectTransform.transform.eulerAngles;
		image = gameObject.GetComponent<Image> ();

	}
		
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (this.gameObject.tag.Equals ("jugparent")) {
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("front")) {
			this.gameObject.GetComponent<Button> ().enabled = false;
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("strawberry")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("banana")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("pineapple")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("peach")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("rabbitchoclate")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("yellowchoclate")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("beanchoclate")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("heartchoclate")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
//		if (this.gameObject.tag.Equals ("spoon")) {
//			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
//			parent = transform.parent;
//			transform.SetParent (transform.root);
//		}
		if (this.gameObject.tag.Equals ("lipstickremover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Cheekshaderemover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Eyeshaderemover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Eyelashremover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Eyelinerremover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Lipstick")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("lashbrush1")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("lashbrush2")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("lashbrush3")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("lashbrush4")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("lashbrush5")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("CheekShadeBrush")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("eyeshadebrush")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("eyelinerbrush")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("spotremover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("MaskApplicator")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			GameManager.instance.maskname = this.gameObject.name;
			if (onStayingCollider != null) {
				onStayingCollider.Invoke ();
			}
		}
//		if (this.gameObject.tag.Equals ("Shower")) {
//			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
//			parent = transform.parent;
//			transform.SetParent (transform.root);
//		}

		if (this.gameObject.tag.Equals ("Dryer")) {
			gameObject.transform.GetChild (0).transform.gameObject.SetActive (true);
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("Plucker")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("PimpleRemover")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Cucumber")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
		}
		if (this.gameObject.tag.Equals ("Shower")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			gameObject.transform.GetChild (0).transform.gameObject.SetActive (true);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}

		if (this.gameObject.tag.Equals ("MaskApplicator")) {
			
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("bottle")) {

			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("jar")) {
			anchorPos = GetComponent <RectTransform> ().anchoredPosition;
			parent = transform.parent;
			transform.SetParent (transform.root);
			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
		if (this.gameObject.tag.Equals ("lipstickmake")) {

			if (onTouchBegan != null) {
				onTouchBegan.Invoke ();
			}
		}
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		///////// Scenes Common Code Here //////////
		if (this.gameObject.tag.Equals ("jugparent")) {
			if (onTouchEnd != null) {
				onTouchEnd.Invoke ();
			} 
		}
		if (this.gameObject.tag.Equals ("front")) {
			this.gameObject.GetComponent<Button> ().enabled = true;
			if (onTouchEnd != null) {
				onTouchEnd.Invoke ();
			} 
		}else {
				if (this.gameObject.tag.Equals ("bottle")) {
					if (onTouchEnd != null) {
						onTouchEnd.Invoke ();
					}
				}
				if (this.gameObject.tag.Equals ("jar")) {
				 GetComponent <RectTransform> ().anchoredPosition = anchorPos;
				 transform.SetParent (parent);
					if (onTouchEnd != null) {
						onTouchEnd.Invoke ();
					}
				}
				if (this.gameObject.tag.Equals ("lipstickmake")) {
					if (onTouchEnd != null) {
						onTouchEnd.Invoke ();
					}
				}
				//Fruits End Drag
				if (this.gameObject.tag.Equals ("strawberry")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("pineapple")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("banana")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("peach")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("rabbitchoclate")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("yellowchoclate")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("beanchoclate")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("heartchoclate")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}

				if (this.gameObject.tag.Equals ("lipstickremover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("Cheekshaderemover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("Eyelashremover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("Eyeshaderemover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("Eyelinerremover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("Lipstick")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
					nextBtn.SetActive(true);
				if(skipBtn!=null)
					skipBtn.SetActive(false);
				//if (PlayerPrefs.GetInt("UnlimitedMode") == 1 || PlayerPrefs.GetInt("CareerMode") == 1)
				//{
				//    nextBtn.SetActive(true);
				//}
			}
				if (this.gameObject.tag.Equals ("eyeshadebrush")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
					nextBtn.SetActive(true);

				if (skipBtn != null)
					skipBtn.SetActive(false);
				//if (PlayerPrefs.GetInt("UnlimitedMode") == 1 || PlayerPrefs.GetInt("CareerMode") == 1)
				//{
				//    nextBtn.SetActive(true);
				//}
			}
				if (this.gameObject.tag.Equals ("CheekShadeBrush")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
					nextBtn.SetActive(true);

				if (skipBtn != null)
					skipBtn.SetActive(false);
				//if (PlayerPrefs.GetInt("UnlimitedMode") == 1 || PlayerPrefs.GetInt("CareerMode") == 1)
				//{
				//    nextBtn.SetActive(true);
				//}
			}
				if (this.gameObject.tag.Equals ("eyelinerbrush")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("MaskApplicator")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);

				}
				if (this.gameObject.tag.Equals ("lashbrush1")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("lashbrush2")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("lashbrush3")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("lashbrush4")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}
				if (this.gameObject.tag.Equals ("lashbrush5")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					isStayingInCollider = false;
				}


	
				if (this.gameObject.tag.Equals ("Shower")) {
//					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
//					transform.SetParent (parent);
//					if (this.gameObject.name == "Shower3") {
//						if (onExitCollider != null) {
//							onExitCollider.Invoke ();
//						}
//					}
				}
				if (this.gameObject.tag.Equals ("spotremover")) {
				this.gameObject.transform.GetChild (0).gameObject.SetActive (false);
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					if (this.gameObject.name == "spotremover") {
						if (onExitCollider != null) {
							onExitCollider.Invoke ();
						}
					}
				}

				if (this.gameObject.tag.Equals ("Dryer")) {
					gameObject.transform.GetChild (0).transform.gameObject.SetActive (false);
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
					if (onTouchEnd != null) {
						onTouchEnd.Invoke ();
					}

				}
				if (this.gameObject.tag.Equals ("Plucker")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("PimpleRemover")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("Cucumber")) {
					GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					transform.SetParent (parent);
				}
				if (this.gameObject.tag.Equals ("Chunk")) {
					if (onTouchEnd != null) {
						onTouchEnd.Invoke ();
					}
				} else {
					if (this.gameObject.tag.Equals ("front")) {
						if (onTouchEnd != null) {
							onTouchEnd.Invoke ();
						}
					}
					if (this.gameObject.tag.Equals ("Shower")) {
						gameObject.transform.GetChild (0).transform.gameObject.SetActive (false);
					    GetComponent <RectTransform> ().anchoredPosition = anchorPos;
					    transform.SetParent (parent);
					if (this.gameObject.name == "Shower3") {
						if (onExitCollider != null) {
							onExitCollider.Invoke ();
						}
					}
						if (onTouchEnd != null) {
							onTouchEnd.Invoke ();
						}
						//SoundManager.instance.PlayShowerLoop (false);
					}
					if (this.gameObject.tag.Equals ("MaskApplicator")) {
						if (onTouchEnd != null) {
							onTouchEnd.Invoke ();
						}
					}

					rectTransform.localPosition = startPosition;
					rectTransform.transform.eulerAngles = startRotation;
				}

			}


				isStayingInCollider = false;


			}
		
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{

		rectTransform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		rectTransform.position = new Vector3 (rectTransform.position.x, rectTransform.position.y, 0);


		if (isStayingInCollider) {

			//////  Hair Style View Code here //////////


			///  Spa View Code here //////////

			if (this.gameObject.tag == "Shower") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
			if (this.gameObject.tag == "spotremover") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
		}
			
	}

	#endregion

    #region Collision Detector Methods



    void OnCollisionEnter2D(Collision2D collision)
    {


		//if (collision.gameObject.tag == "jar") {
		//	if (this.gameObject.tag == "strawberry" || this.gameObject.tag == "pineapple" || this.gameObject.tag == "banana" || this.gameObject.tag == "peach" || this.gameObject.tag == "rabbitchoclate" || this.gameObject.tag == "yellowchoclate" || this.gameObject.tag == "beanchoclate" || this.gameObject.tag == "heartchoclate") {
				
		//		transform.SetParent (parent);
		//		this.gameObject.GetComponent<Collider2D> ().enabled = false;
		//		this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "EmptyLipstick") {
		//	if (this.gameObject.tag == "lipstickmake") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "tube") {
		//	if (this.gameObject.tag == "jar") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "jar") {
		//	if (this.gameObject.tag == "spoon") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "jar") {
		//	if (this.gameObject.tag == "bottle") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}

		//if (collision.gameObject.tag == "MaskCollider") {
		//	if (this.gameObject.tag == "Shower") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "dust") {
		//	if (this.gameObject.tag == "Shower") {
		//		if (onStayingCollider != null) {
		//			onStayingCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "dropslayer") {
		//	if (this.gameObject.tag == "Dryer") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "spotlayer") {
		//	if (this.gameObject.tag == "spotremover") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "EyeShade") {
		//	if (this.gameObject.tag == "Eyeshaderemover") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "Eyelashremover") {
				
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyeliner") {
		//	if (this.gameObject.tag == "Eyelinerremover") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "cheekshade") {
		//	if (this.gameObject.tag == "Cheekshaderemover") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "Lips") {
		//	if (this.gameObject.tag == "lipstickremover") {
		//		print ("the name of game object is"+collision.gameObject.name);
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "lipsbloss") {
		//	if (this.gameObject.tag == "lipstickremover") {
		//		print ("the name of game object is"+collision.gameObject.name);
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}

		if(collision.gameObject.tag == "2x" && collision.gameObject.tag == "4x" && collision.gameObject.tag == "6x")
		{
			if(this.gameObject.tag == "MoveDimond")
			{
				Debug.Log("Collison Check is working or Not!!!");
				if (onEnterCollider != null)
				{
					onEnterCollider.Invoke ();
				}
			}
		}
		

		if (collision.gameObject.tag == "Lips") {
			if (this.gameObject.tag == "Lipstick") {
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		//if (collision.gameObject.tag == "lipsbloss") {
		//	if (this.gameObject.tag == "Lipstick") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		if (collision.gameObject.tag == "EyeShade") {
			if (this.gameObject.tag == "eyeshadebrush") {
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		if (collision.gameObject.tag == "cheekshade") {
			if (this.gameObject.tag == "CheekShadeBrush") {
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		//if (collision.gameObject.tag == "eyeliner") {
		//	if (this.gameObject.tag == "eyelinerbrush") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "lashbrush1") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "lashbrush2") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "lashbrush3") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "lashbrush4") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
		//if (collision.gameObject.tag == "eyelash") {
		//	if (this.gameObject.tag == "lashbrush5") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}
			//if (collision.gameObject.tag == "Shampoo") {
			//	if (this.gameObject.tag == "Dryer") {
					
			//		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;

			//		if (onEnterCollider != null) {
			//			onEnterCollider.Invoke ();
			//		}
			//	}
			//}


		////   Table Collision Code Here ////////

		//if (collision.gameObject.tag == "ChunkLeftCollider") {
		//	if (this.gameObject.tag == "Chunk") {

		//		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		//		this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}

		//if (collision.gameObject.tag == "ChunkRightCollider") {
		//	if (this.gameObject.tag == "Chunk") {

		//		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		//		this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
		//		if (onStayingCollider != null) {
		//			onStayingCollider.Invoke ();
		//		}
		//	}
		//}


		//////  Shower Code here //////////

		//if (collision.gameObject.tag == "Bubble") {
		//	if (this.gameObject.tag == "Shower") {
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}

		////// Spa View Code here //////////

		//if (collision.gameObject.tag == "Pimple") {
		//	if (this.gameObject.tag == "PimpleRemover") {

		//		collision.gameObject.SetActive (false);
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}

		//	}
		//}

		//if (collision.gameObject.tag == "PluckerHair") {
		//	if (this.gameObject.tag == "Plucker") {

		//	//	this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
		//		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		//		collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;

		//		collision.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;

		//		collision.gameObject.GetComponent<Rigidbody2D>().gravityScale=1;
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//	}
		//}

		//if (collision.gameObject.tag == "0"  || collision.gameObject.tag == "1") {
		//	if (this.gameObject.tag == "Cucumber") {

		//		GameManager.instance.currentTag = collision.gameObject.tag;
		//		collision.gameObject.SetActive (false);
		//		if (onEnterCollider != null) {
		//			onEnterCollider.Invoke ();
		//		}
		//		this.gameObject.SetActive (false);

		//	}
		//}
	}

	int stayCount = 0;
	public int stayMax = 10;
	void OnCollisionStay2D(Collision2D collision)
	{
		if (stayCount % stayMax != 0)
        {
			stayCount++;
			return;
        }
        else
        {
			stayCount++;
		}
		//////  MakeUP View Code here //////////
			
	//	if (collision.gameObject.tag == "eyelash") {
	//		if (this.gameObject.tag == "Eyelashremover") {
	//			this.isStayingInCollider = true;
	//			if (onStayingCollider != null) {
	//				onStayingCollider.Invoke ();
	//			}
	//		}
	//	}
	//	if (collision.gameObject.tag == "EyeShade") {
	//		if (this.gameObject.tag == "Eyeshaderemover") {
	//			this.isStayingInCollider = true;
	//			if (onStayingCollider != null) {
	//				onStayingCollider.Invoke ();
	//			}
	//		}
	//	}
	//    if (collision.gameObject.tag == "eyeliner") {
	//	if (this.gameObject.tag == "Eyelinerremover") {
	//		this.isStayingInCollider = true;
	//		if (onStayingCollider != null) {
	//			onStayingCollider.Invoke ();
	//		}
	//	}
	//}
	//	if (collision.gameObject.tag == "cheekshade") {
	//		if (this.gameObject.tag == "Cheekshaderemover") {
	//			this.isStayingInCollider = true;
	//			if (onStayingCollider != null) {
	//				onStayingCollider.Invoke ();
	//			}
	//		}
	//	}
	//	if (collision.gameObject.tag == "Lips") {
	//		if (this.gameObject.tag == "lipstickremover") {
	//			this.isStayingInCollider = true;
	//			if (onStayingCollider != null) {
	//				onStayingCollider.Invoke ();
	//			}
	//		}
	//	}
	//	if (collision.gameObject.tag == "lipsbloss") {
	//		if (this.gameObject.tag == "lipstickremover") {
	//			this.isStayingInCollider = true;
	//			if (onStayingCollider != null) {
	//				onStayingCollider.Invoke ();
	//			}
	//		}
	//	}
		if (collision.gameObject.tag == "Lips") {
			if (this.gameObject.tag == "Lipstick") {
				this.isStayingInCollider = true;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
		}
        //if (collision.gameObject.tag == "lipsbloss") {
        //	if (this.gameObject.tag == "Lipstick") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        if (collision.gameObject.tag == "EyeShade")
        {
            if (this.gameObject.tag == "eyeshadebrush")
            {
                this.isStayingInCollider = true;
                if (onStayingCollider != null)
                {
                    onStayingCollider.Invoke();
                }
            }
        }
        if (collision.gameObject.tag == "cheekshade")
        {
            if (this.gameObject.tag == "CheekShadeBrush")
            {
                this.isStayingInCollider = true;
                if (onStayingCollider != null)
                {
                    onStayingCollider.Invoke();
                }
            }
        }
        //if (collision.gameObject.tag == "eyeliner") {
        //	if (this.gameObject.tag == "eyelinerbrush") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush1") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush2") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush3") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush4") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush5") {
        //		this.isStayingInCollider = true;
        //		if (onStayingCollider != null) {
        //			onStayingCollider.Invoke ();
        //		}
        //	}
        //}
        /////  Spa View Code here //////////
        //if (collision.gameObject.tag == "MaskCollider") {
        //	if (this.gameObject.tag == "Shower") {
        //		isStayingInCollider = true;
        //	}
        //}
        //if (collision.gameObject.tag == "spotremover") {
        //	if (this.gameObject.tag == "spotlayer") {
        //		isStayingInCollider = true;
        //	}
        //}

    }
	
	void OnCollisionExit2D(Collision2D collision)
	{
		isStayingInCollider = false;
		if (collision.gameObject.tag == "Lips") {
			if (this.gameObject.tag == "Lipstick") {
				this.isStayingInCollider = false;
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
                    //SoundManager.instance.PlayniceColorSound();
                }
			}

		}
        //if (collision.gameObject.tag == "lipsbloss") {
        //	if (this.gameObject.tag == "Lipstick") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "Lips") {
        //	if (this.gameObject.tag == "lipstickremover") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        ////}
        //if (collision.gameObject.tag == "cheekshade")
        //{
        //    if (this.gameObject.tag == "Cheekshaderemover")
        //    {
        //        this.isStayingInCollider = false;
        //        if (onExitCollider != null)
        //        {
        //            onExitCollider.Invoke();
        //        }
        //    }

        //}
        //if (collision.gameObject.tag == "eyeliner") {
        //	if (this.gameObject.tag == "Eyelinerremover") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "Eyelashremover") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "EyeShade") {
        //	if (this.gameObject.tag == "Eyeshaderemover") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}

        if (collision.gameObject.tag == "EyeShade")
        {
            if (this.gameObject.tag == "eyeshadebrush")
            {
                this.isStayingInCollider = false;
                if (onExitCollider != null)
                {
                    onExitCollider.Invoke();
                }
            }

        }
        if (collision.gameObject.tag == "cheekshade")
        {
            if (this.gameObject.tag == "CheekShadeBrush")
            {
                this.isStayingInCollider = false;
                if (onExitCollider != null)
                {
                    onExitCollider.Invoke();
                }
            }

        }


        if (collision.gameObject.tag == "bigCollider")
        {
            SoundManager.instance.PlayChecksSound();
        }
        if (collision.gameObject.tag == "eyeBigCollider")
        {
            SoundManager.instance.PlayEyeLashSound();
        }
        if (collision.gameObject.tag == "Lips")
        {
            SoundManager.instance.PlayLipsSound(); ;
        }
        //if (collision.gameObject.tag == "eyeliner") {
        //	if (this.gameObject.tag == "eyelinerbrush") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush1") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush2") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush3") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush4") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
        //if (collision.gameObject.tag == "eyelash") {
        //	if (this.gameObject.tag == "lashbrush5") {
        //		this.isStayingInCollider = false;
        //		if (onExitCollider != null) {
        //			onExitCollider.Invoke ();
        //		}
        //	}

        //}
    }

    #endregion
}
