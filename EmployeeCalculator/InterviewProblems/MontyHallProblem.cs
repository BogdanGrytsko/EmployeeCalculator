namespace EmployeeCalculator.InterviewProblems;

public class MontyHallProblem
{
    public static (int, int) Simultate(int numberOfTries)
    {
        var wins = 0;
        var losses = 0;
        for (int i = 0; i < numberOfTries; i++)
        {
            if (SimulateOneTry())
                wins++;
            else
                losses++;
        }
        return (wins, losses);
        
    }

    private static bool SimulateOneTry()
    {
        var rnd = new Random();
        var doors = new List<int> { 0, 0, 0 };
        var prizeDoor = rnd.Next(3);
        doors[prizeDoor] = 1;
        // Player picks a door
        var playerDoorChoiceInitial = rnd.Next(3);
        var hostCanReveal = new List<int>();
        for (int i = 0; i < doors.Count; i++)
        {
            if (doors[i] == 1) continue;
            if (i == playerDoorChoiceInitial) continue;
            hostCanReveal.Add(i);
        }

        var revealDoor = hostCanReveal[rnd.Next(hostCanReveal.Count)];

        //option 1: stay with the door
        //option 2: choose another door
        var allDoorsIndexes = new List<int> { 0, 1, 2 };
        var playerDoorChoiceChanged = allDoorsIndexes.Except(new List<int> { playerDoorChoiceInitial, revealDoor }).Single();

        var result = doors[playerDoorChoiceChanged] == 1;
        return result;
    }
}
