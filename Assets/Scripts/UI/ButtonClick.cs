using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float amountToIncrease = 0.2f;
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale +=
        new Vector3(amountToIncrease, amountToIncrease, amountToIncrease);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale -=
        new Vector3(amountToIncrease, amountToIncrease, amountToIncrease);
    }
}
