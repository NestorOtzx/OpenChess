using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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

    public List<Mode> basicModes = new List<Mode>();
    private void Awake()
    {
        CreateBaseModes();
        CreateBaseFiles();
        ReadAllFiles();
    }

    void CreateBaseModes()
    {
        string modesPath = Application.dataPath + "/Modes";

        Debug.Log(modesPath);

        string[] paths = Directory.GetDirectories(modesPath);

        for (int i = 0; i < paths.Length; i++)
        {
            paths[i].Replace("\\", "/");

            string [] allDirs =paths[i].Split('/');

            string name = allDirs[allDirs.Length-1];

            Debug.Log(name);

            string board = "";
            string pieces = "";

            if (File.Exists(paths[i] + "/board.txt") && File.Exists(paths[i] + "/pieces.txt"))
            {
                board = File.ReadAllText(paths[i] + "/board.txt");
                Debug.Log(Path.GetDirectoryName(paths[i]+"/board.txt"));
                pieces = File.ReadAllText(paths[i] + "/pieces.txt");
            }
            else
            {
                Debug.LogError("Files -board.txt- or -pieces.txt- does'nt exist int the mode: " + name);
                continue;
            }

            Mode newMode;
            newMode.name = name;
            newMode.board = board;
            newMode.pieces = pieces;

            basicModes.Add(newMode);
        }
    }

    public void CreateBaseFiles()
    {
        string modesPath = Application.persistentDataPath + "/Modes";

        Directory.CreateDirectory(modesPath);

        for (int i = 0; i < basicModes.Count; i++)
        {
            string currentModePath = modesPath + "/" + basicModes[i].name;

            Directory.CreateDirectory(currentModePath);

            File.WriteAllText(currentModePath+"/board.txt", basicModes[i].board);

            File.WriteAllText(currentModePath + "/pieces.txt", basicModes[i].pieces);
           
        }

    }

    public void ReadAllFiles()
    {
        string modesPath = Application.persistentDataPath + "/Modes";

        string[] paths = Directory.GetDirectories(modesPath);

        for (int i = 0; i<paths.Length; i++)
        {
            paths[i].Replace("\\", "/");

            string [] allDirs =paths[i].Split('/');

            string name = allDirs[allDirs.Length-1];

            Debug.Log(name + " 2");

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

    //Only used for debug purposes.
    public static Mode GetDefMode()
    {
        string modePath = Application.dataPath + "/Modes/Classic";

        string board = File.ReadAllText(modePath + "/board.txt");
        string pieces = File.ReadAllText(modePath + "/pieces.txt");

        Mode newMode;
        newMode.name = "Default";
        newMode.board = board;
        newMode.pieces = pieces;

        return newMode;
    }

}
