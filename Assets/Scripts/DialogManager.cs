using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    int linecount = 0;
    Dialog dialog;
    public static DialogManager Instance {get; private set;}
    private void Awake() {
        Instance = this;
    }
    public void ShowDialog(Dialog dialog) {
        OnShowDialog?.Invoke();
        
        dialogBox.SetActive(true);
        this.dialog = dialog;
        dialogText.text = dialog.Lines[0];
    }

    public void HandleUpdate() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            ++linecount;
            if (linecount < dialog.Lines.Count) {
                dialogText.text = dialog.Lines[linecount];
            }
            else {
                dialogBox.SetActive(false);
                OnHideDialog?.Invoke();
                linecount = 0;
            }
        }
    }
}
