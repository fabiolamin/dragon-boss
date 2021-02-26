using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private PlayerInput _playerInput;
    private PlayerAttack _playerAttack;

    [SerializeField] private float _delayDefaultForward = 0.6f;
    [SerializeField] private float _delayFinishDamage = 0.5f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    public IEnumerator SetDamageAnimation()
    {
        _playerHealth.WasHit = true;
        _animator.SetTrigger("Damage");
        yield return new WaitForSeconds(_delayFinishDamage);
        _playerHealth.WasHit = false;
    }

    public IEnumerator SetMovementAnimation()
    {
        transform.forward = _playerInput.SwipeDirection;
        _animator.SetTrigger("Move");

        yield return new WaitForSeconds(_delayDefaultForward);

        transform.forward = new Vector3(0f, 0f, 1f);
        _playerAttack.CanAttack = true;
    }
}
