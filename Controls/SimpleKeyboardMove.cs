using UnityEngine;
using System.Collections;

public class SimpleKeyboardMove : MonoBehaviour
{

    [SerializeField] string upButton;
    [SerializeField] string downButton;
    [SerializeField] string leftButton;
    [SerializeField] string rightButton;
    [SerializeField] float moveSpeed;

    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
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
