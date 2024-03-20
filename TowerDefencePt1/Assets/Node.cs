using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject turret;
    private Renderer rend;
    private Color StartColor;
    public Vector3 positionOffset;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Remove Existing Structure");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild,transform.position + positionOffset,transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

}
