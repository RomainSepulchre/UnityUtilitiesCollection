using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BuildVersionDisplay : MonoBehaviour
{
    private TextMeshProUGUI _versionText;

    private void Awake()
    {
        _versionText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        _versionText.SetText($"Build version: {Application.version}");
    }
}
