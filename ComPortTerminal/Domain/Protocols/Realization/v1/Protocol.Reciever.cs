﻿using ComPortTerminal.Domain.Packets.Realization.v1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Domain.Protocols.Realization.v1
{
    public partial class Protocol
    {
        public void RecieveHandler(byte input)
        {
            //If packet arrived
            if (_packet.TryParse(input))
            {
                switch (_packet.Type)
                {
                    case (Packet.Types.getParameters):                        
                        {
                            //_status = Statuses.connected;
                            var par = _packet.GetParams();
                            //If parameters in GUI match with parameters in quadcopter
                            if (par.id == _id)
                                _status = Statuses.connected;
                            else
                                _status = Statuses.updating;
                        }
                        Console.WriteLine("Telemetry params arrived");
                        break;
                }                            
                _delay.Restart();
            }
        }

        public delegate void RecievedParametersHandler(Parameters p);
        private RecievedParametersHandler _recievedParametersHandler;
        public void SetRecievedParametersHandler(RecievedParametersHandler handler)
        {
            _recievedParametersHandler += handler;
        }
    }
}