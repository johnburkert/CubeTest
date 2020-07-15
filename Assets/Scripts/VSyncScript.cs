using UnityEngine;

public class VSyncScript : MonoBehaviour
{
    [Range(0, 4)]
    public int vSyncCount = 1;
    
    private void Start()
    {
        QualitySettings.vSyncCount = vSyncCount;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            QualitySettings.vSyncCount = vSyncCount;
        }
    }
}
