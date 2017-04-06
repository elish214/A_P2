using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using SearchAlgorithmsLib;

namespace SearchAlgorithmsLib.searchers
{
    public class BFS<T> : PrioritySearcher<T>, ISearcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            AddToOpenList(searchable.GetInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();

            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);

                if (n.Equals(searchable.GetGoalState()))
                {
                    Solution<T> solution = BackTrace(n);
                    solution.NodesEvaluated = GetNumberOfNodesEvaluated();
                    return solution; // private method, back traces through the parents
                }                         // calling the delegated method, returns a list of states with n as a parent

                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);

                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !OpenContains(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        AddToOpenList(s);
                    }
                    else if (OpenContains(s) && GetOpenElem(s).Cost > s.Cost)
                    {
                        UpdatePriority(s);
                    }
                }
            }

            return null;
        }
    }
}
