using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public struct Mode
{
    public string name;

    [TextArea(8, 16)]
    public string board;

    [TextArea(8, 16)]
    public string pieces;
}

public enum adversaryMode
{
    Friend, Cpu
}

public class ModeManager : MonoBehaviour
{
    public TMP_Dropdown adversaryDrop;

    adversaryMode adversary;




    public TMP_Dropdown modeDrop;

    static List<Mode> allmodes = new List<Mode>();

    private void Awake()
    {
        Debug.Log("Persistent data path: "+Application.persistentDataPath);


        allmodes.Clear();

        CreateBaseFiles();

        List < Mode > Modes = GetModesInFolder(Application.persistentDataPath + "/Modes");

        modeDrop.ClearOptions();

        for (int i = 0; i<Modes.Count; i++)
        {
            allmodes.Add(Modes[i]);
            modeDrop.options.Add(new TMP_Dropdown.OptionData() { text = Modes[i].name });
        }

        adversaryDrop.ClearOptions();

        for(int i = 0; i<adversaryMode.GetValues(adversary.GetType()).Length; i++)
        {
            adversaryDrop.options.Add(new TMP_Dropdown.OptionData() { text = adversary.ToString() });
            adversary = adversary.Next();
        }
    }

    public adversaryMode GetAdversaryMode()
    {
        return (adversaryMode)System.Enum.ToObject(typeof(adversaryMode), adversaryDrop.value);
    }

    public Mode GetCurrentMode()
    {
        return allmodes[modeDrop.value];
    }

   

    public void CreateBaseFiles()
    {
        TextAsset[] textFile = Resources.LoadAll<TextAsset>("Modes");

        List<Mode> basicModes = new List<Mode>();

        Mode currentMode = new Mode();

        int txtByFolder = 3;

        for (int i = 0; i< textFile.Length; i++)
        {
            switch(textFile[i].name)
            {
                case "name":
                    currentMode.name = textFile[i].text;
                    break;
                case "board":
                    currentMode.board = textFile[i].text;
                    break;
                case "pieces":
                    currentMode.pieces = textFile[i].text;
                    break;
            }

            txtByFolder--;


            if (txtByFolder <= 0)
            {
                txtByFolder = 3;
                basicModes.Add(currentMode);
                currentMode = new Mode();
            }
        }


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

    List<Mode> GetModesInFolder(string modesPath)
    {

        Debug.Log("Get modes from: " +modesPath);
        List<Mode> bModes = new List<Mode>();


        string[] paths = Directory.GetDirectories(modesPath);

        for (int i = 0; i < paths.Length; i++)
        {
            paths[i] = paths[i].Replace(@"\", "/");

            string[] allDirs = paths[i].Split('/');

            string name = allDirs[allDirs.Length - 1];


            string board = "";
            string pieces = "";

            if (File.Exists(paths[i] + "/board.txt") && File.Exists(paths[i] + "/pieces.txt"))
            {
                board = File.ReadAllText(paths[i] + "/board.txt");
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

            bModes.Add(newMode);
        }

        return bModes;
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
