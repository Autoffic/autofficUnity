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
            // Debug.Log(response.GetValue());
            // config = response.GetValue();
            var recieved = response.GetValue().ToString();
            var deserialized = JsonConvert.DeserializeObject<List<int>>(recieved);
            config = deserialized[0];
    
        });
        socket.On("YOLO_EVENT", (response) =>
        {
            var recived = response.GetValue();
            var serialized = recived.ToString();
            var deserialized = JsonConvert.DeserializeObject<List<String>>(serialized);

            switch (deserialized[0].ToString())
            {
                case "NORTH":
                    Debug.Log("CASE: " + deserialized[0]);
                    switch (deserialized[1].ToString())
                    {
                        case "lane0":
                            _actions.Enqueue(() => CarSpawner.instCN1());
                            Debug.Log("From lane 1");
                            break;
                        case "lane1":
                            _actions.Enqueue(() => CarSpawner.instCN2());
                            break;
                        case "lane2":
                            _actions.Enqueue(() => CarSpawner.instCN3());
                            break;
                        default:
                            Debug.Log("Invalid Input");
                            break;
                    }
                    break;
                case "EAST":
                    Debug.Log("CASE: " + deserialized[0]);
                    switch (deserialized[1].ToString())
                    {
                        case "lane0":
                            _actions.Enqueue(() => CarSpawner.instCE1());
                            Debug.Log("From lane 1");
                            break;
                        case "lane1":
                            _actions.Enqueue(() => CarSpawner.instCE2());
                            break;
                        case "lane2":
                            _actions.Enqueue(() => CarSpawner.instCE3());
                            break;
                        default:
                            Debug.Log("Invalid Input");
                            break;
                    }
                    break;
                case "WEST":
                    Debug.Log("CASE: " + deserialized[0]);
                    switch (deserialized[1].ToString())
                    {
                        case "lane0":
                            _actions.Enqueue(() => CarSpawner.instCW1());
                            Debug.Log("From lane 1");
                            break;
                        case "lane1":
                            _actions.Enqueue(() => CarSpawner.instCW2());
                            break;
                        case "lane2":
                            _actions.Enqueue(() => CarSpawner.instCW3());
                            break;
                        default:
                            Debug.Log("Invalid Input");
                            break;
                    }
                    break;
                case "SOUTH":
                    Debug.Log("CASE: " + deserialized[0]);
                    switch (deserialized[1].ToString())
                    {
                        case "lane0":
                            _actions.Enqueue(() => CarSpawner.instCS1());
                            Debug.Log("From lane 1");
                            break;
                        case "lane1":
                            _actions.Enqueue(() => CarSpawner.instCS2());
                            break;
                        case "lane2":
                            _actions.Enqueue(() => CarSpawner.instCS3());
                            break;
                        default:
                            Debug.Log("Invalid Input");
                            break;
                    }
                    break;
                default:
                    CarSpawner.instCE1();
                    Debug.Log("IN CE1");
                    break;
            }
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
        // foreach (var Road in Roads)
        // {
        //     // Debug.Log("on collision with " + Road.GetComponent<BoxCollider>().name);

        // }

        if ((Time.realtimeSinceStartupAsDouble - updatedTime) > 30)
        {
            Debug.Log(JsonConvert.SerializeObject(carNo));
            Debug.Log("30 seconds gone");
            int x = 0;
            foreach (int car in carNo)
            {
                Debug.Log("Index " + x + " is " + carNo[x]);
                x++;
            }
            socket.Emit("LIGHT_CHANGE_NEEDED_EVENT", JsonConvert.SerializeObject(carNo));
            updatedTime = Time.realtimeSinceStartupAsDouble;

        }


    }

    private void OnDestroy()
    {

    }
    public void valueChanged(string a)
    {
        data = a;
        Debug.Log(data);
    }
    public void onCLick()
    {
        socket.Emit("traffic", data);
    }

}
