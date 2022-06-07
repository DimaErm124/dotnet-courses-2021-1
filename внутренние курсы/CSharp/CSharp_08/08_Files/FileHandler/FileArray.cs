using System;
using System.IO;
using System.Text;

namespace FileHandler
{
    public class FileArray : IDisposable
    {
        private bool isDisposed = false;

        private const int EncodingName = 1251;

        private FileStream _fileStream;

        private StreamReader _streamReader;

        private StreamWriter _streamWriter;

        public int Length { get; private set; }

        public char this[int i]
        {
            get => Read(i);
            set => Write(i, value);
        }

        private FileArray(string path, int length)
        {
            if (!CheckFilePath(path))
            {
                throw new Exception($"Directory not exist for file with path \"{path}\"!");
            }

            Length = length;

            InitStreams(path);

            _streamWriter.Write(new string(' ', length));
        }

        private FileArray(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File \"{path}\" not found!");
            }

            InitStreams(path);

            Length = _streamReader.ReadToEnd().Length;
        }

        private void InitStreams(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            _streamReader = new StreamReader(_fileStream, Encoding.GetEncoding(EncodingName));
            _streamWriter = new StreamWriter(_fileStream, Encoding.GetEncoding(EncodingName));
            _streamWriter.AutoFlush = true;
        }

        private bool CheckFilePath(string path)
        {
            if (!Directory.Exists(path.Substring(0, path.LastIndexOf('\\'))))
            {
                return false;
            }

            return true;
        }

        private char Read(int index)
        {
            if (isDisposed)
                throw new ObjectDisposedException("Object has been deleted!");

            var buffer = new char[1];

            _fileStream.Position = index;

            if (_streamReader.Read(buffer) == 0)
            {
                throw new ArgumentException("File ending!");
            }

            return buffer[0];
        }

        private char[] ReadAll()
        {
            var buffer = new char[Length];
            
            SetStartPosition();
            
            _streamReader.ReadBlock(buffer, 0, Length);
                      
            return buffer;
        }

        private void Write(int index, char symbol)
        {
            if (isDisposed)
                throw new ObjectDisposedException("Object has been deleted!");

            _fileStream.Position = index;

            _streamWriter.Write(symbol);
        }

        private void SetStartPosition()
        {
            _fileStream.Position = 0;
        }

        public static FileArray Create(string path, int length)
        {
            return new FileArray(path, length);
        }

        public static FileArray Read(string path)
        {
            return new FileArray(path);
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                _streamWriter.Dispose();
                _streamReader.Dispose();
                _fileStream.Dispose();

                isDisposed = true;
            }
        }

        public override string ToString()
        {
            return new string(ReadAll());
        }
    }
}