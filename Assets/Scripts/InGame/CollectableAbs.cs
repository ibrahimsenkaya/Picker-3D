using UnityEngine;

namespace InGame
{
    public class CollectableAbs : MonoBehaviour
    {
        private Rigidbody _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
    
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Checkpoint"))
            {
                //GetComponent<Collider>().isTrigger = true;
                _rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}