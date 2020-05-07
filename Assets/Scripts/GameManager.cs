using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private Player player;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance==null)
            {
                Debug.LogError("No instance");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

    public Player GetPlayer()
    {
        return player;
    }
}
