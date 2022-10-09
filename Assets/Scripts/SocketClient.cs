using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SocketClient : MonoBehaviour
{
    public SocketIOUnity socket;
    // Start is called before the first frame update
    void Start()
    {
        socket = new SocketIOUnity("http://localhost:5000", new SocketIOOptions
        {
            Query = new Dictionary<string, string>
                {
                    {"token", "UNITY" }
                }
            ,
            EIO = 4
            ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });

        socket.JsonSerializer = new NewtonsoftJsonSerializer();

        socket.OnConnected += (sender, e) =>
        {
            Debug.Log("socket.OnConnected");
        };
        socket.OnDisconnected += (sender, e) =>
        {
            Debug.Log("disconnect: " + e);
        };
        socket.OnReconnectAttempt += (sender, e) =>
        {
            Debug.Log($"{DateTime.Now} Reconnecting: attempt = {e}");
        };
        socket.On("hello", (response) =>
        {
            Debug.Log(response.GetValue());
        });
        Debug.Log("Connecting...");
        socket.Connect();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            socket.Emit("traffic", "east");
        }
    }

    private void OnDestroy()
    {

    }
}
