using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsibleBanner : MonoBehaviour
{
  void OnEnable()
  {
    //Debug.Log("--------first sceme");
     Debug.Log("------------Loading First Mode signle item----");
    AdsManager.Instance.DestroyBanner();
     AdsManager.Instance.HideBanner();
    AdsManager.Instance.ShowCollapsibleBanner();
    AdsManager.Instance.ShowMREC();
  }
  void OnDisable()
  {
    AdsManager.Instance.HideMREC();
   
   //AdsManager.Instance.DestroyCollapsibleBanner();
   //AdsManager.Instance.ShowBanner();
  }
  public void Show()
  {
    Debug.Log("--------Loading First Mode signle item");
    //AdsManager.Instance.DestroyBanner();
     AdsManager.Instance.ShowCollapsibleBanner();
  }
  public void Hide()
  {
    AdsManager.Instance.HideCollapsibleBanner();
    AdsManager.Instance.DestroyCollapsibleBanner();
  }
}
