using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color StartColor;
    public Vector3 positionOffset;
    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Remove Existing Structure");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        else
        {
        rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

}
