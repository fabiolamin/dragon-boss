using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}
