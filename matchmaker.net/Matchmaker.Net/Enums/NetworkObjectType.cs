﻿using System;

namespace Matchmaker.Net.Enums
{
    [Serializable]
    public enum NetObjectType
    {
        CLIENT_REQUEST_SERVER_LIST,
        CLIENT_SERVER_RESPONSE_GENERIC,
        CLIENT_SERVER_REGISTER_SERVER,
        CLIENT_SERVER_UNREGISTER_SERVER,
        CLIENT_SERVER_MODIFY_REGISTERED_SERVER,
        SERVER_SEND_MATCHMAKE
    }
}
