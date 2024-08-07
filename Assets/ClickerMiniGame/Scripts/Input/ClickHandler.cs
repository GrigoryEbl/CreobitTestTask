using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private ScoresWallet _scoresWallet;

    private int _addedScores = 1;

    public void OnClick()
    {
        _scoresWallet.AddScores(_addedScores);
    }
}
