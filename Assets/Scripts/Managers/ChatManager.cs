using Assets.Scripts.Commands;
using Assets.Scripts.Controllers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class ChatManager
    {
        const string RAW_MESSAGE_REGEX = @"@(?<userName>[\w]*)\.tmi\.twitch\.tv\sPRIVMSG\s#kamadake\s:(?<text>[\w\W]*?)$";

        static readonly Dictionary<string, Func<Match, ICommand>> _commandDictionary = new Dictionary<string, Func<Match, ICommand>>()
        {
            // Register Command
            {
                @"\B--register\b", ((msg) =>
                {
                    return new RegisterCommand();
                })
            },

            // Lane Command
            {
                @"\B--lane[\s]?(?<lane>[\d]+?)\b", ((msg) =>
                {
                    if(msg.Groups.Count == 2)
                    {
                        int laneNumber;
                        if(int.TryParse(msg.Groups[1].Value, out laneNumber))
                            return new MoveCommand() {LaneNumber = laneNumber };
                    }
                    return null;
                })
            }
        };

        /// <summary>
        /// Parses a raw chat message such that it is able to extract the username of the
        /// message sender, and the content of the message itself.
        /// </summary>
        /// <param name="rawMessage">
        /// The raw chat message (including the sender username and channel name).
        /// </param>
        public static void ParseRawMessage(string rawMessage)
        {
            if (String.IsNullOrEmpty(rawMessage))
                return;

            Match msgMatch = Regex.Match(rawMessage, RAW_MESSAGE_REGEX);

            if (msgMatch.Success && msgMatch.Groups != null && msgMatch.Groups.Count == 3)
            {
                string userName = msgMatch.Groups[1].Value;
                string message = msgMatch.Groups[2].Value;

                ICommand command = ParseMessage(message);
                if (command != null)
                {
                    Debug.Log(String.Format("{0} says '{1}' => {2}", userName, message, command.GetType().Name));

                    command.UserName = userName;

                    CommandRouter.RouteCommand(command);
                }
                else
                    Debug.Log(String.Format("{0} says '{1}' => ?", userName, message));
            }
        }

        /// <summary>
        /// Tries out the message against a known set of regular expressions in an
        /// attempt to retrieve an ICommand.
        /// </summary>
        /// <param name="message">
        /// The chat message sent by a user.
        /// </param>
        /// <returns>
        /// Returns a formatted ICommand from the given message (or null).
        /// </returns>
        static ICommand ParseMessage(string message)
        {
            if (String.IsNullOrEmpty(message) || !message.Contains("--"))
                return null;

            foreach (var matchComm in _commandDictionary)
            {
                Match match = Regex.Match(message, matchComm.Key);

                if (match.Success && match.Groups != null)
                {
                    ICommand command = matchComm.Value(match);

                    if (command != null)
                        return command;
                }
            }

            return null;
        }
    }
}