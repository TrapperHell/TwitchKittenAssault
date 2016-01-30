using System;
using System.Linq;
using UnityEngine;

namespace WaypointControl
{
    public class TokenMoveManager
    {
        static readonly string[] _laneNames = new string[] { "1-2", "2-3", "3-1" };

        public static void MoveToken(GameObject token, string fromTeam, string toTeam)
        {
            FollowDirection direction;
            string pathName = GetPathName(fromTeam, toTeam, out direction);

            if (!String.IsNullOrEmpty(pathName))
                token.transform.FollowPath(pathName, 100f, FollowType.Once, direction);

            /*
            FollowPath() extension methods:
                .Duration(3f)
                .LookForward(true)
                .SmoothLookForward(true, 10f)
                .Flip(true)
                .Log(true)
            */
        }

        private static string GetPathName(string fromTeam, string toTeam, out FollowDirection direction)
        {
            direction = FollowDirection.Forward;

            if (fromTeam == null || toTeam == null)
                return null;

            string laneName = String.Format("{0}-{1}", fromTeam, toTeam);

            if (!_laneNames.Contains(laneName))
            {
                laneName = Reverse(laneName);
                direction = FollowDirection.Backward;
            }

            if (_laneNames.Contains(laneName))
                return laneName;

            return null;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}