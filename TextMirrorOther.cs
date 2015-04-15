// TextMirrorOther.cs
// Last edited 7:43 PM 04/15/2015 by Aaron Freedman

using UnityEngine;
using UnityEngine.UI;

namespace Assets.PrototypingKit
{
    [RequireComponent(typeof (Text))]
    /// <summary>
    /// This script forces the Text it is attached to to mirror the other Text object
    /// </summary>
    public class TextMirrorOther : MonoBehaviour
    {
        private Text thisText;
        public Text textToMirror;

        private void Start()
        {
            thisText = GetComponent<Text>();
        }

        private void Update()
        {
            thisText.text = textToMirror.text;
        }
    }
}