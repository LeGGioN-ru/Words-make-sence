using TMPro;
using UnityEngine;

public class ArmorView : ItemView
{
    [SerializeField] private TMP_Text _defendPercent;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _mana;

    public override void Init(Phrase phrase)
    {
        if (phrase is Armor armor)
        {
            _defendPercent.text = armor.DefendPercent.ToString();
            _health.text = armor.Health.ToString();
            _mana.text = armor.Mana.ToString();
        }

        base.Init(phrase);
    }
}
