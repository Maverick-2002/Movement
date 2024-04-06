[System.Serializable]
public class PlayerProgress
{
    public int CurrentMissionID;
    public int LastMissionID;
    public int totalplaytime;
    public int Score;
    public BallSpawner ball;

    public void DummyData()
    {
        totalplaytime = 0;
        CurrentMissionID = 0;
        LastMissionID = 0;
        ball.playerScore = 0;
        ball.playerLives = 0;
    }
}

