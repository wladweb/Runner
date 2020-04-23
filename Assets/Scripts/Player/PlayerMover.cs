using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _target;

    private void Start()
    {
        _target = transform.position;
    }

    private void Update()
    {
        if (transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_target.y < _maxHeight)
            SetNextTarget(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_target.y > _minHeight)
            SetNextTarget(-_stepSize);
    }

    private void SetNextTarget(float stepSize)
    {
        _target = new Vector2(_target.x, _target.y + stepSize);
    }
}
