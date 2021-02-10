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

            AudioSource.PlayClipAtPoint(_buttonAudioClip, Camera.main.transform.position, PlayerPrefs.GetFloat("Sounds"));
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
