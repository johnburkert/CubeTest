using UnityEngine;

public class TimeScaleScript : MonoBehaviour
{
    [Range(0, 100)]
    public float timeScale = 1f;
    
    private void Start()
    {
        Time.timeScale = timeScale;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            Time.timeScale = timeScale;
        }
    }
}
