using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Socket.Quobject.SocketIoClientDotNet.Client;
using Socket.Newtonsoft.Json;

public class ChatData {
	public string id;
	public string msg;
};

public class SocketIOScript : MonoBehaviour {
    public string serverURL = "http://localhost:3000";

    protected QSocket socket = null;
    protected List<string> chatLog = new List<string>();
    public _game_manager gm_;

    void Destroy()
    {
        DoClose();
    }

    // Use this for initialization
    void Start()
    {
        DoOpen();

        gm_ = GameObject.Find("_game_manager").GetComponent<_game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        lock (chatLog)
        {
            if (chatLog.Count > 0)
            {
                foreach (var s in chatLog)
                {
                    Debug.Log(s);
                    gm_._command_processing(s);
                }
                chatLog.Clear();
            }
        }
    }

    void DoOpen()
    {
        if (socket == null)
        {
            socket = IO.Socket(serverURL);
            socket.On(QSocket.EVENT_CONNECT, () =>
            {
                lock (chatLog)
                {
                    // Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
                    chatLog.Add("Socket.IO connected.");
                }
            });
            socket.On("chat", (data) =>
            {
                string str = data.ToString();

                ChatData chat = JsonConvert.DeserializeObject<ChatData>(str);
                string strChatLog = "user#" + chat.id + ": " + chat.msg;

                // Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
                lock (chatLog)
                {
                    chatLog.Add(strChatLog);
                }
            });
        }
    }

    void DoClose()
    {
        if (socket != null)
        {
            socket.Disconnect();
            socket = null;
        }
    }

    public void SendChat(string str)
    {
        if (socket != null)
        {
            socket.Emit("chat", str);
        }
    }
}
