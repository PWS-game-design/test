using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        ClearList();
    }
public List<GameObject> menus = new();

    public void AddLastMenu(GameObject obj)
    {
        menus.Add(obj);
    }
    public void ReturnToLastMenu()
    {
        int count = menus.Count - 1;
        menus[count].SetActive(true);
        menus.RemoveAt(count);

    }
    public void ClearList()
    {
        menus.Clear();
    }
}
