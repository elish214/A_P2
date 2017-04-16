using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Searchable interface.
    /// </summary>
    /// <typeparam name="T"> a generic type to search on. </typeparam>
    public interface ISearchable<T>
    {
        /// <summary>
        /// Returns searchable's initial state.
        /// </summary>
        /// <returns> searchable's initial state. </returns>
        State<T> GetInitialState();
        
        /// <summary>
        /// Returns searchable's goal state.
        /// </summary>
        /// <returns> searchable's goal state. </returns>
        State<T> GetGoalState();

        /// <summary>
        /// Returns a list of all possible states from specific state.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        /// <returns> a list of all possible states from specific state. </returns>
        List<State<T>> GetAllPossibleStates(State<T> s);
    }
}
