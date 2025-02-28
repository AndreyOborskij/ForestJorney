using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = "Jump";

    public float Direction { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        IsJump = Input.GetButtonDown(Jump);
    }
}
