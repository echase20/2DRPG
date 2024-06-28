using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    public static DialogManager Instance {get; private set;}
    private void Awake() {
        Instance = this;
    }
    public void ShowDialog(Dialog dialog) {
        dialogBox.SetActive(true);
        dialogText.text = dialog.Lines[0];
    }
}
