using UnityEngine;

public class nodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public void SetTarget(Node Targetnode)
    {
        target = Targetnode;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
