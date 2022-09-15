using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void Execute()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
