using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Slot
{
    class Program
    {
        static void Main(string[] args)
        {
            SlotMachine machine=new SlotMachine();
            machine.RollingSlot();
            machine.PrintSlot();
            machine.CheckSlot();
        }

    }


   
}