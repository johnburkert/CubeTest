using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlaybackScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(InputRoutine());
    }

    // Update is called once per frame
    private IEnumerator InputRoutine()
    {
        while (true)
        {
            yield return null;
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetComponent<Animator>().Play("Base Layer.CubeRotate", 0, 0);
            }
        }
    }
}
