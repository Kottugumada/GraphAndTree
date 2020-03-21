// Adjacency Matrix time complexity is O(vertices ^2)
using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
	public class CourseScheduling_AdjMatrix_Courses
	{
		public int[] FindOrder(int numCourses, int[][] prerequisites)
		{
			int[] inDegree = new int[numCourses];
			Stack<int> nodeWithNoIncomingEdges = new Stack<int>();
            List<int> courses = new List<int>();

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
                // if the sample set is [[1,0],[2,0],[3,1],[3,2]]
                // stack should eventually have 1 and 2
                // might start with a [1,0]
                if (inDegree[i] == 0)
				{
					nodeWithNoIncomingEdges.Push(i);
				}
			}
			// loop till stack is not empty
			while (nodeWithNoIncomingEdges.Count > 0)
			{
				int curr = nodeWithNoIncomingEdges.Pop();
                courses.Insert(0,curr);
                // iterate over the prerequisites array to check  if the course that we just popped off is in the prerequisites
                for (int i = 0; i < prerequisites.Length; i++)
				{
                    // look for courses which had a dependency 
                    // if the sample set is [[1,0],[2,0],[3,1],[3,2]]
                    // it would first identify [1, 0]
                    if (prerequisites[i][1] == curr)
					{
                        // remove courses which were previously dependent on this one course, from prerequisites
                        inDegree[prerequisites[i][0]]--;
						// if we met all the rquirements for a certain vertex, we can add it to the stack
                        // removing dependency that course 1 has
						if (inDegree[prerequisites[i][0]] == 0)
						{
							nodeWithNoIncomingEdges.Push(prerequisites[i][0]);
						}
					}
				}
			}
            if (courses.Count != numCourses) return new int[0];
            return courses.ToArray();
		}
	}
}
