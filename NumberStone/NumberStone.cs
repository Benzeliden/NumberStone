using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberStone
{
    //TODO: make property internal\protected and add proxy class for tests
    public class NumberStone
    {
        public NumberStone(string value, int b = 10)
        {
            Base = b;
            Digits = new List<int>();
        }

        public NumberStone(List<int> values, int b = 10)
        {
            Base = b;
            Digits = values.Select(i => i).ToList();
            Normalize();
        }

        public List<int> Digits { get; set; }

        public int Base { get; protected set; }

        public int this[int i]
        {
            get
            {
                return Digits.Count > i ? Digits[i] : 0;
            }
            set
            {
                if (Digits.Count < i)
                {
                    Digits[i] = value;
                }
                var j = Digits.Count;
                while (j < i)
                {
                    Digits.Add(0);
                    j++;
                }
                Digits.Add(value);
            }
        }

        public void Normalize()
        {
            var i = 0;
            var per = 0;
            while (i < Digits.Count)
            {
                Digits[i] += per;
                per = Digits[i] / Base;
                if (per > 0)
                {
                    Digits[i] = Digits[i] % Base;
                }
                i++;
            }
            while (per > 0)
            {
                var temp = per / Base;
                if (temp > 0)
                {
                    Digits.Add(per % Base);
                    per = temp;
                }
                else
                {
                    Digits.Add(per);
                }

            }
        }

        public NumberStone ConvertTo10()
        {
            var res = new List<int>();

            var i = 0;
            var b = 1;
            while (i < Digits.Count)
            {
                var temp = Digits[i];
                res.Add(temp % b);

                i++;
            }

            return new NumberStone(res);
        }

        public static NumberStone operator +(NumberStone a, NumberStone b)
        {
            if (a.Base != b.Base)
            {
                throw new NotImplementedException();
            }
            var res = new List<int>();

            return a;
        }

        public override string ToString()
        {
            if (Base == 10)
            {
                Normalize();
                var sb = new StringBuilder();
                foreach (var item in Digits)
                {
                    sb.Append(item);
                }

                return sb.ToString();
            }
            return "err";
        }
    }
}
