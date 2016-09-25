using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibraryUpdater
{
    public class SchLibParameter
    {

        private readonly string template = "|RECORD=41|INDEXINSHEET=1|OWNERPARTID=-1|COLOR=8388608|FONTID=1|ISHIDDEN=T|TEXT={0}|NAME={1}|UNIQUEID={2}\0";
        public Dictionary<string, string> RecordProperties;
        public bool IsParameterRecord;
        private byte[] _Original;
        static Random r = new Random();
        public byte flag;

        public byte[] Original
        {
            get { return _Original; }
        }

        public SchLibParameter(string Name, string Text)
        {
            string createdRecord = String.Format(template, Text, Name, CreateUniqueId());
            SetupRecord(createdRecord);
            _Original = (Encoding.ASCII.GetBytes(createdRecord));
        }

        public SchLibParameter(byte[] recordEntry, byte flag)
        {
            _Original = recordEntry;
            string recordStr = Encoding.ASCII.GetString(recordEntry);
            SetupRecord(recordStr);
            this.flag = flag;
        }

        private void SetupRecord(string record)
        {
            if (record.Contains("RECORD=41"))
            {
                IsParameterRecord = true;
                RecordProperties = new Dictionary<string, string>();
                splitOutProperties(record);
            }
            else
            {
                IsParameterRecord = false;
            }
        }

        private void splitOutProperties(string record)
        {
            var properties = record.Split('|');
            foreach(string prop in properties)
            {
                if (prop.Length == 0) continue;
                var keyval = prop.Split('=');
                if (RecordProperties.ContainsKey(keyval[0])) continue;

                RecordProperties.Add(keyval[0], keyval[1].Trim('\0'));
            }
        }


        public string CreateUniqueId()
        {
            string randString = "";
            for(int i = 0; i < 8; i++)
            {
                char x = (char)r.Next('A', 'Z');
                randString = randString + x;
            }

            return randString;

        }
    }
}
