﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public void RecieveHandler(byte input)
        {       
            //If packet arrived
            if(Packet.Parser(input))
            {
                
            }
        }
    }
}