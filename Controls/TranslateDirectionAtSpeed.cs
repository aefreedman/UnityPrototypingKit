using UnityEngine;
using System.Collections;

public class TranslateDirectionAtSpeed : MonoBehaviour
{

    [SerializeField] Vector3 direction;
//    [SerializeField] 
    public float speed;
//    public float Speed
//    {
//        get { return speed; }
//    }

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
