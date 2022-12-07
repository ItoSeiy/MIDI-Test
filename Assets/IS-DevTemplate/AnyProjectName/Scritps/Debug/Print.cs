using UnityEngine;

public class Print : MonoBehaviour
{
    [SerializeField]
    private string _message;

    public void Do()
    {
        print(_message);
    }
}
