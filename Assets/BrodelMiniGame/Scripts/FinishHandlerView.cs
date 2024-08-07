using TMPro;
using UnityEngine;

public class FinishHandlerView : MonoBehaviour
{
    private readonly float _timeFactor = 60f;
    private readonly string _zeroTimer = "00:00";
    private readonly string _timeSample = "00";

    [SerializeField] private FinishHandler _finishHandler;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        _finishHandler.PlayerFinished += OnPlayerFinished;
    }

    private void OnDisable()
    {
        _finishHandler.PlayerFinished += OnPlayerFinished;
    }

    private void OnPlayerFinished(float lastTme)
    {
        _panel.SetActive(true);

        int minutes = Mathf.FloorToInt(lastTme / _timeFactor);
        int seconds = Mathf.FloorToInt(lastTme % _timeFactor);

        if (lastTme > 0)
            _text.text = $"{StylizeString(minutes)}:{StylizeString(seconds)}";
        else
            _text.text = _zeroTimer;
    }

    private string StylizeString(int time)
    {
        return time.ToString(_timeSample);
    }
}
