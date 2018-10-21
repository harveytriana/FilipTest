using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilipTest.Models
{
    [Serializable]
    [MessagePackObject(keyAsPropertyName: true)]
    public class OnlineRecord
    {
        public string ID { get; set; }
        public DateTime Time { get; set; }
        public float Depth { get; set; }
        public Dictionary<string, float> Parameters { get; set; }

        public override string ToString()
        {
            return $"{Time.ToString("HH:mm:ss")}: {ID} {Depth.ToString("0.00")} | N: {Count()}";
        }

        public int Count()
        {
            return Parameters != null ? Parameters.Count : 0;
        }

        public float ValueOf(string mnemonic)
        {
            if (Parameters == null ||
                Parameters.ContainsKey(mnemonic) == false) {
                return -999.25F;
            }
            return Parameters[mnemonic];
        }
    }
}