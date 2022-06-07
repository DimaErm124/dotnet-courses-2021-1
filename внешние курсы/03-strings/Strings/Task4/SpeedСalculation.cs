using System.Diagnostics;
using System.Text;

namespace Task4
{
    public class SpeedСalculation
    {
        private Stopwatch _stopWatch;

        public SpeedСalculation()
        {
            _stopWatch = new Stopwatch();
        }
        public string CompareStringAdditionSpeed(string additionString, int count)
        {
            _stopWatch.Restart();

            GetStringCount(additionString, count);

            _stopWatch.Stop();

            return _stopWatch.Elapsed.TotalMilliseconds.ToString();
        }

        public string CompareStringBuilderAdditionSpeed(StringBuilder additionStringBuilder, int count)
        {
            _stopWatch.Restart();

            GetStringBuilderCount(additionStringBuilder, count);

            _stopWatch.Stop();

            return _stopWatch.Elapsed.TotalMilliseconds.ToString();
        }

        public string GetStringCount(string additionString, int count)
        {
            string str=string.Empty;

            for (int i = 0; i < count; i++)
            {
                str += additionString;
            }

            return str;
        }

        public StringBuilder GetStringBuilderCount(StringBuilder additionString, int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                sb.Append(additionString);
            }

            return sb;
        }
    }
}
