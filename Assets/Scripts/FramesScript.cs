using System.Collections;
using UnityEngine;

public class FramesScript : MonoBehaviour
{
    public float errorThreshold = 45f;
    public int warningThreshold = 30;
    
    private uint _frames;
    private float _speed;
    
    private float Y
    {
        get
        {
            var y = transform.localRotation.eulerAngles.y;

            return y < 0f ? y + 360f : y;
        }
    }

    private void Start()
    {
        StartCoroutine(FramesRoutine());
        StartCoroutine(SpeedRoutine());
        StartCoroutine(ErrorRoutine());
    }
    
    private IEnumerator FramesRoutine()
    {
        _frames = 1;
        
        while (true)
        {
            yield return null;

            _frames++;
        }
    }

    private IEnumerator SpeedRoutine()
    {
        var prevY = Y;
        const float time = 0.5f;
        
        while (true)
        {
            yield return new WaitForSeconds(time);
            
            var y = Y;

            _speed = (y - (y < prevY ? prevY - 360f : prevY)) / time;
            
            prevY = y;
        }
    }

    private IEnumerator ErrorRoutine()
    {
        var prevY = Y;
        var error = 0;
        
        var cube = GetComponent<MeshRenderer>();
  
        while (true)
        {
            yield return null;
            
            var y = Y;
            
            var speed = (y - (y < prevY ? prevY - 360f : prevY)) / Time.deltaTime;

            if (speed < errorThreshold)
            {
                error++;
            }
            else
            {
                if (error > warningThreshold)
                {
                    Debug.LogWarning($"Slowdown for {error} frames at frame {_frames - error}");
                }

                error = 0;
            }

            var n = 1f - Mathf.Min(1f, error / errorThreshold);

            cube.material.color = new Color(1f, n, n);
                
            prevY = y;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 500, 20), $"Frames: {_frames:N0}");
        GUI.Label(new Rect(10, 50, 500, 20), $"Speed: {_speed:N1}");
    }
}
