using GooglePlayGames;
using UnityEngine;

namespace TGDStudio.PlayGameServices
{
    public class LeaderboardController : MonoBehaviour
    {
        #region VARIABLES

        private static LeaderboardController instance;
        public static LeaderboardController Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new GameObject("LeaderboardController_Created").AddComponent<LeaderboardController>();
                }

                return instance;
            }
        }

        #endregion

        #region PUBLIC_METHODS

        public void OnShowLeaderboards()
        {
            if (PlayGamesPlatform.Instance.localUser.authenticated)
            {
                PlayGamesPlatform.Instance.ShowLeaderboardUI();
            }
            else
            {
                PlayGamesPlatform.Instance.Authenticate((success, errorMessage) =>
                {
                    if (success)
                        PlayGamesPlatform.Instance.ShowLeaderboardUI();
                    else
                        Debug.LogError(errorMessage);
                }, 
                false);
            }
        }

        public void SetAmountWaves(int value)
        {
            //value = Random.Range(1, 100);
            if (PlayGamesPlatform.Instance.localUser.authenticated)
            {
                PlayGamesPlatform.Instance.ReportScore
                (
                    value,
                    GPGSIds.leaderboard_waves,
                    success => Debug.Log("Leaderboard update success: " + success)
                );
            }
        }

        #endregion
    }
}