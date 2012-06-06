using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace alchemy
{
    [Serializable]
    public class Dictionary2D
    {

        public Dictionary2D()
        {
            dict = new Dictionary<Pair<string>, string>();
        }

        class PairEqualityComparer<T> : IEqualityComparer<Pair<T>> where T : IComparable
        {

            public bool Equals(Pair<T> p1, Pair<T> p2)
            {
                return p1.Equals(p2);
            }


            public int GetHashCode(Pair<T> bx)
            {
                return bx.First.GetHashCode() * 37 + bx.Second.GetHashCode();
            }

        }


        [Serializable]
        public class Pair<T> where T : IComparable
        {
            public T First { get; set; }
            public T Second { get; set; }

            public Pair(T first, T second)
            {
                if (first.CompareTo(second) > 0)
                {
                    T tmp = first;
                    first = second;
                    second = tmp;
                }
                this.First = first;
                this.Second = second;
            }

            public override bool Equals(object obj)
            {
                Pair<T> val = obj as Pair<T>;
                if (val != null)
                {
                    return val.First.Equals(First) && val.Second.Equals(Second);
                }
                else
                    return false;
            }

            public override int GetHashCode()
            {
                return First.GetHashCode() ^ Second.GetHashCode();
            }

            public static bool operator==(Pair<T> p1, Pair<T> p2)
            {
                if (((object)p1 == null) && ((object)p2 == null))
                    return true;
                if ((object)p1 == null)
                    return false;
                return p1.Equals(p2);
            }

            public static bool operator!=(Pair<T> p1, Pair<T> p2)
            {
                if (((object)p1 == null) && ((object)p2 == null))
                    return false;
                if ((object)p1 == null)
                    return true;
                return !p1.Equals(p2);
            }
        }

        Dictionary<Pair<string>, string> dict;

        public Dictionary<Pair<string>, string>.ValueCollection Values
        {
            get
            {
                return dict.Values;
            }
        }

        public string this[string index0, string index1]
        {
            get
            {
                string result;
                Pair<string> p = new Pair<string>(index0, index1);
                
                if (dict.TryGetValue(p, out result))
                    return result;
                else
                    return null;
            }
            set
            {
                try
                {
                    dict.Add(new Pair<string>(index0, index1), value);
                }
                catch
                {
                    
                }
            }
        }

        public IEnumerable<Pair<string>> Pairs
        {
            get
            {
                foreach (KeyValuePair<Pair<string>, string> p in dict)
                {
                    yield return p.Key;
                }
                yield break;
            }
        }

        public int Size
        {
            get
            {
                return dict.Count;
            }
        }

    }
}
