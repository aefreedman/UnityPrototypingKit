// TranslateDirectionAtSpeed.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit
{
    public class TranslateDirectionAtSpeed : MonoBehaviour
    {
        [SerializeField] private Vector3 direction;
//    [SerializeField] 
        public float speed;
//    public float Speed
//    {
//        get { return speed; }
//    }

        // Use this for initialization
        private void Start() {}

        // Update is called once per frame
        private void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}