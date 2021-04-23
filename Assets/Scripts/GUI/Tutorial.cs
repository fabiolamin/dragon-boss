using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int tipIndex = 0;

    [SerializeField] private GameObject[] _tutorialTips;
    [SerializeField] private GameObject _button;
    [SerializeField] private float _tipInterval;

    private void Start()
    {
        CheckTutorial();
    }

    private void CheckTutorial()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            ActivateTip(true);
            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }

    private void ActivateTip(bool isActive)
    {
        _tutorialTips[tipIndex].SetActive(isActive);
        _button.SetActive(isActive);
        Time.timeScale = isActive ? 0 : 1;
    }

    public void SetUpNewTip()
    {
        ActivateTip(false);
        tipIndex++;

        if (tipIndex < _tutorialTips.Length)
        {
            StartCoroutine(StartNewTip());
        }
    }

    private IEnumerator StartNewTip()
    {
        yield return new WaitForSeconds(_tipInterval);
        ActivateTip(true);
    }
}