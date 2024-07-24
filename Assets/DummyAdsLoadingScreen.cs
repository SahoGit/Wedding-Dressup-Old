using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DummyAdsLoadingScreen : MonoBehaviour
{
  

 //public GameObject LoadingScreen_New;

    public Text loadingText;
    public GameObject DummyScreen;
    //public GameObject loadingScreen;
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
    private void Start()
    {
        // Start the process
        StartCoroutine(SwitchToLoadingScreen());
    }

    IEnumerator SwitchToLoadingScreen()
    {
        // Show the current screen and start the loading animation
       // mainScreen.SetActive(true);
       // loadingScreen.SetActive(false);
        StartCoroutine(LoadingAnimation());

        // Wait for 2 seconds
        yield return new WaitForSeconds(3f);

        // Switch to the loading screen
        DummyScreen.SetActive(false);
       // loadingScreen.SetActive(true);
    }

    IEnumerator LoadingAnimation()
    {
        while (true)
        {
            loadingText.text = ".";
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "..";
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "...";
           // yield return new WaitForSeconds(0.5f);
           // loadingText.text = "Ads Laoding...";
            yield return new WaitForSeconds(0.5f);
        }
    }

}
