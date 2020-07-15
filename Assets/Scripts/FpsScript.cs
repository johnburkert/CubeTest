using System.Collections;
using UnityEngine;

public class FpsScript : MonoBehaviour
{
    private string _fpsText;
    
    private void Start()
    {
        StartCoroutine(FpsRoutine());
    }

    private IEnumerator FpsRoutine()
    {
        var time = 0f;
        var count = 0;
        
        while (true)
        {
            yield return null;

            count++;

            time += Time.deltaTime;

            if (time < 1f) continue;

            time -= 1f;

            _fpsText = $"FPS: {count}";

            count = 0;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 500, 20), _fpsText);
    }
}
