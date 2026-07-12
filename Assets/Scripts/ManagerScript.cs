using UnityEngine;
using System.Collections.Generic;

public class ManagerScript : MonoBehaviour
{
    public TaskScript TS;

    public List<GameObject> taskList = new List<GameObject>();
    public List<string> taskNames = new List<string>();
    public string[] taskStrings;
    public Transform[] teleportMarks;

    [SerializeField] private GameObject _task;
    [SerializeField] private Transform _taskContainer;
    private int _maxTaskAmount = 5;

    private void Start()
    {
        for (int i=0;i<_maxTaskAmount;i++)
        {
            taskList.Add(null);
        }

        TaskNameMaker();
    }

    public void AddTask()
    {;
        int nr = 0;

        for (int i=0;i<_maxTaskAmount;i++)
        {
            if (taskList[i] != null) continue;

            GameObject taskObject = Instantiate(_task.gameObject, _taskContainer);
            TaskScript taskScript = taskObject.GetComponent<TaskScript>();
            //taskList.Add(taskObject);
            taskList[i] = taskObject;
            taskObject.transform.position = teleportMarks[i].position;
            taskScript.TaskNumberSet(nr);
            taskScript.Initialize(this, nr);
            nr++;
        }
    }

    public void ModifyTask()
    {

    }

    public void RemoveTask(int number)
    {
        /*for (int i=0;i<_maxTaskAmount;i++)
       {
           GameObject task = taskList[i];
           TaskScript taskScript = GetComponent<TaskScript>();
           if (i == taskScript._taskNumber)
           {
               taskList.RemoveAt(i);
               Destroy(task.gameObject);
           }                    
       }
       */
        Destroy(taskList[number].gameObject);
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
