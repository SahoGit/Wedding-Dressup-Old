using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public Image progressBar;
    public GameObject loadingScreen;
    private float loadingTime = 3f; // Total loading time in seconds
    private float elapsedTime = 0f;
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
   //AdsManager.Instance.ShowBanner();
   //AdsManager.Instance.DestroyCollapsibleBanner();
    AdsManager.Instance.HideMREC();
  }
    void Start()
    {
        // Ensure the loading screen is active at the start
        loadingScreen.SetActive(true);
    }

    void Update()
    {
        if (elapsedTime < loadingTime)
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Update progress bar fill amount
            progressBar.fillAmount = elapsedTime / loadingTime;
        }
        else
        {
            // Deactivate the loading screen after the loading is complete
            loadingScreen.SetActive(false);
        }
    }
}
