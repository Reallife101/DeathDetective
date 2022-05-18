using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveJournal
{
    public static bool dataExists()
    {
        return File.Exists(Path.Combine(Application.persistentDataPath, "journal.data"));
    }

    public static void deleteFile()
    {
        if( File.Exists(Path.Combine(Application.persistentDataPath, "journal.data")))
        {
            File.Delete(Path.Combine(Application.persistentDataPath, "journal.data"));
        }
    }

    public static void SaveJournal(JournalManager jm)
    {
        journalData data = new journalData(jm);

        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "journal.data")))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
        }
    }

    public static void SaveJournal(journalData md)
    {
        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "journal.data")))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, md);
        }
    }

    public static journalData loadJournal()
    {
        journalData data = null;
        using (FileStream fs = File.Open(Path.Combine(Application.persistentDataPath, "journal.data"), FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            data = formatter.Deserialize(fs) as journalData;
        }

        return data;
    }
}
