using UnityEngine;
using System.Collections.Generic;

public class ManagerScript : MonoBehaviour
{

    public List<GameObject> taskList = new List<GameObject>();
    public List<string> taskNames = new List<string>();
    public string[] taskStrings;

    [SerializeField] private GameObject _task;
    private int _maxTaskAmount = 5;

    private void Start()
    {
        TaskNameMaker();
    }

    public void AddTask()
    {
        if (taskList.Count >= _maxTaskAmount) return;
        taskList.Add(_task);
    }

    public void ModifyTask()
    {

    }

    public void RemoveTask()
    {
        
    }

    private void TaskNameMaker()
    {
        for (int i = 0; i < _maxTaskAmount; i++)
        {
            string text;

            do
            {
                int roll = Random.Range(0, taskStrings.Length);
                text = taskStrings[roll];
            }
            while (taskNames.Contains(text));

            taskNames.Add(text);
        }
    }
}
