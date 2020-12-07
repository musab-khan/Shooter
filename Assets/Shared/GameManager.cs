using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    //public event System.Action<Player> OnLocalPlayerJoined;
    //private GameObject gameObject;

    //private static GameManager m_instance;
    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (m_instance == null)
    //        {
    //            m_instance = new GameManager();
    //        }
    //        return m_instance;
    //    }
    //}

    //private InputController m_InputController;
    //public InputController InputController
    //{
    //    get
    //    {
    //        if (m_InputController == null)
    //            m_InputController = gameObject.GetComponent<InputController>();

    //        return m_InputController;
    //    }
    //}

    //private Player m_LocalPlayer;
    //public Player LocalPlayer
    //{
    //    get
    //    {
    //        return m_LocalPlayer;
    //    }
    //    set
    //    {
    //        m_LocalPlayer = value;
    //        if (OnLocalPlayerJoined != null)
    //            OnLocalPlayerJoined(m_LocalPlayer);
    //    }
    //}

    public static GameManager Instance;
    public InputController InputController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
            

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        InputController = GetComponent<InputController>();
    }
}
