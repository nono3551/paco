using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Paco.SystemManagement.Ssh
{
    public class Fingerprint
    {
        public byte[] Bytes { get; }
        public const string FingerprintRegexError = "Please enter valid md5 hash. Example: " + FingerprintPlaceholder + ".";
        public const string FingerprintPlaceholder = "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53";
        public const string FingerprintRegex = "^([0-9a-f]{2}:){15}[0-9a-f]{2}$";

        public Fingerprint(string fingerprint)
        {
            List<byte> bytes = new List<byte>();

            foreach (string hex in fingerprint.Split(':'))
            {
                bytes.Add(Convert.ToByte(hex, 16));
            }

            Bytes = bytes.ToArray();
        }

        public Fingerprint(byte[] fingerprint)
        {
            Bytes = fingerprint;
        }

        public bool Matches(Fingerprint fingerprint)
        {
            return Bytes.SequenceEqual(fingerprint.Bytes);
        }

        public bool IsValid(string fingerprint)
        {
            return Regex.IsMatch(fingerprint, fingerprint);
        }
    }
}
