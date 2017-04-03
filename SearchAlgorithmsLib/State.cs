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
        public double Cost { get; set; } // cost to reach this state (set by a setter)
        public State<T> CameFrom { get; set; } // the state we came from to this state (setter)

        public State(T state, State<T> cameFrom = null, double cost = 0) // CTOR
        {
            TState = state;
            CameFrom = cameFrom;
            Cost = cost;
        }

        public String ToString()
        {
            return $"{TState}, {Cost}, {CameFrom}";
        }

        public bool Equals(State<T> s) // we overload Object's Equals method
        {
            return TState.Equals(s.TState);
        }
    }
}
