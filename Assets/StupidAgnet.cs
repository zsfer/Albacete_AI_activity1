using UnityEngine;
using UnityEngine.AI;

public class StupidAgnet : MonoBehaviour
{
    [SerializeField] Transform _player; // hell nah
    [SerializeField] GameObject _gameOverScreen;

    NavMeshAgent _agent;

    bool _gameOver = false; // if this was real life, we move this to another class(Game) or something

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();        
        _gameOverScreen.SetActive(false); 

        if (_player == null) // hell nah (1)
            _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        _agent.SetDestination(_player.position);

        // super expensive to use .Distance
        if (Vector3.Distance(transform.position, _player.position) <= 4 && !_gameOver)  {
            _gameOverScreen.SetActive(true); 
            _player.GetComponent<PlayerController>().enabled = false;
            _gameOver = true;
        }
    }
}
