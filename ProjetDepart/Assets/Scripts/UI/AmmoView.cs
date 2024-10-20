using UnityEngine;
using TMPro;

public class AmmoView : MonoBehaviour
{
    [SerializeField] private string format = "Ammo: {0}";
    private StatManager statManager;
    private TMP_Text text;

    private void Awake()
    {
        statManager = Finder.StatManager;
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = string.Format(format, statManager.Ammo);
    }
}
