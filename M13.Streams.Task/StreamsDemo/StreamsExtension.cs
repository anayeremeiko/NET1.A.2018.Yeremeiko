using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx
    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .
                
        /// <summary>
        /// Copies text of one file to another by byte
        /// </summary>
        /// <param name="sourcePath">Source file.</param>
        /// <param name="destinationPath">Destination file.</param>
        /// <returns>Number of copied bytes.</returns>
        /// <exception cref="ArgumentException">Source and destination pathes need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int bytes = 0;
            using (var readStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (var writeStream = new FileStream(destinationPath, FileMode.Create))
                {
                    for (int i = 0; i < readStream.Length; i++)
                    {
                        writeStream.WriteByte((byte)readStream.ReadByte());
                        bytes++;
                    }
                }
            }

            return bytes;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Copies text of one file to another by byte
        /// </summary>
        /// <param name="sourcePath">Source file.</param>
        /// <param name="destinationPath">Destination file.</param>
        /// <returns>Number of copied bytes.</returns>
        /// <exception cref="ArgumentException">Source and destination paths need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (StreamReader sr = new StreamReader(sourcePath, Encoding.UTF8))
            using (StreamWriter sw = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                string text = sr.ReadToEnd();
                byte[] array = Encoding.UTF8.GetBytes(text);
                byte[] bom = Encoding.UTF8.GetPreamble();
                using (var memStream = new MemoryStream(array))
                {
                    byte[] byteArray = new byte[array.Length];
                    int count = memStream.Read(byteArray, 0, byteArray.Length);
                    
                    while (count < memStream.Length)
                    {
                        byteArray[count++] = (byte)memStream.ReadByte();
                    }

                    char[] bomChar = Encoding.UTF8.GetChars(bom);
                    char[] charArray = Encoding.UTF8.GetChars(byteArray);
                    sw.Write(bomChar);
                    sw.Write(charArray);
                    return Encoding.UTF8.GetByteCount(charArray) + Encoding.UTF8.GetByteCount(bomChar);
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Copies the text of one file to another.
        /// </summary>
        /// <param name="sourcePath">The source file.</param>
        /// <param name="destinationPath">The destination file.</param>
        /// <returns>Number of written bytes.</returns>
        /// <exception cref="ArgumentException">Source and destination pathes need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int bytes = 0;
            using (var readStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (var writeStream = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] array = new byte[readStream.Length];
                    readStream.Read(array, 0, array.Length);
                    writeStream.Write(array, 0, array.Length);
                    bytes = (int)writeStream.Length;
                }
            }
            
            return bytes;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Copies text of one file to another by byte
        /// </summary>
        /// <param name="sourcePath">Source file.</param>
        /// <param name="destinationPath">Destination file.</param>
        /// <returns>Number of copied bytes.</returns>
        /// <exception cref="ArgumentException">Source and destination paths need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (StreamReader sr = new StreamReader(sourcePath, UTF8Encoding.Default))
            using (StreamWriter sw = new StreamWriter(destinationPath, false, UTF8Encoding.Default))
            {
                string text = sr.ReadToEnd();
                byte[] array = Encoding.UTF8.GetBytes(text);
                byte[] bom = Encoding.UTF8.GetPreamble();
                
                using (var memStream = new MemoryStream(array, 0, array.Length))
                {
                    byte[] readBytes = memStream.ToArray();
                    char[] bomChar = Encoding.UTF8.GetChars(bom);
                    char[] charArray = Encoding.UTF8.GetChars(readBytes);
                    sw.Write(bomChar);
                    sw.Write(charArray);
                    return Encoding.UTF8.GetByteCount(charArray) + Encoding.UTF8.GetByteCount(bomChar);
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Copies the text of one file to another.
        /// </summary>
        /// <param name="sourcePath">The source file.</param>
        /// <param name="destinationPath">The destination file.</param>
        /// <returns>Number of written bytes.</returns>
        /// <exception cref="ArgumentException">Source and destination pathes need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] array;
            using (var readStream = new FileStream(sourcePath, FileMode.Open))
            using (var bs = new BufferedStream(readStream, (int)readStream.Length))
            {
                array = new byte[bs.Length];
                bs.Read(array, 0, array.Length);
            }

            using (var writeStream = new FileStream(destinationPath, FileMode.Create))
            using (var bs = new BufferedStream(writeStream))
            {
                bs.Write(array, 0, array.Length);
            }

            return array.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Copies text from one file to another.
        /// </summary>
        /// <param name="sourcePath">The source file.</param>
        /// <param name="destinationPath">The destination file.</param>
        /// <returns>Number of written strings.</returns>
        /// <exception cref="ArgumentException">Source and destination pathes need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int writtenStrings = 0;
            using (var readStream = new FileStream(sourcePath, FileMode.Open))
            using (var writeStream = new FileStream(destinationPath, FileMode.Create))
            using (StreamReader sr = new StreamReader(readStream, Encoding.Default))
            using (StreamWriter sw = new StreamWriter(writeStream, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(line);
                    writtenStrings++;
                }
            }

            return writtenStrings;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Defines if two files are the same by content.
        /// </summary>
        /// <param name="sourcePath">First file.</param>
        /// <param name="destinationPath">Second file.</param>
        /// <returns>True if equal, false otherwise.</returns>
        /// <exception cref="ArgumentException">Source and destination paths need to be not empty.</exception>
        /// <exception cref="FileNotFoundException">File at source or destination path not found.</exception>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            if (sourcePath == destinationPath)
            {
                return true;
            }

            using (var firstFile = new StreamReader(sourcePath, Encoding.UTF8))
            using (var secondFile = new StreamReader(destinationPath, Encoding.UTF8))
            {
                string line;
                while ((line = firstFile.ReadLine()) != null)
                {
                    if(line!=secondFile.ReadLine())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic
        
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} need to be not empty.");
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} need to be not empty.");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"{nameof(sourcePath)} not found.");
            }

            if (!File.Exists(destinationPath))
            {
                throw new FileNotFoundException($"{nameof(destinationPath)} not found.");
            }
        }

        #endregion

        #endregion
    }
}
