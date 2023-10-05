using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 7f;
	[SerializeField] private GameInput _gameInput;
	
	private bool _isWalking;
	
    private void Update()
    {
		Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
		
		Vector3 moveDir = new Vector3 (inputVector.x, 0f, inputVector.y);
		transform.position += moveDir * _moveSpeed * Time.deltaTime;
		
		_isWalking = moveDir != Vector3.zero;
		float rotationSpeed = 10f;
		transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }
	
	public bool IsWalking()
	{
		return _isWalking;
	}
}
