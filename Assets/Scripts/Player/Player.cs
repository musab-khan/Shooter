using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    public testCrosshair test;

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Senstivity;
    }

    [SerializeField] float speed = 0;
    [SerializeField] MouseInput MouseControl;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
                m_MoveController = GetComponent<MoveController>();
            return m_MoveController;
        }
    }



    private CrossHair m_CrossHair;
    private CrossHair CrossHair {
        get
        {
            if (m_CrossHair == null)
                m_CrossHair = GetComponentInChildren<CrossHair>();
            return m_CrossHair;
        }
    }
    InputController playerInput;
    Vector2 mouseInput;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Senstivity.x);

        //test.LookHeight(mouseInput.y * MouseControl.Senstivity.y);

    }
}
