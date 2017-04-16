using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Generic state class.
    /// </summary>
    /// <typeparam name="T"> a generic type of state. </typeparam>
    public class State<T>
    {
        /// <summary>
        /// Holds the specific type of state it is.
        /// </summary>
        public T TState { get; set; } // the state representation
        //public double Cost { get; set; } // cost to reach this state (set by a setter)
        //public State<T> CameFrom { get; set; } // the state we came from to this state (setter)

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="state"> a generic state. </param>
        private State(T state)
        {
            TState = state;
        }

        /// <summary>
        /// Overloads Object's Equals method.
        /// </summary>
        /// <param name="s"> a state. </param>
        /// <returns> true if equals. false otherwise. </returns>
        public bool Equals(State<T> s)
        {
            return this == s;
        }

        /// <summary>
        /// Overrides State's HashCode function.
        /// </summary>
        /// <returns> it's HashCode. </returns>
        public override int GetHashCode()
        {
            return TState.GetHashCode();
        }

        /// <summary>
        /// Overrides State's 'Equals' function.
        /// </summary>
        /// <param name="obj"> another object. </param>
        /// <returns> true if equals. false otherwise. </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }

        /// <summary>
        /// State pool class.
        /// </summary>
        public static class StatePool
        {
            /// <summary>
            /// Holds the pool as a dictionary of the generic type to it's state.
            /// </summary>
            private static Dictionary<T, State<T>> pool = new Dictionary<T, State<T>>();

            /// <summary>
            /// Checks wheter a state is already exist in pool and return it. create it otherwise.
            /// </summary>
            /// <param name="t"> a generic type to search it's state. </param>
            /// <returns> a state from the state pool. </returns>
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
