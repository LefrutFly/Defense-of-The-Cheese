using UnityEngine;

public class Statistics
{
    private const string KEY = "StatisticsKey";

    public StatisticsData data { get; private set; } = new StatisticsData();

    public float TimeNow = 0;
    public int KillsNow = 0;
    public int BulletsNow = 0;


    public void WriteTime()
    {
        if (TimeNow > data.TimeBest)
        {
            data.TimeBest = TimeNow;
        }

        Save();
    }

    public void WriteKills()
    {
        if (KillsNow > data.KillsBest)
        {
            data.KillsBest = KillsNow;
        }

        Save();
    }

    public void WriteBullets()
    {
        if (BulletsNow > data.BulletsBest)
        {
            data.BulletsBest = BulletsNow;
        }

        Save();
    }

    public void LoadStatistics()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            string json = PlayerPrefs.GetString(KEY);

            data = JsonUtility.FromJson<StatisticsData>(json);
        }
        else
        {
            data = new StatisticsData();
        }
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(KEY, json);

        PlayerPrefs.Save();
    }
}