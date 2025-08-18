using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Damaged += OutputInfo;
        Health.Cured += OutputInfo;
        Health.Died += Destroy;
    }

    private void OnDisable()
    {
        Health.Damaged -= OutputInfo;
        Health.Cured -= OutputInfo;
        Health.Died -= Destroy;
    }

    protected abstract void OutputInfo();

    private void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
