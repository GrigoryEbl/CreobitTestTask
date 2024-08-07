using UnityEngine;

public class Player : MonoBehaviour
{
   private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void Start()
    {
        _timer.StartWork();
    }
}
