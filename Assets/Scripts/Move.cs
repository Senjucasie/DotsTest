using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*_speed *Time.deltaTime);
        if (transform.position.z > 192)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -409f);
        }
    }
}
