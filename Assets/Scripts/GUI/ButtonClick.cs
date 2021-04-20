using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float amountToIncrease = 0.2f;
    [SerializeField] private AudioClip _buttonAudioClip;
    [SerializeField] private SoundPlayer _soundPlayer;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!SceneLoader.IsLoading)
        {
            transform.localScale +=
        new Vector3(amountToIncrease, amountToIncrease, amountToIncrease);

            _soundPlayer.PlaySound(_buttonAudioClip);
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
