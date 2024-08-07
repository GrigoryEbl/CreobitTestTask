using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    private bool _isWork;

    public Action TimeEmpty;

    public bool IsWork => _isWork;

    private void Update()
    {
        if (_isWork)
            _time += Time.deltaTime;
    }

    public void StartWork()
    {
        if (_isWork)
            return;

        _isWork = true;
    }

    public float GetLastTime()
    {
        return _time;
    }
}
