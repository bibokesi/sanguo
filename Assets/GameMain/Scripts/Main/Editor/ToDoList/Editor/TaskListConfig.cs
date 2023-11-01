using UnityEngine;

namespace GameMain.Editor.TaskList
{
    [CreateAssetMenu(fileName = "TodoList", menuName = "GameMain/Todo List", order = 300)]
    public class TaskListConfig : ScriptableObject
    {
#pragma warning disable 0414
        [SerializeField]
        int TaskCount = 0;
#pragma warning disable 0414
        [SerializeField]
        bool[] Mark = new bool[] { };
        [SerializeField]
        bool[] Enabled = new bool[] { };
        [SerializeField]
        int[] Progress = new int[] { };
        [SerializeField]
        string[] Title = new string[] { };
        [SerializeField]
        string[] Description = new string[] { };
    }
}
