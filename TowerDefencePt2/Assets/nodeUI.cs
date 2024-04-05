using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class nodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Button upgradeButton;

public TextMeshProUGUI upgradeCost;
    public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		} else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}
		ui.SetActive(true);
	}

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrage()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
