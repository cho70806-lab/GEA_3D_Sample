using UnityEngine;

public class HpPractice : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    int a;
    [ContextMenu("체력")]

    void PrintHp()
    {
        Debug.Log(100*currentHp / maxHp );
    }

}
