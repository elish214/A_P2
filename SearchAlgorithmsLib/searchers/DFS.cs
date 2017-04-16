using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    /// <summary>
    /// DFS class.
    /// </summary>
    /// <typeparam name="T"> a generic type to search on. </typeparam>
    public class DFS<T> : Searcher<T>, ISearcher<T>
    {
        /// <summary>
        /// Searching method. uses the DFS on the searchable.
        /// </summary>
        /// <param name="searchable"> search at the searchable </param>
        /// <returns> Returns searchable's solution. </returns>
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            Stack<State<T>> open = new Stack<State<T>>();
            open.Push(searchable.GetInitialState());

            while (open.Count() > 0)
            {
                State<T> n = open.Pop();
                Closed.Add(n); // label it.
                Increase();

                if (n.Equals(searchable.GetGoalState())) // got to the goal state.
                {
                    Solution<T> solution = BackTrace(n);
                    solution.NodesEvaluated = GetNumberOfNodesEvaluated();
                    Clear();
                    return solution;
                }

                List<State<T>> neighbours = searchable.GetAllPossibleStates(n); // get neighbours.

                foreach (State<T> s in neighbours)
                {
                    if (!Closed.Contains(s))
                    {
                        CameFrom[s] = n;
                        open.Push(s);
                    }
                }
            }

            Clear();
            return null;
        }
    }
}
