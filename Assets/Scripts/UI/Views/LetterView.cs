using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Letter))]
[RequireComponent(typeof(Image))]
public class LetterView : MonoBehaviour
{
    [SerializeField] private Color _selectableColor;

    private Color _standartColor;
    private Image _image;

    public event UnityAction<Letter> Clicked;

    public Letter Letter => _letter;

    private Letter _letter;
    private Button _button;
    private TMP_Text _text;

    public bool IsSelected { get; private set; }

    private void Awake()
    {
        _letter = GetComponent<Letter>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TMP_Text>();
        _standartColor = GetComponent<Image>().color;
        _image = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        _letter.Changed += ChangeText;
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _letter.Changed -= ChangeText;
        _button.onClick.RemoveListener(OnClick);
    }

    public void DeSelect()
    {
        IsSelected = false;
        _image.color = _standartColor;
    }

    private void ChangeText(char letter)
    {
        DeSelect();
        _text.text = letter.ToString();
    }

    private void OnClick()
    {
        if (IsSelected == false)
            Select();
        else
            DeSelect();

        Clicked?.Invoke(_letter);
    }

    private void Select()
    {
        IsSelected = true;
        _image.color = _selectableColor;
    }
}
