using TMPro;
using UnityEngine;

public class EvilLevelView : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _textLevel;

    private void OnEnable()
    {
        _spawner.EvilIncreased += OnEvilIncreased;
    }

    private void OnDisable()
    {
        _spawner.EvilIncreased -= OnEvilIncreased;
    }

    private void OnEvilIncreased(int evilLevel)
    {
        _textLevel.text = evilLevel.ToString();
    }
}
