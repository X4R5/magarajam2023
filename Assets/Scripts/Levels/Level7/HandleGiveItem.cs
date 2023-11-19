using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleGiveItem : MonoBehaviour
{
    [SerializeField] Sprite _itemIconToGive;
    [SerializeField] GameObject _textToShow;
    private void OnEnable()
    {
        InventoryManager.Instance.CollectObject(_itemIconToGive);
        _textToShow.SetActive(true);
        Invoke("HideText", 3f);
        Invoke("DestroyThisGameObject", 3.2f);

    }

    void DestroyThisGameObject()
    {
        Destroy(this.gameObject);
    }

    void HideText()
    {
        _textToShow.SetActive(false);
    }
}
