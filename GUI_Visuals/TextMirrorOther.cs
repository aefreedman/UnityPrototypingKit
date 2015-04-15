using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
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