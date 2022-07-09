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

public enum playMode
{
    Player_Vs_Player, Player_Vs_Cpu, Cpu_Vs_Cpu
}

public class ModeManager : MonoBehaviour
{
    public TMP_Dropdown gameModeDrop;

    static List<Mode> allGameModes = new List<Mode>();

    public TMP_Dropdown playModeDrop;

    playMode playmode;


    private void Awake()
    {
        Debug.Log("Persistent data path: " + Application.persistentDataPath);

        allGameModes.Clear();
        gameModeDrop.ClearOptions();
        playModeDrop.ClearOptions();

        CreateBaseModes();
        GameModesToDropDown();
        PlayModesToDD();
    }


    //Create basic modes in folder.
    private void CreateBaseModes()
    {
        Mode[] basicModes = GetBaseModes();

        string modesPath = Application.persistentDataPath + "/Modes";

        Directory.CreateDirectory(modesPath);

        for (int i = 0; i < basicModes.Length; i++)
        {
            string currentModePath = modesPath + "/" + basicModes[i].name;

            Directory.CreateDirectory(currentModePath);

            File.WriteAllText(currentModePath + "/board.txt", basicModes[i].board);

            File.WriteAllText(currentModePath + "/pieces.txt", basicModes[i].pieces);
        }
    }

    //Read the folder and add all the modes to dropdown
    private void GameModesToDropDown()
    {
        List<Mode> Modes = GetModesInFolder(Application.persistentDataPath + "/Modes");


        for (int i = 0; i < Modes.Count; i++)
        {
            allGameModes.Add(Modes[i]);
            gameModeDrop.options.Add(new TMP_Dropdown.OptionData() { text = Modes[i].name });
        }
    }



    private void PlayModesToDD()
    {
        for (int i = 0; i < playMode.GetValues(playmode.GetType()).Length; i++)
        {
            //Allow to replace _ with spaces " ".
            string dropText = playmode.ToString().Replace("_", " ");

            playModeDrop.options.Add(new TMP_Dropdown.OptionData() { text = dropText });
            playmode = playmode.Next();
        }
    }



    //Get all default modes from Rosources folder
    static Mode [] GetBaseModes()
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


        return basicModes.ToArray();
    }

    //Get all modes in some folder
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

    //Only used when you start the editor from the board scene
    public static Mode GetBaseMode(int mode)
    {
        return GetBaseModes()[mode];
    }

    public playMode GetPlayMode()
    {
        return (playMode)System.Enum.ToObject(typeof(playMode), playModeDrop.value);
    }

    public Mode GetCurrentGameMode()
    {
        return allGameModes[gameModeDrop.value];
    }
}
