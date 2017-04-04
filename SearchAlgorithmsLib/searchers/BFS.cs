using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib.searchers
{
    public class BFS<T> : Searcher<T>, ISearcher<T>
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
                    return BackTrace(n); // private method, back traces through the parents
                }                         // calling the delegated method, returns a list of states with n as a parent

                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);

                foreach (State<T> s in succerssors)
                {
                    if (!SetContains(closed, s) && !OpenContains(s))
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
