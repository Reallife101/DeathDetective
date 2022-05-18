using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveJournal
{
    public static bool dataExists()
    {
        return File.Exists(Application.persistentDataPath + "/journal.data");
    }

    public static void SaveJournal(JournalManager jm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/journal.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        journalData data = new journalData(jm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveJournal(journalData md)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/journal.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, md);
        stream.Close();
    }

    public static journalData loadJournal()
    {
        string path = Application.persistentDataPath + "/journal.data";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        journalData data = formatter.Deserialize(stream) as journalData;
        stream.Close();

        return data;
    }
}
