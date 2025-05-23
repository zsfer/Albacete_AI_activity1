using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float _startX;

    [SerializeField] float _freq = 5, _amp = 0.5f;

    void Start()
    {
        _startX = transform.position.x;
    }

    void Update()
    {
        float newX = Mathf.Sin(Time.time * _freq) * _amp;

        transform.position = new Vector3(_startX + newX, transform.position.y, transform.position.z);
    }

}
