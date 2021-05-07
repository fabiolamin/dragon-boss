using System.Collections;
using UnityEngine;

public class LogoPresentation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private SceneLoader _sceneLoader;

    private void Awake()
    {
        StartCoroutine(StartLogoPresentation());
    }

    private IEnumerator StartLogoPresentation()
    {
        yield return new WaitForSeconds(_duration);
        _sceneLoader.LoadScene(1);
    }
}
