using System;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    public Action<float> PlayerFinished;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            float lastTime = player.GetComponent<Timer>().GetLastTime();

            PlayerFinished?.Invoke(lastTime);

            Time.timeScale = 0f;
        }
    }
}
