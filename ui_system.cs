using UnityEngine;
using UnityEngine.UI;
public class UISystem : MonoBehaviour
{    
      public Text healthText;    
      public Text questLogText;    
      public void UpdateHealth(int health)    
{        
      healthText.text = "Health: " + health.ToString();    
      }    
      public void UpdateQuestLog(string questLog)    
      {        
            questLogText.text = questLog;    
      }
}