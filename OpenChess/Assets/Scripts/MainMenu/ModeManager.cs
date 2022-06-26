using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct Mode
{
    public string name;

    [TextArea(8, 16)]
    public string board;

    [TextArea(8, 16)]
    public string pieces;
}

public class ModeManager : MonoBehaviour
{
    

    public GameObject modeButtonPrefab;
    public Transform grid;


    [SerializeField]
    public List<Mode> allModes = new List<Mode>();
    private void Awake()
    {
        CreateBaseFiles();
        ReadAllFiles();
    }
    public void CreateBaseFiles()
    {
        string modesPath = Application.persistentDataPath + "/Modes";

        Directory.CreateDirectory(modesPath);

        for (int i = 0; i < allModes.Count; i++)
        {
            string currentModePath = modesPath + "/" + allModes[i].name;

            Debug.Log("basic Mode created at: " + currentModePath);

            Directory.CreateDirectory(currentModePath);

            File.WriteAllText(currentModePath+"/board.txt", allModes[i].board);

            File.WriteAllText(currentModePath + "/pieces.txt", allModes[i].pieces);
           
        }

    }

    public void ReadAllFiles()
    {
        string modesPath = Application.persistentDataPath + "/Modes";

        string[] paths = Directory.GetDirectories(modesPath);

        for (int i = 0; i<paths.Length; i++)
        {
            string name = paths[i].Split('\\')[1];

            string board = "";
            string pieces = "";

            if (File.Exists(paths[i]+"/board.txt") && File.Exists(paths[i] + "/pieces.txt"))
            {
                board = File.ReadAllText(paths[i] + "/board.txt");
                pieces = File.ReadAllText(paths[i] + "/pieces.txt");
            }
            else
            {
                Debug.LogError("Files -board.txt- or -pieces.txt- does'nt exist int the mode: " + name);
                continue;
            }

            PlayButton button = Instantiate(modeButtonPrefab, grid).GetComponent<PlayButton>();

            Mode newMode;
            newMode.name = name;
            newMode.board = board;
            newMode.pieces = pieces;

            button.Init(newMode);
        }
    }

}
