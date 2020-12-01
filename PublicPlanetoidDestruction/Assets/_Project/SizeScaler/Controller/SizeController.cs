using System.Collections;
using UnityEngine;

namespace _Project.SizeInverter.Controller
{
    public class SizeController : MonoBehaviour
    {
        [SerializeField] private GameObject[] targetsForIncrement;
        [SerializeField] private GameObject[] targetsForDecrement;
        [SerializeField] private bool incrementEnabled = true;

        [SerializeField] private float incrementScaleFactor = .01f;
        [SerializeField] private float decrementScaleFactor = -.001f;
        
        private WaitForFixedUpdate routineDelay = new WaitForFixedUpdate();

        public bool IncrementEnabled
        {
            set => incrementEnabled = value;
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(scaleChangeRoutine());
        }

        private IEnumerator scaleChangeRoutine()
        {            
            while (incrementEnabled)
            {
                applySizeChange(targetsForIncrement, targetsForDecrement);
                yield return null;
            }
        }

        private void applySizeChange(GameObject[] targetsForIncrement, GameObject[] targetsForDecrement)
        {
            ApplyScaleChangeTo(targetsForIncrement, incrementScaleFactor);
            ApplyScaleChangeTo(targetsForDecrement, decrementScaleFactor);
        }

        // TODO: Maybe not the most performant way of changing the scale
        private void ApplyScaleChangeTo(GameObject[] targets, float scaleChange)
        {
            foreach (var target in targets)
            {
                var targetScale = target.transform.localScale;
                var x = targetScale.x + scaleChange;
                var y = targetScale.x + scaleChange;
                var z = targetScale.x + scaleChange;
                
                target.transform.localScale = new Vector3(x, y, z);
            }
        }
    }
}
