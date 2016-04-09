﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace LibraryMM
{
    public class Pipe
    {
        // "pipeClient.exe"
        public static void PipeServer(string exe_name)
        {
            Process pipeClient = new Process();

            pipeClient.StartInfo.FileName = exe_name;
            //pipeClient.StartInfo.FileName = "pipeClient.exe";

            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out,
                HandleInheritability.Inheritable))
            {
                // Show that anonymous pipes do not support Message mode.
                try
                {
                    Console.WriteLine("[SERVER] Setting ReadMode to \"Message\".");
                    pipeServer.ReadMode = PipeTransmissionMode.Message;
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("[SERVER] Exception:\n    {0}", e.Message);
                }

                Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                    pipeServer.TransmissionMode);

                // Pass the client process a handle to the server.
                pipeClient.StartInfo.Arguments =
                    pipeServer.GetClientHandleAsString();
                pipeClient.StartInfo.UseShellExecute = false;
                pipeClient.Start();

                pipeServer.DisposeLocalCopyOfClientHandle();

                try
                {
                    // Read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        // Send a 'sync message' and wait for client to receive it.
                        sw.WriteLine("SYNC");
                        pipeServer.WaitForPipeDrain();
                        // Send the console input to the client process.
                        Console.Write("[SERVER] Enter text: ");
                        sw.WriteLine(Console.ReadLine());
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("[SERVER] Error: {0}", e.Message);
                }
            }

            pipeClient.WaitForExit();
            pipeClient.Close();
            Console.WriteLine("[SERVER] Client quit. Server terminating.");
        }

        public static void PipeClient(string ClientHandle)
        {
            if (!string.IsNullOrEmpty(ClientHandle))
            {
                using (PipeStream pipeClient =
                    new AnonymousPipeClientStream(PipeDirection.In, ClientHandle))
                {
                    // Show that anonymous Pipes do not support Message mode.
                    try
                    {
                        Console.WriteLine("[CLIENT] Setting ReadMode to \"Message\".");
                        pipeClient.ReadMode = PipeTransmissionMode.Message;
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("[CLIENT] Execption:\n    {0}", e.Message);
                    }

                    Console.WriteLine("[CLIENT] Current TransmissionMode: {0}.",
                       pipeClient.TransmissionMode);

                    using (StreamReader sr = new StreamReader(pipeClient))
                    {
                        // Display the read text to the console
                        string temp;

                        // Wait for 'sync message' from the server.
                        do
                        {
                            Console.WriteLine("[CLIENT] Wait for sync...");
                            temp = sr.ReadLine();
                        }
                        while (!temp.StartsWith("SYNC"));

                        // Read the server data and echo to the console.
                        while ((temp = sr.ReadLine()) != null)
                        {
                            Console.WriteLine("[CLIENT] Echo: " + temp);
                        }
                    }
                }
            }
            Console.Write("[CLIENT] Press Enter to continue...");
            Console.ReadLine();
        }
    }
}