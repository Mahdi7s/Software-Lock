using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Model
{
    public class UserSerialState
    {
        public int UserSerialStateId { get; set; }

        public string LastEnablingState { get; set; }
    }
}
