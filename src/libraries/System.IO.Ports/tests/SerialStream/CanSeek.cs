// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.IO.PortsTests;
using Legacy.Support;
using Xunit;

namespace System.IO.Ports.Tests
{
    public class SerialStream_CanSeek : PortsTest
    {
        #region Test Cases
        [ConditionalFact(nameof(HasOneSerialPort))]
        public void CanSeek_Open_Close()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Stream serialStream = com.BaseStream;
                com.Close();

                Debug.WriteLine("Verifying CanSeek property throws exception After Open() then Close()");

                Assert.False(serialStream.CanSeek);
            }
        }

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void CanSeek_Open_BaseStreamClose()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Stream serialStream = com.BaseStream;
                com.BaseStream.Close();

                Debug.WriteLine("Verifying CanSeek property throws exception After Open() then BaseStream.Close()");

                Assert.False(serialStream.CanSeek);
            }
        }

        [ConditionalFact(nameof(HasOneSerialPort))]
        public void CanSeek_AfterOpen()
        {
            using (SerialPort com = new SerialPort(TCSupport.LocalMachineSerialInfo.FirstAvailablePortName))
            {
                com.Open();
                Debug.WriteLine("Verifying CanSeek property returns true after a call to Open()");
                Assert.False(com.BaseStream.CanSeek);
            }
        }

        #endregion

        #region Verification for Test Cases

        #endregion
    }
}
