// Adjacency Matrix time complexity is O(vertices ^2)
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
	public class CourseScheduling_AdjMatrix
	{
		public bool CanFinish(int numCourses, int[][] prerequisites)
		{
			int[] inDegree = new int[numCourses];
			Stack<int> st = new Stack<int>();

			int count = 0; // to check the the number of courses possible

			// calculate all the courses that have prerequisites
			// i is dependent on 0
			for (int i = 0; i < prerequisites.Length; i++)
			{
				inDegree[prerequisites[i][0]]++;
			}
			// add every single vertex that has no prerequisites
			// if inDegree[i] == 0 that means that there are no dependencies on inDegree[i]
			for (int i = 0; i < inDegree.Length; i++)
			{
				if (inDegree[i] == 0)
				{
					st.Push(i);
				}
			}
			// loop till stack is not empty
			while (st.Count > 0)
			{
				int curr = st.Pop();
				count++;
				// iterate over the prerequisites array to check  if the course that we just popped off is in the prerequisites
				for (int i = 0; i < prerequisites.Length; i++)
				{
					if (prerequisites[i][1] == curr)
					{
						inDegree[prerequisites[i][0]]--;
						// if we met all the rquirements for a certain vertex, we can add it to the stack
						if (inDegree[prerequisites[i][0]] == 0)
						{
							st.Push(prerequisites[i][0]);
						}
					}
				}
			}
			return count == numCourses;
		}
	}
}
