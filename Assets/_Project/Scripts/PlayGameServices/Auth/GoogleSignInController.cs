using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

namespace TGDStudio.PlayGameServices
{
    public class GoogleSignInController : MonoBehaviour
    {
        #region VARIABLES
        private static GoogleSignInController instance;
        public static GoogleSignInController Instance
        {
            get 
            {
                if (instance is null)
                {
                    instance = new GameObject("GoogleSignInController_Created").AddComponent<GoogleSignInController>();
                }

                return instance;
            }
        }
        private string userName;
        #endregion

        #region MONOBEHAVIOURS_METHODS

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            StartPlayGameServices(true);
        }

        #endregion

        #region PUBLIC_METHODS

        public void StartPlayGameServices(bool onBackground = false)
        {
            // Create client configuration
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

            // Enable debugging output (recommended)
            PlayGamesPlatform.DebugLogEnabled = true;

            // Initialize and activate the platform
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();

            // Try auth
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, onBackground);
        }

        public void OnSignin()
        {
            if (!PlayGamesPlatform.Instance.localUser.authenticated)
            {
                // Sign in with Play Game Services, showing the consent dialog
                // by setting the second parameter to isSilent=false.
                StartPlayGameServices(false);
            }
            else
            {
                // Sign out of play games
                PlayGamesPlatform.Instance.SignOut();
                Debug.Log("Signout PlayGames");
            }
        }

        public string GetUserName()
        {
            return userName;
        }

        #endregion

        #region PRIVATE_METHODS

        private void SignInCallback(bool success, string message)
        {
            if (success)
            {
                userName = Social.localUser.userName;
                Debug.Log("Signed in!");
                Debug.Log($"User name: {userName}");
            }
            else
            {
                Debug.LogError("Sign-in failed...");
                Debug.LogError("Message:: " + message);
            }
        }

        #endregion
    }
}