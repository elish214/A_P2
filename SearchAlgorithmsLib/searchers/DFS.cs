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
            AddToOpenList(searchable.GetInitialState());
            HashSet<State<T>> discovered = new HashSet<State<T>>(); // labeled as discovered.

            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList();

                if (n.Equals(searchable.GetGoalState())) // got to the goal state.
                {
                    //return AllDiscovered(discovered, searchable);
                    return BackTrace(n);
                }

                discovered.Add(n); // label it.
                List<State<T>> neighbours = searchable.GetAllPossibleStates(n); // get neighbours.

                foreach (State<T> s in neighbours)
                {
                    if (!SetContains(discovered, s))
                    {
                        AddToOpenList(s);
                    }
                }
            }

            return null;
        }
    }
}
