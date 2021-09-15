﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Packets.Realization.v1;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public Response TryConnect(string connection)
        {
            //Connection to COM-port
            var resp = _conn.Connect(connection);
            if (resp.isError)
            {
                
            }
            

            return new Response
            {
                Message = resp.Message,
                isError = false,
                isCanceled = false
            };
        }
    }
}