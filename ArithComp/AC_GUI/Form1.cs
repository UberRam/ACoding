using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ACLib;
using System.Security.Cryptography;
namespace AC_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //List<int> compressed1 = Compress("ALAMAKOTAIKOTMAALE");
            //MessageBox.Show(string.Join(", ", compressed1));
            //string decompressed = Decompress(compressed1);
            //MessageBox.Show(decompressed);
        }

        private void browseSourceButton_Click(object sender, EventArgs e)
        {
            sourceOpenFileDialog.ShowDialog();
        }

        private void sourceOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            sourceText.Text = sourceOpenFileDialog.FileName;
        }

        private void browseTargetButton_Click(object sender, EventArgs e)
        {
            targetOpenFileDialog.ShowDialog();
        }

        private void targetOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            targetText.Text = targetOpenFileDialog.FileName;
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(sourceText.Text);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception openSourceException)
            {
                MessageBox.Show("Error1! Cannot open source file for read");
                return;
            }

            try
            {
                targetFile = new FileInfo(targetText.Text);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception openTargetException)
            {
                MessageBox.Show("Error2! Cannot open target file to write!");
                return;
            }

            // Information
            sourceFileSizeValueText.Text = sourceFile.Length.ToString();

            sourceStream.Seek(0, SeekOrigin.Begin);
            byte[] writtenBytes = Encoding.Default.GetBytes(Program.g_Signature);
            targetStream.Write(writtenBytes, 0, 3);

            DateTime firstTime = DateTime.Now;

            // Main compression function
            model.Process(sourceStream, targetStream, ModeE.MODE_ENCODE);

            DateTime secondTime = DateTime.Now;
            TimeSpan duration = secondTime - firstTime;

            sourceStream.Close();
            targetStream.Close();

            // Information
            targetFileSizeValueText.Text = targetFile.Length.ToString();
            compressionRatioValueText.Text = ((double)sourceFile.Length / (double)targetFile.Length).ToString();
            timeValueText.Text = duration.TotalMilliseconds.ToString();

            MessageBox.Show("Encoding Succeeded!");
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(sourceText.Text);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception openSourceException)
            {
                MessageBox.Show("Error1! Cannot open source file for read");
                return;
            }

            try
            {
                targetFile = new FileInfo(targetText.Text);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception openTargetException)
            {
                MessageBox.Show("Error2! Cannot open target file to write!");
                return;
            }

            // Information
            sourceFileSizeValueText.Text = sourceFile.Length.ToString();

            byte[] readBytes = new byte[3];
            sourceStream.Read(readBytes, 0, 3);
            string signature = Encoding.Default.GetString(readBytes);

            if (signature != Program.g_Signature)
            {
                MessageBox.Show("Error3! Not valid encoded AC file as Source!");
                return;
            }

            DateTime firstTime = DateTime.Now;

            // Main compression function
            model.Process(sourceStream, targetStream, ModeE.MODE_DECODE);

            DateTime secondTime = DateTime.Now;
            TimeSpan duration = secondTime - firstTime;

            sourceStream.Close();
            targetStream.Close();

            // Information
            targetFileSizeValueText.Text = targetFile.Length.ToString();
            compressionRatioValueText.Text = ((double)targetFile.Length / (double)sourceFile.Length).ToString();
            timeValueText.Text = duration.TotalMilliseconds.ToString();

            MessageBox.Show("Decoding Succeeded!");
        }

        private void btnEncLZW_Click(object sender, EventArgs e)
        {
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(sourceText.Text);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception openSourceException)
            {
                MessageBox.Show("Error1! Cannot open source file for read");
                return;
            }

            try
            {
                targetFile = new FileInfo(targetText.Text);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception openTargetException)
            {
                MessageBox.Show("Error2! Cannot open target file to write!");
                return;
            }

            // Information
            sourceFileSizeValueText.Text = sourceFile.Length.ToString();

            //sourceStream.Seek(0, SeekOrigin.Begin);
            //byte[] writtenBytes = Encoding.Default.GetBytes(Program.g_Signature);
            //targetStream.Write(writtenBytes, 0, 3);
            byte[] buffer;
            string result = "";
              try
              {
                int length = (int)sourceStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = sourceStream.Read(buffer, sum, length - sum)) > 0)
                  sum += count;  // sum is a buffer offset for next reading
                
                  foreach (byte bajt in buffer)
                  {
                      result += bajt.ToString();
                  }
              }
              finally
              {
                sourceStream.Close();
              }
            DateTime firstTime = DateTime.Now;
            List<int> compressed = Compress(result);
            string preparedFormattedCode = string.Join(",", compressed);
            MessageBox.Show(string.Join(",", compressed));
            byte[] dataToSave = Encoding.ASCII.GetBytes(preparedFormattedCode.ToCharArray());
            //List<byte> dataList= new List<byte>();
            //for (int i = 0; i < compressed.Count; i++)
            //{
            //    if (i != compressed.Count - 1)
            //    {
            //        dataList.Add(Convert.ToByte(compressed[i]));
            //        dataList.Add(Convert.ToByte(','));
            //    }
            //    else
            //    {
            //        dataList.Add(Convert.ToByte(compressed[i]));
            //    }
            //}
            //byte[] dataToSave = dataList.ToArray();
            
            // Main compression function
            //model.Process(sourceStream, targetStream, ModeE.MODE_ENCODE);
            targetStream.Write(dataToSave,0,dataToSave.Length);
            DateTime secondTime = DateTime.Now;
            TimeSpan duration = secondTime - firstTime;

            sourceStream.Close();
            targetStream.Close();

            // Information
            targetFileSizeValueText.Text = targetFile.Length.ToString();
            compressionRatioValueText.Text = ((double)sourceFile.Length / (double)targetFile.Length).ToString();
            timeValueText.Text = duration.TotalMilliseconds.ToString();

            MessageBox.Show("Encoding Succeeded!");
        }

        private void btnDecLZW_Click(object sender, EventArgs e)
        {
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(sourceText.Text);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception openSourceException)
            {
                MessageBox.Show("Error1! Cannot open source file for read");
                return;
            }

            try
            {
                targetFile = new FileInfo(targetText.Text);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception openTargetException)
            {
                MessageBox.Show("Error2! Cannot open target file to write!");
                return;
            }

            // Information
            sourceFileSizeValueText.Text = sourceFile.Length.ToString();

            //byte[] readBytes = new byte[3];
            //sourceStream.Read(readBytes, 0, 3);
            //string signature = Encoding.Default.GetString(readBytes);

            //if (signature != Program.g_Signature)
            //{
            //    MessageBox.Show("Error3! Not valid encoded AC file as Source!");
            //    return;
            //}
            byte[] buffer;
            string result = "";
            try
            {
                int length = (int)sourceStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = sourceStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                sourceStream.Close();
            }
            List<int> compressed = new List<int>();
            foreach (byte b in buffer)
            {
                if(((char)b)!=',')
                compressed.Add(Convert.ToChar(b));
            }
            DateTime firstTime = DateTime.Now;

            string wyjscie=Decompress(compressed);
            MessageBox.Show(wyjscie);
            MessageBox.Show(Decompress(compressed));
            // Main compression function
            //model.Process(sourceStream, targetStream, ModeE.MODE_DECODE);
            DateTime secondTime = DateTime.Now;
            byte[] dataToSave=Encoding.ASCII.GetBytes(wyjscie);
            //StreamWriter sWriter = new StreamWriter(targetStream);
            //sWriter.Write((Encoding.UTF8.GetChars(wyjscie
            TimeSpan duration = secondTime - firstTime;
            targetStream.Write(dataToSave, 0, dataToSave.Length);
            sourceStream.Close();
            targetStream.Close();

            // Information
            targetFileSizeValueText.Text = targetFile.Length.ToString();
            compressionRatioValueText.Text = ((double)targetFile.Length / (double)sourceFile.Length).ToString();
            timeValueText.Text = duration.TotalMilliseconds.ToString();

            MessageBox.Show("Decoding Succeeded!");
        }

        public static List<int> Compress(string uncompressed)
        {
            // build the dictionary
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(((char)i).ToString(), i);

            string w = string.Empty;
            List<int> compressed = new List<int>();

            foreach (char c in uncompressed)
            {
                string wc = w + c;
                if (dictionary.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    // write w to output
                    compressed.Add(dictionary[w]);
                    // wc is a new sequence; add it to the dictionary
                    dictionary.Add(wc, dictionary.Count);
                    w = c.ToString();
                }
            }

            // write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
                compressed.Add(dictionary[w]);

            return compressed;
        }

        public static string Decompress(List<int> compressed)
        {
            // build the dictionary
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(i, ((char)i).ToString());

            string w = dictionary[compressed[0]];
            compressed.RemoveAt(0);
            StringBuilder decompressed = new StringBuilder(w);

            foreach (int k in compressed)
            {
                string entry = null;
                if (dictionary.ContainsKey(k))
                    entry = dictionary[k];
                else if (k == dictionary.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                // new sequence; add it to the dictionary
                dictionary.Add(dictionary.Count, w + entry[0]);

                w = entry;
            }

            return decompressed.ToString();
        }

        private void btnCRCEnc_Click(object sender, EventArgs e)
        {
            AbstractModel model = new ModelOrder0();

            FileInfo sourceFile, targetFile;
            FileStream sourceStream, targetStream;

            try
            {
                sourceFile = new FileInfo(sourceText.Text);
                sourceStream = sourceFile.OpenRead();
            }
            catch (Exception openSourceException)
            {
                MessageBox.Show("Error1! Cannot open source file for read");
                return;
            }

            try
            {
                targetFile = new FileInfo(targetText.Text);
                targetStream = targetFile.OpenWrite();
            }
            catch (Exception openTargetException)
            {
                MessageBox.Show("Error2! Cannot open target file to write!");
                return;
            }

            // Information
            sourceFileSizeValueText.Text = sourceFile.Length.ToString();

            //sourceStream.Seek(0, SeekOrigin.Begin);
            //byte[] writtenBytes = Encoding.Default.GetBytes(Program.g_Signature);
            //targetStream.Write(writtenBytes, 0, 3);
            byte[] buffer;
            string result = "";
            try
            {
                int length = (int)sourceStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = sourceStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                sourceStream.Close();
            }
            DateTime firstTime = DateTime.Now;
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;
            using (sourceStream) //here you pass the file name 
            {
                foreach (byte b in crc32.ComputeHash(sourceStream))
                {
                    hash += b.ToString("x2").ToLower();
                }
                MessageBox.Show(hash);
            }
            double x = 0;
            bool[] kodBinarny= new bool[buffer.Length*8];
            bool[] remainder = new bool[buffer.Length * 8 + txtCRCLen.Text.Length];
            bool[] remainderResult = new bool[buffer.Length * 8 + txtCRCLen.Text.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                for (int j = 0; j < 8;j++ )
                {
                    x = Math.Pow(2, j);
                    if (((int)x & buffer[i])==0)
                    {
                        kodBinarny[i+j]=false;
                    }
                    else
                        kodBinarny[i + j] = true;
                }
            }
            //string padding = "";
            //for (int k = 0; k < txtCRCLen.Text.Length; k++)
            //    padding += "0";
            //for (int h = 0; h < kodBinarny.Length;h++ )
            //{
            //    remainder[h] = kodBinarny[h];
            //}
            //for (int h = kodBinarny.Length; h < kodBinarny.Length + txtCRCLen.Text.Length; h++)
            //{
            //    remainder[h] = false;
            //}
            //bool[] dzielnik= new bool[txtCRCLen.Text.Length];
            //for (int h = 0; h < dzielnik.Length; h++)
            //{
            //    if(txtCRCpolynomial.Text.ToCharArray()[h]=='1')
            //    {
            //        dzielnik[h]=true;
            //    }
            //    else
            //        dzielnik[h]=false;
            //}
            //for (int h = 0; h < kodBinarny.Length + txtCRCLen.Text.Length; h++)
            //{
            //    for (int j = 0; j < txtCRCLen.Text.Length; j++)
            //    {
            //        if (dzielnik[j] == kodBinarny[h+j])
            //        {
            //            remainderResult[h+j] = false;
            //        }
            //        else
            //            remainderResult[h+j] = true;
            //        if (j==txtCRCLen.Text.Length-1)
            //        h += j+1;
            //    }
            //}
            //MessageBox.Show(remainderResult.ToString());
            //List<byte> dataList= new List<byte>();
            //for (int i = 0; i < compressed.Count; i++)
            //{
            //    if (i != compressed.Count - 1)
            //    {
            //        dataList.Add(Convert.ToByte(compressed[i]));
            //        dataList.Add(Convert.ToByte(','));
            //    }
            //    else
            //    {
            //        dataList.Add(Convert.ToByte(compressed[i]));
            //    }
            //}
            //byte[] dataToSave = dataList.ToArray();

            // Main compression function
            //model.Process(sourceStream, targetStream, ModeE.MODE_ENCODE);
            //targetStream.Write(dataToSave, 0, dataToSave.Length);
            DateTime secondTime = DateTime.Now;
            TimeSpan duration = secondTime - firstTime;

            sourceStream.Close();
            targetStream.Close();

            // Information
            targetFileSizeValueText.Text = targetFile.Length.ToString();
            compressionRatioValueText.Text = ((double)sourceFile.Length / (double)targetFile.Length).ToString();
            timeValueText.Text = duration.TotalMilliseconds.ToString();

            MessageBox.Show("Encoding Succeeded!");
        }

        private void btnCRCDec_Click(object sender, EventArgs e)
        {

        }

    }
}
