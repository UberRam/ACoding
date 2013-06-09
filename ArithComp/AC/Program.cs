using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AC
{
    class Program
    {
        const string g_Signature = "PO3"; // signature: "PO3" (0x434D4341, intel byte order)

        static int Main(string[] args)
        {
            Console.WriteLine("Arithmetic Coding");

            if (args.Length != 2)
            {
                Console.WriteLine("Error! right syntax is: AC [source] [target]");
                return 1;
            }

            // choose model, here just order-0
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(args[0]);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Cannot open source file to read!");
                return 2;
            }

            try
            {
                targetFile = new FileInfo(args[1]);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Cannot open target file to write!");
                return 3;
            }

            byte[] readBytes = new byte[3];
            sourceStream.Read(readBytes, 0, 3);
            string signature = Encoding.Default.GetString(readBytes);

            if (signature == g_Signature)
            {
                Console.WriteLine("Decoding " + args[0] + " to " + args[1]);
                model.Process(sourceStream, targetStream, ModeE.MODE_DECODE);
            }
            else
            {
                Console.WriteLine("Encoding " + args[0] + " to " + args[1]);

                sourceStream.Seek(0, SeekOrigin.Begin);
                byte[] writtenBytes = Encoding.Default.GetBytes(g_Signature);
                targetStream.Write(writtenBytes, 0, 3);

                model.Process(sourceStream, targetStream, ModeE.MODE_ENCODE);
            }

            sourceStream.Close();
            targetStream.Close();

            return 0;
        }
    }
}
