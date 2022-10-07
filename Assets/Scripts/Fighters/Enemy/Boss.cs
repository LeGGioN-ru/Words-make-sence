using IJunior.TypedScenes;

public class Boss : Enemy
{
    private void OnEnable()
    {
        Died += OnDied;
    }

    private void OnDisable()
    {
        Died -= OnDied;
    }

    private void OnDied()
    {
        MainMenu.Load();
    }
}
