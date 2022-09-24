[System.Serializable]
public class GameData
{
    public int sceneIndex;
    public int badOrder;
    public float master, music, sfx;
    public float score;

    public GameData(Save save)
    {
        badOrder = save.badOrder;
        sceneIndex = save.sceneIndex;
        master = save.master;
        music = save.music;
        sfx = save.sfx;
        score = save.score;
    }
}