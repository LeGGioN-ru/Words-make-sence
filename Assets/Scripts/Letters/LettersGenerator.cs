using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LettersGenerator : MonoBehaviour
{
    [SerializeField] private LetterRow _letterRowTemplate;
    [SerializeField] private LetterView _letterViewTemplate;
    [SerializeField] private LetterPanel _panel;
    [SerializeField] private int _amountLetters;
    [SerializeField] private int _amountRows;
    [SerializeField] private LetterWallet _letterWallet;
    [SerializeField] private LetterPanelCleaner _panelCleaner;

    private List<LetterView> _letterViews = new List<LetterView>();

    private void Start()
    {
        for (int i = 0; i < _amountRows; i++)
        {
            var row = Instantiate(_letterRowTemplate, _panel.transform);

            for (int j = 0; j < _amountLetters; j++)
            {
                _letterViews.Add(Instantiate(_letterViewTemplate, row.transform));
            }
        }

        _panelCleaner.Init(_letterViews);
        _letterWallet.Init(_letterViews.ToArray());
    }

    public void ClearAll()
    {
        _letterViews.ForEach(let => let.Letter.ChangeLabel());
    }
}
