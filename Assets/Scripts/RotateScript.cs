using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed;
    
    private void Start()
    {
        StartCoroutine(RotateRoutine());
    }
    
    private IEnumerator RotateRoutine()
    {
        var rotation = 0f;
        
        while (true)
        {
            yield return null;

            rotation += speed * Time.deltaTime;

            if (rotation > 360f)
                rotation -= 360f;
            
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }
    }
}
