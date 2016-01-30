using Assets.Scripts.Commands;
using System;

namespace Assets.Scripts.Controllers
{
    public static class CommandRouter
    {
        /// <summary>
        /// Routes a Command according to its type to the appropriate endpoint.
        /// </summary>
        /// <param name="command">
        /// The ICommand to route.
        /// </param>
        public static void RouteCommand(ICommand command)
        {
            if (command == null || String.IsNullOrEmpty(command.UserName))
                return;

            MoveCommand move = command as MoveCommand;
            if (move != null)
            {
                GameController.Instance.GoToLane(command.UserName, move.LaneNumber);
                return;
            }

            RegisterCommand register = command as RegisterCommand;
            if (register != null)
            {
                GameController.Instance.RegisterPlayer(command.UserName);
                return;
            }
        }
    }
}