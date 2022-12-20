using System.Collections;
using UnityEngine;

namespace MySamples.TriangleProcessing.Scripts
{
    public class TrianglesManager : MonoBehaviour
    {
        [SerializeField] private TrianglesProcessing trianglePrefab;

        private int _instanceNumber;

        private void Start()
        {
            _instanceNumber = 15;
            
            for (var i = 0; i < _instanceNumber; i++)
            {
                StartCoroutine(WaitAndInstantiate(i * 0.5f));
            }
        }
        
        private IEnumerator WaitAndInstantiate(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            Instantiate(trianglePrefab, this.transform);
        }
    }
}
