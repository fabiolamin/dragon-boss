using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator _fadeAnimator;

    public static bool IsLoading { get; private set; }

    private void Awake()
    {
        IsLoading = false;
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex);
    }

    public void LoadScene(int index)
    {
        IsLoading = true;
        Time.timeScale = 1;
        _fadeAnimator.SetTrigger("FadeIn");
        StartCoroutine(SetScene(index));
    }

    private IEnumerator SetScene(int index)
    {
        yield return new WaitForSeconds(_fadeAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(index);
    }
}
