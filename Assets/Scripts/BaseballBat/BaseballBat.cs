using UnityEngine;

public class BaseballBat : MonoBehaviour 
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}

