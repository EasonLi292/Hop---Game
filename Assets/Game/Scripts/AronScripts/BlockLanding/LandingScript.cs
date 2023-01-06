using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingScript : MonoBehaviour
{
    private bool rewarded = false;

    public BonusScript bonus; 

    // Start is called before the first frame update
    void Start()
    {
        rewarded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            // Bonus
            if (!rewarded) {
                // Reward player for landing on cube 
                FindObjectOfType<ScoreManager>().IncreaseScore(1);
                JumpInfo.LandingCounter++;
                rewarded = true;

                // Spawn New Block
                FindObjectOfType<BlockSpawnManager>().NewBlock();
                
                // Allow player to move again 
                FindObjectOfType<FloatingController>().SetCanMove(true);
                
                // Wait before checking Perfect Landing to ensure all Collission Triggers have occured safely
                Invoke("CheckPL", 0.25f);
            } 
        }
    }

    // !Only Checked Once due to Rewarded Boolean!
    // Checks if the Landing was Perfect 
    public void CheckPL() {
        if (bonus.PLTriggered()) {
            JumpInfo.TotalPLCounter++;
            JumpInfo.ConsecutivePLcounter++;

            // NEW BEST
            if (JumpInfo.ConsecutivePLcounter > JumpInfo.BestConsecutivePL) {
                JumpInfo.BestConsecutivePL = JumpInfo.ConsecutivePLcounter;
            }

            // ADD SCORE BASED ON CONSECUTIVE (already have +1 for landing) 
            if (JumpInfo.ConsecutivePLcounter < 5 && JumpInfo.ConsecutivePLcounter > 0) {
                FindObjectOfType<ScoreManager>().IncreaseScore(JumpInfo.ConsecutivePLcounter);
            } 
            
            // MAX WE CAN ADD IS +4 for PLs
            else if (JumpInfo.ConsecutivePLcounter > 5) {
                FindObjectOfType<ScoreManager>().IncreaseScore(4);
            }
        } 
        // Player didn't land a perfect landing
        else {
            JumpInfo.ConsecutivePLcounter = 0;
        }
    }
}
