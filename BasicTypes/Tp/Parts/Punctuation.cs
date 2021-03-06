﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes
{
    [DataContract]
    [Serializable]
    public class Punctuation : IParse<Punctuation>, IToString
    {
        [DataMember]
        private readonly string symbol;

        private const string symbols = ":.?!";
        public Punctuation(string symbol)
        {
            symbol = symbol.Trim();
            if (symbol.Length != 1)
            {
                throw new InvalidOperationException("Punctuation must be 1 char long");
            }
            if (!symbols.ContainsCheck(symbol))
            {
                throw new InvalidOperationException("Punctuation must be : or . or ? or !");
            }
            this.symbol = symbol;
        }

        public override string ToString()
        {
            return this.ToString("g");
        }

        public static Punctuation Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return new Punctuation(value);
        }

        bool IParse<Punctuation>.TryParse(string value, out Punctuation result)
        {
            return TryParse(value, out result);
        }

        public bool TryParse(string value, IFormatProvider provider, out Punctuation result)
        {
            Config c = provider.GetFormat(typeof(Punctuation)) as Config;

            return TryParse(value, out result);
        }

        Punctuation IParse<Punctuation>.Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return Parse(value);
        }

        public static bool TryParse(string value, out Punctuation result)
        {
            try
            {
                result = new Punctuation(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public static bool ContainsPunctuation(string value)
        {
            foreach (char c in symbols)
            {
                if (value.ContainsCheck(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsPunctuation(string[] values)
        {
            foreach (string value in values)
            {
                foreach (char c in symbols)
                {
                    if (value.ContainsCheck(c))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }
        public string ToString(string format)
        {
            return symbol;
        }
    }
}
