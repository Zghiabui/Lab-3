using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MiniProjectUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    // Hàm này sẽ được gọi bởi Event của Dummy
    public void UpdateHealth(int hp)
    {
        hpText.text = $"DUMMY HP: {hp}";

        if (hp < 50) hpText.color = Color.yellow;
        if (hp < 20) hpText.color = Color.red;
    }

    public void ShowWin()
    {
        hpText.text = "TARGET ELIMINATED!";
        hpText.color = Color.green;
    }
}