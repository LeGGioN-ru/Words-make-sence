using System.Collections.Generic;
using UnityEngine;

public class LettersGenerator : MonoBehaviour
{
    [SerializeField] private LetterRow _letterRow;
    [SerializeField] private LetterView _letterView;
    [SerializeField] private LetterPanel _panel;
    [SerializeField] private int _amountLetters;
    [SerializeField] private int _amountRows;
    [SerializeField] private LetterWallet _letterWallet;

    private List<LetterView> _letterViews = new List<LetterView>();

    private void Start()
    {
        for (int i = 0; i < _amountRows; i++)
        {
            var row = Instantiate(_letterRow, _panel.transform);

            for (int j = 0; j < _amountLetters; j++)
            {
                _letterViews.Add(Instantiate(_letterView, row.transform));
            }
        }

        _letterWallet.Init(_letterViews.ToArray());
    }
}
