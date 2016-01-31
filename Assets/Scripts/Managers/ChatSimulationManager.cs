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
            ":user2!user2@user2.tmi.twitch.tv PRIVMSG #kamadake :--lane 1",

            ":user1!user1@user1.tmi.twitch.tv PRIVMSG #kamadake :--lane 3",

            ":user3!user3@user3.tmi.twitch.tv PRIVMSG #kamadake :--register",
            ":user3!user3@user3.tmi.twitch.tv PRIVMSG #kamadake :--lane 2",

            ":user4!user4@user4.tmi.twitch.tv PRIVMSG #kamadake :this looks like a fun game. how do i play?",
            ":user1!user1@user1.tmi.twitch.tv PRIVMSG #kamadake :use the --register command",
            ":user4!user4@user4.tmi.twitch.tv PRIVMSG #kamadake :cool! thanks mate --register",
            ":user4!user4@user4.tmi.twitch.tv PRIVMSG #kamadake :i'm in :D",
            ":user4!user4@user4.tmi.twitch.tv PRIVMSG #kamadake :--lane 1",

            ":user5!user5@user5.tmi.twitch.tv PRIVMSG #kamadake :--register",
            ":user5!user5@user5.tmi.twitch.tv PRIVMSG #kamadake :goto --lane 2 please",

            ":user6!user6@user6.tmi.twitch.tv PRIVMSG #kamadake :go--register",
            ":user6!user6@user6.tmi.twitch.tv PRIVMSG #kamadake :--registerPls",
            ":user6!user6@user6.tmi.twitch.tv PRIVMSG #kamadake :woops, --register",
            ":user6!user6@user6.tmi.twitch.tv PRIVMSG #kamadake :--lane 35",
            ":user6!user6@user6.tmi.twitch.tv PRIVMSG #kamadake :ohh man, i meant --lane 3",
        };

        void Start()
        {
            StartCoroutine(SimulateChat());
        }

        IEnumerator SimulateChat()
        {
            foreach (string chatLine in chatLines)
            {
                yield return new WaitForSeconds(Random.Range(1f, 3f));

                ChatManager.ParseRawMessage(chatLine);
            }
        }
    }
}