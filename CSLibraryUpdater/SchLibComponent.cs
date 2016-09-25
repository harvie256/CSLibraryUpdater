using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLibraryUpdater
{
    public class SchLibComponent
    {
        public List<SchLibParameter> Parameters;
        public string Name;

        public SchLibComponent(string Name, byte[] Data)
        {
            Parameters = new List<SchLibParameter>();
            this.Name = Name;
            getRecords(Data);
            
        }

        public byte[] GetBinary()
        {
            List<byte> bytes = new List<byte>();

            foreach(var parameter in Parameters)
            {
                int length = parameter.Original.Length;
                bytes.Add((byte)length);
                bytes.Add((byte)(length >> 8));
                bytes.Add((byte)(length >> 16));
                bytes.Add(parameter.flag);
                bytes.AddRange(parameter.Original);
            }

            return bytes.ToArray();
        }

        public void AddParameters(Dictionary<string, string> parameters)
        {
            foreach(var pair in parameters)
            {
                var schParam = new SchLibParameter(pair.Key, pair.Value);
                Parameters.Add(schParam);
            }
        }

        public SchLibParameter FindParameter(string key)
        {
            SchLibParameter foundParameter = null;
            foreach (var parameter in Parameters)
            {
                if (!parameter.IsParameterRecord) continue;

                if (parameter.RecordProperties.ContainsKey("TEXT"))
                {
                    if (parameter.RecordProperties["NAME"].Contains(key))
                    {
                        foundParameter = parameter;
                        break;
                    }
                }
            }
            return foundParameter;
        }

        private void getRecords(byte[] streamContents)
        {
            bool endOfFile = false;
            int fileLocationPtr = 0;

            while (!endOfFile)
            {
                // Read the first 4 bytes for the length & flag
                int length = 0;
                length = streamContents[fileLocationPtr] |
                    streamContents[fileLocationPtr + 1] << 8;

                byte flag = streamContents[fileLocationPtr + 3];

                fileLocationPtr += 4;

                byte[] binaryRecord = new byte[length];
                Array.Copy(streamContents, fileLocationPtr, binaryRecord, 0, length);
                Parameters.Add(new SchLibParameter(binaryRecord, flag));
                fileLocationPtr += length;

                if (fileLocationPtr >= streamContents.Length)
                {
                    endOfFile = true;
                }
            }
        }
    }
}
