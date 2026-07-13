using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ManagerScript : MonoBehaviour
{
    [Header("Lists and strings")]
    [SerializeField] private List<GameObject> taskList = new List<GameObject>();
    [SerializeField] private List<string> taskNames = new List<string>();
    [SerializeField] private string[] taskStrings;
    public TMP_InputField inputField;

    [Header("Gameobjects and transforms")]
    [SerializeField] private GameObject _task;
    [SerializeField] private GameObject inputObject;
    [SerializeField] private Transform[] teleportMarks;
    [SerializeField] private Transform _taskContainer;

    private int _maxTaskAmount = 5;
    private int indexNumber;

    private void Start()
    {
        inputObject.SetActive(false);
        TaskNameMaker();
        inputField.onSubmit.AddListener(ChangeText);
    }

    public void AddTask()
    {;
        for (int i=0;i<_maxTaskAmount;i++)
        {
            if (taskList[i] != null) continue;

            GameObject taskObject = Instantiate(_task.gameObject, _taskContainer);
            TaskScript taskScript = taskObject.GetComponent<TaskScript>();
            taskList[i] = taskObject;
            taskObject.transform.position = teleportMarks[i].position;
            taskScript.Initialize(this, i);

            taskScript._taskText.text = taskNames[i];
        }
    }

    public void CompleteTask(int number)
    {
        GameObject taskObject = taskList[number];
        TaskScript taskScript = taskObject.GetComponent<TaskScript>();

        taskScript.ToggleCompleted();
    }

    public void RemoveTask(int number)
    {
        Destroy(taskList[number]);
        taskList[number] = null;
    }

    public void RenameTask(int number)
    {
        inputObject.SetActive(true);
        indexNumber = number;
    }

    private void ChangeText(string text)
    {
        GameObject taskObject = taskList[indexNumber];
        TaskScript taskScript = taskObject.GetComponent<TaskScript>();
        taskScript._taskText.text = text;
        taskNames[indexNumber] = text;
        inputField.text = "";
        inputObject.SetActive(false);
    }

    private void TaskNameMaker()
    {
        for (int i = 0; i < _maxTaskAmount; i++)
        {
            taskList.Add(null);

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
