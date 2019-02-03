using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    [SerializeField] private CollectibleList collectibleType;
    [SerializeField] private int valuePoint = 0;

	private CollectibleList collectibleSelected;
    void Start() { 
		collectibleSelected = collectibleType;
	}

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            switch (collectibleSelected)
            {
                case CollectibleList.IsMoney:
                    // Add Money 
                    break;
                case CollectibleList.IsMoneyBag:
                    // Add large Money
                    break;
                case CollectibleList.IsHealth:
                    // Add Health
                    break;
                case CollectibleList.IsMagnet:
                    // Enable Magnet
                    break;
                case CollectibleList.IsAmo:
                    // Increase Fire Rate
                    break;
            }
        }

        SimplePoolManager.instance.DisablePoolObject(transform);
    }
}

public enum CollectibleList
{
    IsMoney,
    IsMoneyBag,
    IsHealth,
    IsMagnet,
    IsAmo

}