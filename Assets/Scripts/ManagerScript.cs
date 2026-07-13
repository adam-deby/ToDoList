using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

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
    private bool hasLoaded;

    private void Start()
    {
        inputObject.SetActive(false);
        TaskNameMaker();
        inputField.onSubmit.AddListener(ChangeText);
    }

    public void AddTask()
    {
        for (int i = 0; i < taskNames.Count; i++)
        {
            if (hasLoaded && taskList[i] != null) continue;

            GameObject taskObject = Instantiate(_task.gameObject, _taskContainer);

            if (!hasLoaded) taskList.Add(taskObject);
            else taskList[i] = taskObject;
            
            TaskScript taskScript = taskObject.GetComponent<TaskScript>();

            taskObject.transform.position = teleportMarks[i].position;
            taskScript.Initialize(this, i);

            taskScript._taskText.text = taskNames[i];
        }

        if (!hasLoaded) hasLoaded = true;
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
        TaskNamesSave();
        inputObject.SetActive(false);
    }

    private void TaskNameMaker()
    {
        string path = Path.Combine(Application.persistentDataPath, "save.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            taskNames = saveData.taskNames;
        }
        else
        {
            for (int i=0;i<_maxTaskAmount;i++)
            {
                taskNames.Add(null);
            }

            for (int i = 0; i < _maxTaskAmount; i++)
            {
                string text;

                do
                {
                    int roll = Random.Range(0, taskStrings.Length);
                    text = taskStrings[roll];
                }
                while (taskNames.Contains(text));

                taskNames[i] = text;
            }

            TaskNamesSave();
        }

    }

    public void TaskNamesSave()
    {
        SaveData saveDataa = new SaveData();
        saveDataa.taskNames = taskNames;

        string jsonn = JsonUtility.ToJson(saveDataa, true);

        string pathh = Path.Combine(Application.persistentDataPath, "save.json");

        File.WriteAllText(pathh, jsonn);

        Debug.Log(pathh);
    }
}
