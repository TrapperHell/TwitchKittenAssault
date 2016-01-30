using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ChatSimulationManager : MonoBehaviour
    {
        string[] chatLines = new string[]
        {
        ":user1!user1@user1.tmi.twitch.tv PRIVMSG #kamadake :hello folks",
        ":user1!user1@user1.tmi.twitch.tv PRIVMSG #kamadake :--register",
        ":user2!user2@user2.tmi.twitch.tv PRIVMSG #kamadake :--register",
        ":user1!user1@user1.tmi.twitch.tv PRIVMSG #kamadake :--lane 2",
        ":user3!user3@user3.tmi.twitch.tv PRIVMSG #kamadake :--register",
        };

        void Start()
        {
            StartCoroutine(SimulateChat());
        }

        IEnumerator SimulateChat()
        {
            foreach (string chatLine in chatLines)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 2f));

                ChatManager.ParseRawMessage(chatLine);
            }
        }
    }
}