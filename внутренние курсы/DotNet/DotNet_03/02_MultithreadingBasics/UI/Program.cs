using ModelWithSynchronousProperty;
using System;
using System.Threading;

namespace UI
{
    class Program
    {
        private static readonly int[] _arrayReaderThreadNumber = { 1, 2, 3, 5, 6, 7, 8, 10, 11, 12 };
        private static readonly int[] _arrayWriterThreadNumber = { 4, 9 };

        private static AutoResetEvent[] _waitHandles = new AutoResetEvent[_arrayWriterThreadNumber.Length + _arrayReaderThreadNumber.Length];

        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Add("Start app");

            logger.Add("Start init");

            Random random = new Random();
            ShareResHandler shareResHandler = new ShareResHandler(new ReaderWriterLockSlim(), logger);
            Thread[] threads = new Thread[_arrayWriterThreadNumber.Length + _arrayReaderThreadNumber.Length];

            logger.Add("Finish init");

            logger.Add("Start circle for create threads");
            for (int i = 0; i < _arrayWriterThreadNumber.Length + _arrayReaderThreadNumber.Length; i++)
            {
                _waitHandles[i] = new AutoResetEvent(false);

                logger.Add("Create thread #" + (i + 1));
                if (Array.Exists(_arrayReaderThreadNumber, x => x == i + 1))
                {
                    threads[i] = new Thread((object auto) =>
                    {
                        if (auto is AutoResetEvent resetEvent)
                        {
                            logger.Add("Start get thread");

                            string shareRes = shareResHandler.ShareRes;

                            logger.Add("Finish get thread");
                            
                            resetEvent.Set();
                        }

                    });
                    threads[i].Start(_waitHandles[i]);
                }
                else
                {
                    threads[i] = new Thread((object auto) =>
                    {
                        if (auto is AutoResetEvent resetEvent)
                        {
                            logger.Add("Start set thread");

                            string newValue = random.Next(100).ToString();
                            shareResHandler.ShareRes = newValue;                            

                            logger.Add("Finish set thread");
                            
                            resetEvent.Set();
                        }
                    });
                    threads[i].Start(_waitHandles[i]);
                }
            }
            WaitHandle.WaitAll(_waitHandles);

            logger.Add("Finish circle for create threads");

            logger.Add("Finish app");
        }
    }
}