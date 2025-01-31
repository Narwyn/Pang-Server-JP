﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.Utilities
{
    public enum STDA_ERROR_TYPE : uint
    {
        WSA,
        _SOCKET,
        SOCKETSERVER,
        IOCP,
        THREAD,
        THREADPOOL,
        THREADPL_SERVER,
        THREADPL_CLIENT,
        _MYSQL,
        _MSSQL,
        _POSTGRESQL,
        MANAGER,
        EXEC_QUERY,
        PANGYA_DB,
        BUFFER,
        PACKET,
        PACKET_POOL,
        PACKET_FUNC,
        PACKET_FUNC_SV,
        PACKET_FUNC_LS,
        PACKET_FUNC_AS,
        PACKET_FUNC_RS,
        PACKET_FUNC_GG_AS,
        PACKET_FUNC_CLIENT,
        FUNC_ARR,
        SESSION,
        SESSION_POOL,
        JOB,
        JOB_POOL,
        UTIL_TIME,
        MESSAGE,
        MESSAGE_POOL,
        LIST_FIFO,
        LIST_FIFO_CONSOLE,
        CRYPT,
        COMPRESS,
        PANGYA_ST,
        PANGYA_GAME_ST,
        PANGYA_LOGIN_ST,
        PANGYA_MESSAGE_ST,
        PANGYA_RANK_ST,
        _IFF,
        CLIENTVERSION,
        SERVER,
        GAME_SERVER,
        LOGIN_SERVER,
        MESSAGE_SERVER,
        AUTH_SERVER,
        RANK_SERVER,
        GG_AUTH_SERVER,
        CLIENT,
        MULTI_CLIENT,
        CLIENTE,
        TIMER,
        TIMER_MANAGER,
        CHANNEL,
        LOBBY,
        ROOM,
        ROOM_GRAND_PRIX,
        ROOM_GRAND_ZODIAC_EVENT,
        ROOM_BOT_GM_EVENT,
        ROOM_MANAGER,
        LIST_ASYNC,
        _RESULT_SET,
        _RESPONSE,
        _ITEM,
        _ITEM_MANAGER,
        GM_INFO,
        PLAYER_INFO,
        PLAYER,
        PLAYER_MANAGER,
        SESSION_MANAGER,
        CLIENTE_MANAGER,
        READER_INI,
        MGR_ACHIEVEMENT,
        MGR_DAILY_QUEST,
        SYS_ACHIEVEMENT,
        NORMAL_DB,
        LOGIN_MANAGER,
        LOGIN_TASK,
        MAIL_BOX_MANAGER,
        PERSONAL_SHOP,
        LOTTERY,
        CARD_SYSTEM,
        COMET_REFILL_SYSTEM,
        PAPEL_SHOP_SYSTEM,
        BOX_SYSTEM,
        MEMORIAL_SYSTEM,
        PACKET_FUNC_MS,
        FRIEND_MANAGER,
        HOLE,
        GAME,
        TOURNEY_BASE,
        VERSUS_BASE,
        PRACTICE,
        CUBE_COIN_SYSTEM,
        COIN_CUBE_LOCATION_SYSTEM,
        TREASURE_HUNTER_SYSTEM,
    }
    public static class ExceptionError
    {
        public static uint STDA_SOURCE_ERROR_ENCODE(uint source_error) => (uint)(((source_error) << 24) & 0xFF000000);
        public static uint STDA_SOURCE_ERROR_DECODE(uint err_code) => (uint)(((err_code) >> 24) & 0x000000FF);
        public static uint STDA_ERROR_ENCODE(uint err) => (uint)(((err) << 16) & 0x00FF0000);
        public static uint STDA_ERROR_DECODE(uint err_code) => (uint)(((err_code) >> 16) & 0x000000FF);
        public static uint STDA_SYSTEM_ERROR_ENCODE(uint _err_sys) => (uint)((_err_sys) & 0x0000FFFF);
        public static uint STDA_SYSTEM_ERROR_DECODE(uint err_code) => (uint)((err_code) & 0x0000FFFF);
        public static uint STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE source_error, uint err_code, uint _err_sys) => (uint)(STDA_SOURCE_ERROR_ENCODE(Convert.ToUInt32(source_error)) | STDA_ERROR_ENCODE((err_code)) | STDA_SYSTEM_ERROR_ENCODE((_err_sys)));
        public static uint STDA_MAKE_ERROR(uint source_error, uint err_code, uint _err_sys) => (uint)(STDA_SOURCE_ERROR_ENCODE((source_error)) | STDA_ERROR_ENCODE((err_code)) | STDA_SYSTEM_ERROR_ENCODE((_err_sys)));
        public static bool STDA_ERROR_CHECK_SOURCE_AND_ERROR(uint err_code, uint source_error, uint error) => (bool)(STDA_SOURCE_ERROR_DECODE((err_code)) == (source_error) && STDA_ERROR_DECODE((err_code)) == (error));

    }
    public class exception : Exception
    {
        protected string m_message_error = "";
        protected string m_message_error_full = "";
        protected uint m_code_error = 0;
        public exception(string message) : base(message)
        {
        }

        public exception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public exception(string message_error, uint code_error) : this(message_error + "\t Error Code: " + code_error)
        {
            m_message_error = message_error;
            m_code_error = code_error;

            m_message_error_full = m_message_error + "\t Error Code: " + code_error;
        }

        public Exception GetException()
        {
            return this;
        }
        public string getMessageError()
        {
            return m_message_error;
        }

        public uint getCodeError()
        {
            return m_code_error;
        }

        public string getFullMessageError()
        {
            return m_message_error_full + ", [Strace]: " + getStackTrace();
        }

        public string getStackTrace()
        {
            return this.StackTrace;
        }
    }
}
