using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchCore
{
    public abstract class StreamDataReader<T>
    {
        private Regex _dataMatchRegex;

        public IEnumerable<T> ReadData(Stream dataStream)
        {
            using (var reader = new StreamReader(dataStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var matchResult = DataMatchRegex.Match(line);

                    if (matchResult.Success)
                    {
                        yield return ParseRegexResult(matchResult);
                    }
                }
            }
        }

        private Regex DataMatchRegex
        {
            get
            {
                if (_dataMatchRegex == null)
                    _dataMatchRegex = new Regex(LineMatchPattern);

                return _dataMatchRegex;
            }
        }

        protected abstract string LineMatchPattern { get; }

        protected abstract T ParseRegexResult(Match regexMatch);
    }
}