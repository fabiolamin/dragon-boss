using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator _fadeAnimator;

    public void GoToScene(int index)
    {
        Time.timeScale = 1;
        _fadeAnimator.SetTrigger("FadeIn");
        StartCoroutine(SetGameScene(index));
    }

    private IEnumerator SetGameScene(int index)
    {
        yield return new WaitForSeconds(_fadeAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(index);
    }
}
