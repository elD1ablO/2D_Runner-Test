using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 20;

    float leftBound = -20f;
    
    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
