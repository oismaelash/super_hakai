using UnityEngine;
using TMPro;

public class UpdateCountdownText : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.Instance.countdown.ToString();
    }
}