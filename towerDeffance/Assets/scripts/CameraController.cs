using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minX = -10f;
    [SerializeField] private float _maxX = 10f;
    [SerializeField] private float _minY = -10f;
    [SerializeField] private float _maxY = 10f;

    [SerializeField] private Transform _camera;

    private Vector3 _offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _offset = Input.mousePosition * 0.01f + _camera.position;
            _offset.z = -10;
        }

        if (_camera.position.x >= _minX && _camera.position.x <= _maxX)
        {
            if (_camera.position.y >= _minY && _camera.position.y <= _maxY)
            {
                if (Input.GetMouseButton(2))
                {
                    _camera.position = _offset - Input.mousePosition * 0.01f;
                }
            }
        }

        if(_camera.position.x < _minX)
        {
            _camera.position = new Vector3(_minX, _camera.position.y, _camera.position.z);
        }
        if (_camera.position.x > _maxX)
        {
            _camera.position = new Vector3(_maxX, _camera.position.y, _camera.position.z);
        }

        if (_camera.position.y < _minY)
        {
            _camera.position = new Vector3(_camera.position.x, _minY, _camera.position.z);
        }
        if (_camera.position.y > _maxY)
        {
            _camera.position = new Vector3(_camera.position.x, _maxY, _camera.position.z);
        }

    }
}
