using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using SearchAlgorithmsLib;

namespace SearchAlgorithmsLib.searchers
{
    public class BFS<T, S> : PrioritySearcher<T, S>, ISearcher<T> where S : IComparable<S>
    {
        public BFS(Weight w, Addition add) : base(w, add)
        {
        }

        public override Solution<T> Search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            State<T> state = searchable.GetInitialState();
            //HashSet<State<T>> closed = new HashSet<State<T>>();
            Cost[state] = default(S);
            AddToOpenList(state); // inherited from Searcher

            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList(); // inherited from Searcher, removes the best state
                Closed.Add(n);

                if (n.Equals(searchable.GetGoalState()))
                {
                    Solution<T> solution = BackTrace(n);
                    solution.NodesEvaluated = GetNumberOfNodesEvaluated();
                    Clear();
                    return solution; // private method, back traces through the parents
                }                         // calling the delegated method, returns a list of states with n as a parent

                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);

                foreach (State<T> s in succerssors)
                {
                    if (!Closed.Contains(s) && !OpenContains(s))
                    {
                        Update(s, n);
                        AddToOpenList(s);
                    }
                    else if (OpenContains(s) && Cost[GetOpenElem(s)].CompareTo(Cost[s]) > 0)
                    {
                        Update(s, n);
                        UpdatePriority(s);
                    }
                }
            }

            Clear();
            return null;
        }
    }
}
