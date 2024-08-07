using TMPro;
using UnityEngine;

public class ScoresView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoresWallet _scoresWallet;

    private void OnEnable()
    {
        _scoresWallet.ScoresChanged += OnScoresChanged;
    }

    private void OnDisable()
    {
        _scoresWallet.ScoresChanged -= OnScoresChanged;
    }

    private void OnScoresChanged(int value)
    {
        _text.text = value.ToString();
    }
}
