using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

namespace _Project.SceneLoaderSystem.Controller
{
    public class RocketLaunchController : MonoBehaviour
    {
        [SerializeField] private Animator roofController;
        [SerializeField] private Animator playerEnvController;
        private bool allowSceneLoad = false;
        private const string animatorTrigger = "Launch";
        

        public void OnButtonDown(Hand fromHand)
        {
            fromHand.TriggerHapticPulse(1000);
            TriggerSpaceLaunch();
        }
        
        private void TriggerSpaceLaunch()
        {
            //Trigger an animation
            roofController.SetTrigger(animatorTrigger);
            playerEnvController.SetTrigger(animatorTrigger);
            StartCoroutine(LoadYourAsyncScene());
        }

        public void AllowSceneLoad()
        {
            allowSceneLoad = true;
        }

        IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SpaceSandbox");

            asyncLoad.allowSceneActivation = false;
            
            while (!asyncLoad.isDone)
            {
                if (allowSceneLoad)
                {
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
