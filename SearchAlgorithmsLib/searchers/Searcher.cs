using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    /// <summary>
    /// Searcher abstract class.
    /// </summary>
    /// <typeparam name="T"> a generic type to search on. </typeparam>
    public abstract class Searcher<T> : ISearcher<T>
    {
        /// <summary>
        /// Holds number of evaluated nodes in the current moment. 
        /// </summary>
        private int evaluatedNodes;
        
        /// <summary>
        /// Holds an HashSet of states already been checked.
        /// </summary>
        protected HashSet<State<T>> Closed { get; }
        
        /// <summary>
        /// Holds a dictionary of states to their previous states.
        /// </summary>
        protected Dictionary<State<T>, State<T>> CameFrom { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Searcher()
        {
            evaluatedNodes = 0;
            Closed = new HashSet<State<T>>();
            CameFrom = new Dictionary<State<T>, State<T>>();
        }

        /// <summary>
        /// Increasing number of nodes evaluated.
        /// </summary>
        public void Increase()
        {
            evaluatedNodes++;
        }

        /// <summary>
        /// returns the number of nodes that been evaluated during the search.
        /// </summary>
        /// <returns> number of nodes that been evaluated during the search. </returns>
        public int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        /// <summary>
        /// Returns the back trace of states from a specific state.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        /// <returns> back trace of states from a specific state. </returns>
        protected Solution<T> BackTrace(State<T> s)
        {
            Solution<T> solution = new Solution<T>();           

            while (CameFrom.Keys.Contains(s))
            {
                solution.Add(s);
                s = CameFrom[s];
            }

            solution.Add(s);

            return solution;
        }

        /// <summary>
        /// Clears both HashSet and dictionary.
        /// </summary>
        protected virtual void Clear()
        {
            CameFrom.Clear();
            Closed.Clear();
        }

        /// <summary>
        /// Searching method. uses on the searchable.
        /// </summary>
        /// <param name="searchable"> search at the searchable </param>
        /// <returns> Returns searchable's solution. </returns>
        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
