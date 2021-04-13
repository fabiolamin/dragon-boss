using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float amountToIncrease = 0.2f;
    [SerializeField] private AudioClip _buttonAudioClip;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!SceneLoader.IsLoading)
        {
            transform.localScale +=
        new Vector3(amountToIncrease, amountToIncrease, amountToIncrease);

            AudioManager.Instance.PlaySound(_buttonAudioClip);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!SceneLoader.IsLoading)
        {
            transform.localScale -=
        new Vector3(amountToIncrease, amountToIncrease, amountToIncrease);
        }
    }
}
