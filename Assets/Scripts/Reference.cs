using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reference : MonoBehaviour
{
    public Joystick joystick;
    public Joystick aimstick;
    public Player player;
    public Slider energySlider;
    public Slider healthSlider;
    public Text energyText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.maxEnergy != 0 && player.maxHp != 0)
        {
            energySlider.value = player.energy / player.maxEnergy;
            healthSlider.value = player.hp / player.maxHp;
        }
        
        energyText.text = "Energy: " + Mathf.Floor(player.energy) + "/" + Mathf.Floor(player.maxEnergy);
        healthText.text = "Hp: " + Mathf.Floor(player.hp) + "/" + Mathf.Floor(player.maxHp);
    }
}
