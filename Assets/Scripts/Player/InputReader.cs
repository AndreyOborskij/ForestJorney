using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public float Direction()
    {
        return Input.GetAxis(Horizontal);
    }
}
