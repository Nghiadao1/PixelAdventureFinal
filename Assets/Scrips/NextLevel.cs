using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevel : MonoBehaviour
{
  public GameObject SuccessPanel;
  [SerializeField] private AudioSource audioSuccessSource;
  // [SerializeField] RewardedAdsButton _rewardedAdsButton;
   void OnCollisionEnter2D(Collision2D other)
   {
         if (other.gameObject.CompareTag("Player"))
         {
              if (Score.gemKeys == 3)
              {
                // Load the next level
                Score.gemKeys = 0;
                SuccessPanel.SetActive(true);
                // // load Ads
                // _rewardedAdsButton.LoadAd();
                // // show ads
                audioSuccessSource.Play();
                

              }
         }
   }
}
