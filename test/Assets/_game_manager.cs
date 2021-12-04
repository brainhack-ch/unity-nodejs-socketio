using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _game_manager : MonoBehaviour
{
    public _player_manager pm_;

    // Start is called before the first frame update
    void Start()
    {
        pm_ = GameObject.Find("_game_manager").GetComponent<_player_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void _command_processing(string in_s)
    {
        string[] splitArray = in_s.Split(char.Parse(" "));

        switch (splitArray[1])
        {
            case "newp": // new player
                pm_.add_new_player(splitArray[2], splitArray[3]);
                break;
            case "mvto": // go to target
                //pm_.add_new_player(splitArray[0], splitArray[1]);
                pm_.move_player_to(splitArray[2], splitArray[3]);
                break;
            case "oktier": // correct answer given
                pm_.validate_answer(splitArray[2], splitArray[3]);
                break;
            case "npctier": // incorrect answer given
                pm_.wrong_answer(splitArray[2], splitArray[3]);
                break;

        }
    }
}
