using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chatting : MonoBehaviour
{
    public TMP_InputField T_InputField;
    public Text Chat;
    public PlayerMovement Pm;
    public CameraMovement Cm;

    public FromReact FReact;
    // Start is called before the first frame update
    private void Start()
    {
        T_InputField.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        T_InputField.ActivateInputField();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (T_InputField.enabled)
            {
                string Chatt = T_InputField.text;
                T_InputField.text = "";
                if (Chatt != "")
                {
                    FReact.ChatfromUnity(LocalPlayerManager.instance.Nickname, Chatt);
                }
                //Chat.text += LocalPlayerManager.instance.Nickname + ":" + Chatt + "\n";
                T_InputField.enabled = false;
                Pm.enabled = true;
                Cm.isESC = false;
                Cm.enabled = true;
            }
            else
            {
                T_InputField.enabled = true;
                Pm.enabled = false;
                Cm.enabled = false;
            }
        }
    }
    public void PrintText(string str)
    {
        Chat.text += str + "\n";
    }
}