using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager instance = null;
    private Animator spAnimator;
    private bool skillOpened = false;

    [SerializeField]
    private GameObject skillPanel;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("no instance");
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spAnimator = skillPanel.GetComponent<Animator>();
        CloseSkill();
    }

    public void ToggleSkill()
    {
        if(skillOpened)
        {
            CloseSkill();
            skillOpened = false;
        }
        else
        {
            OpenSkill();
            skillOpened = true;
        }
    }

    private void OpenSkill()
    {
        spAnimator.SetTrigger("Open");
    }

    private void CloseSkill()
    {
        spAnimator.SetTrigger("Close");
    }

    public void Jump()
    {
        GameManager.Instance.GetPlayer().Jump();
    }

}
