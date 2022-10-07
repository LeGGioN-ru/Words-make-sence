using UnityEngine;

public class ItemViewsGenerator : MonoBehaviour
{
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private ArmorView _armorView;
    [SerializeField] private MagicView _magicDamageView;
    [SerializeField] private MagicView _magicHealView;
    [SerializeField] private ArtifactItemView _artifactHealPotionView;
    [SerializeField] private ArtifactItemView _artifactManaPotionView;
    [SerializeField] private ArtifactItemView _artifactAttackBuffView;
    [SerializeField] private ArtifactItemView _artifactManaBuffView;
    [SerializeField] private ArtifactItemView _artifactHealBuffView;
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private Transform _armorContainer;
    [SerializeField] private Transform _magicContrainer;
    [SerializeField] private Transform _artifactContrainer;

    public void Init(Phrase[] phrases)
    {
        foreach (var phrase in phrases)
        {
            switch (phrase)
            {
                case Weapon weapon:
                    Instantiate(_weaponView, _weaponContainer).Init(weapon);
                    break;

                case Armor armor:
                    Instantiate(_armorView, _armorContainer).Init(armor);
                    break;

                case HealMagic healMagic:
                    Instantiate(_magicHealView, _magicContrainer).Init(healMagic);
                    break;

                case DamageMagic damageMagic:
                    Instantiate(_magicDamageView, _magicContrainer).Init(damageMagic);
                    break;

                case HealthPotion healthPotion:
                    Instantiate(_artifactHealPotionView, _artifactContrainer).Init(healthPotion);
                    break;

                case ManaPotion manaPotion:
                    Instantiate(_artifactManaPotionView, _artifactContrainer).Init(manaPotion);
                    break;

                case AttackArtifact attackArtifact:
                    Instantiate(_artifactAttackBuffView, _artifactContrainer).Init(attackArtifact);
                    break;

                case HealthArtifact healthArtifact:
                    Instantiate(_artifactHealBuffView, _artifactContrainer).Init(healthArtifact);
                    break;

                case ManaArtifact mananaArtifact:
                    Instantiate(_artifactManaBuffView, _artifactContrainer).Init(mananaArtifact);
                    break;
            }
        }
    }
}
