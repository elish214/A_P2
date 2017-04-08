using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State<T>
    {
        public T TState { get; set; } // the state representation
        //public double Cost { get; set; } // cost to reach this state (set by a setter)
        //public State<T> CameFrom { get; set; } // the state we came from to this state (setter)

        private State(T state) // CTOR
        {
            TState = state;
        }

        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return this == s;
        }

        public override int GetHashCode()
        {
            return TState.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }

        public static class StatePool
        {
            private static Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();

            public static State<T> GetState(T t)
            {
                if (!pool.ContainsKey(t))
                {
                    pool[t] = new State<T>(t);
                    Console.WriteLine(" created");
                }
                else
                {
                    Console.WriteLine(" found");
                }
                return pool[t];
            }
        }
    }
}
