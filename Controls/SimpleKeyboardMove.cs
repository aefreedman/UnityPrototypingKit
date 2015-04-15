// SimpleKeyboardMove.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;

namespace Assets.PrototypingKit.Controls
{
    public class SimpleKeyboardMove : MonoBehaviour
    {
        [SerializeField] private string upButton;
        [SerializeField] private string downButton;
        [SerializeField] private string leftButton;
        [SerializeField] private string rightButton;
        [SerializeField] private float moveSpeed;

        private void Start() {}

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetButton(upButton))
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(downButton))
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(rightButton))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            if (Input.GetButton(leftButton))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }
}