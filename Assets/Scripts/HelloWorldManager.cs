using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class HelloWorldManager : MonoBehaviour
{
    VisualElement rootVisualElement; // UIElements可视化树的成员对象的基类
    Button hostButton;
    Button clientButton;
    Button serverButton;
    Button moveButton;
    Label statusLabel;

    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        rootVisualElement = uiDocument.rootVisualElement;

        hostButton = CreateButton("HostButton", "Host");
        clientButton = CreateButton("ClientButton", "Client");
        serverButton = CreateButton("ServerButton", "Server");
        moveButton = CreateButton("MoveButton", "Move");
        statusLabel = CreateLabel("StatusLabel", "Not Connected");

        rootVisualElement.Clear();
        rootVisualElement.Add(hostButton);
        rootVisualElement.Add(clientButton);
        rootVisualElement.Add(serverButton);
        rootVisualElement.Add(moveButton);
        rootVisualElement.Add(statusLabel);

        hostButton.clicked += OnHostButtonClick;
        clientButton.clicked += OnClientButtonClick;
        serverButton.clicked += OnServerButtonClick;
    }

    void OnHostButtonClick() => NetworkManager.Singleton.StartHost();
    void OnClientButtonClick() => NetworkManager.Singleton.StartClient();
    void OnServerButtonClick() => NetworkManager.Singleton.StartServer();

    Button CreateButton(string name, string text)
    {
        var button = new Button();
        button.name = name;
        button.text = text;
        button.style.width = 240;
        button.style.backgroundColor = Color.white;
        button.style.color = Color.black;
        button.style.unityFontStyleAndWeight = FontStyle.Bold;
        return button;
    }

    Label CreateLabel(string name, string content)
    {
        var label = new Label();
        label.name = name;
        label.text = content;
        label.style.color = Color.black;
        label.style.fontSize = 18;
        return label;
    }
}
