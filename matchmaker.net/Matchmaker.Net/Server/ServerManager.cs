﻿using Matchmaker.Net.Client;
using Matchmaker.Net.Debug;
using Matchmaker.Net.Enums;
using Matchmaker.Net.Network;
using System.Collections.Generic;

namespace Matchmaker.Net.Server
{
    public static class ServerManager
    {
        public static Queue<DelayedQueueConnection> queuedClients = new Queue<DelayedQueueConnection>();
        private static int _currentlyOperatingClients = 0;

        public static bool ClientCanConnect()
        {
            if (((_currentlyOperatingClients < Configuration.ServerVariables.MAX_CLIENTS_CONNECTED) && queuedClients.Count == 0) || Configuration.ServerVariables.MAX_CLIENTS_CONNECTED < 0)
                return true;
            else
                return false;
        }

        public static void ConnectClient()
        {
            _currentlyOperatingClients++;
            Logging.errlog("Active clients updated: " + _currentlyOperatingClients + "/" + Configuration.ServerVariables.MAX_CLIENTS_CONNECTED, ErrorSeverity.ERROR_INFO);
        }

        public static void DiconnectClient()
        {
            if (_currentlyOperatingClients > 0)
            {
                _currentlyOperatingClients--;
                Logging.errlog("Active clients updated: " + _currentlyOperatingClients + "/" + Configuration.ServerVariables.MAX_CLIENTS_CONNECTED, ErrorSeverity.ERROR_INFO);
            }
        }

        public static int GetOpenSlots()
        {
            return Configuration.ServerVariables.MAX_CLIENTS_CONNECTED - _currentlyOperatingClients;
        }

        public static void Launch(ServerOperation definedServerOperations)
        {
            Configuration.ServerVariables.IDENTITY = new UUID();
            SocketManager serverSocket = new SocketManager(Configuration.ServerVariables.PORT, definedServerOperations);
        }
    }
}