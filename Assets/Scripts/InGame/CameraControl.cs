using UnityEngine;
using UnityEngine.Serialization;

namespace InGame
{
    public class CameraControl : MonoBehaviour
    {
        [FormerlySerializedAs("Picker")] [SerializeField] private Transform picker;
    
        private Vector3 _distance;
        private Vector3 _pickerPos;
        private Vector3 _currentPos;
    
        private void Awake()
        {
            _distance = transform.position - picker.position;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _pickerPos = picker.position;
            _currentPos = transform.position;
        
            transform.position = new Vector3(_pickerPos.x + _distance.x, _currentPos.y, _currentPos.z);
        }
    }
}
