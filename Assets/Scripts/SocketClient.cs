using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using Newtonsoft.Json;
using UnityEngine.AI;
using System.Collections.Concurrent;

public class SocketClient : MonoBehaviour
{
    double updatedTime = 0;
    private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
    string data;
    public SocketIOUnity socket;
    GameObject[] Roads = new GameObject[4];


    static public int[] carNo = new int[12];

    static public int config;
    // Start is called before the first frame update
    void Start()
    {
        Roads[0] = GameObject.Find("NRoad");
        Roads[1] = GameObject.Find("ERoad");
        Roads[2] = GameObject.Find("SRoad");
        Roads[3] = GameObject.Find("WRoad");

        // spawner = GameObject.Find("N1");
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
        socket.On("NEXT_CONFIG_READY_EVENT", (response) =>
        {
            var recieved = response.GetValue().ToString();
            var deserialized = JsonConvert.DeserializeObject<int>(recieved);
            config = deserialized;

        });
        socket.On("YOLO_EVENT", (response) =>
        {
            var recived = response.GetValue();
            var serialized = recived.ToString();
            var deserialized = JsonConvert.DeserializeObject<List<String>>(serialized);

            _actions.Enqueue(() => CarSpawner.carInst(deserialized[0].ToString(), deserialized[1].ToString()));

        });
        Debug.Log("Connecting...");
        socket.Connect();
    }
    private void Update()
    {
        while (_actions.Count > 0)
        {
            if (_actions.TryDequeue(out var action))
            {
                action?.Invoke();
            }
        }

        if ((Time.realtimeSinceStartupAsDouble - updatedTime) > 30)
        {
            socket.Emit("LIGHT_CHANGE_NEEDED_EVENT", JsonConvert.SerializeObject(carNo));
            updatedTime = Time.realtimeSinceStartupAsDouble;

        }
    }


}
