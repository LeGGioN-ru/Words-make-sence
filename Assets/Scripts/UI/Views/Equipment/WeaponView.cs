using TMPro;
using UnityEngine;

public class WeaponView : ItemView
{
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _attackSpeed;

    public override void Init(Phrase phrase)
    {
        if (phrase is Weapon weapon)
        {
            _damage.text = weapon.Damage.ToString();
            _attackSpeed.text = weapon.AttackDelay.ToString();
        }

        base.Init(phrase);
    }
}
