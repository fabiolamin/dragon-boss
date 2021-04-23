using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float amountToIncrease = 0.2f;
    [SerializeField] private AudioClip _buttonAudioClip;
    [SerializeField] private SoundPlayer _soundPlayer;
    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateButtonSize(amountToIncrease);
        _soundPlayer.PlaySound(_buttonAudioClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpdateButtonSize(-amountToIncrease);
    }

    private void UpdateButtonSize(float amount)
    {
        if (!SceneLoader.IsLoading)
        {
            transform.localScale +=
        new Vector3(amount, amount, amount);
        }
    }
}
