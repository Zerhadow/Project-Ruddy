using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string name;
    public string description;
    public int objective;
    public int progress;
    public bool completed;

}

public class Quest : MonoBehaviour
{
    public List<Quest> quests;
    private int enemiesSlain;

    public void UpdateQuestProgress(int objectiveValue)
    {
        enemiesSlain++;

        foreach (Quest quest in quests)
        {
            if (!quest.completed && enemiesSlain >= quest.objective)
            {
                quest.progress = quest.objective;
                quest.completed = true;
                Debug.Log("Quest " + quest.name + " completed!");
                // Give player reward
            }
        }
        // if enemies slain divisible by 2, find or create quest that matches objective
        if (enemiesSlain % 2 == 0 && enemiesSlain < 10)
        {
            // Increment the objective for the next quest
            int nextObjective = (enemiesSlain / 2) + 1;

            // Check if a quest with this objective exists
            bool foundQuest = false;
            foreach (Quest quest in quests)
            {
                if (quest.objective == nextObjective)
                {
                    foundQuest = true;
                    break;
                }
            }

            // If a quest does not exist with this objective, create a new one
            if (!foundQuest)
            {
                Quest newQuest = new Quest();
                newQuest.name = "Defeat " + nextObjective + " Enemies";
                newQuest.description = "Defeat " + nextObjective + " enemies to complete this quest.";
                newQuest.objective = nextObjective;
                quests.Add(newQuest);
            }
        }
        // If all enemies have been slain, mark last quest as completed
        if (enemiesSlain == 10)
        {
            Quest lastQuest = quests[quests.Count - 1];
            lastQuest.completed = true;
            Debug.Log("Quest " + lastQuest.name + " completed! You win!");
            // Give player reward for completing game
        }
    }
}

public class Enemy : MonoBehaviour
{
    public QuestManager questManager;

    private void OnDestroy()
    {
        // Notify the quest manager that an enemy has been slain
        questManager.UpdateQuestProgress(1);
    }
}

