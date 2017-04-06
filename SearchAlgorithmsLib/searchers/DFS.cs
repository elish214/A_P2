using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public class DFS<T> : Searcher<T>, ISearcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            Stack<State<T>> open = new Stack<State<T>>();
            open.Push(searchable.GetInitialState());
            HashSet<State<T>> discovered = new HashSet<State<T>>(); // labeled as discovered.

            while (open.Count() > 0)
            {
                State<T> n = open.Pop();
                discovered.Add(n); // label it.
                Increase();

                if (n.Equals(searchable.GetGoalState())) // got to the goal state.
                {
                    Solution<T> solution = BackTrace(n);
                    solution.NodesEvaluated = GetNumberOfNodesEvaluated();
                    return solution;
                }

                List<State<T>> neighbours = searchable.GetAllPossibleStates(n); // get neighbours.

                foreach (State<T> s in neighbours)
                {
                    if (!discovered.Contains(s))
                    {
                        open.Push(s);
                    }
                }
            }

            return null;
        }
    }
}
