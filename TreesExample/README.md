## Trees:


I wasn't specifically able to really understand how to properly implement a tree, so this is more of a concept.


Using a StreamReader, I would read the scores.txt file and recursively place the values within the tree.
Trees organize values using a hierarchy, with each value being called a node. Each node can have children. If a node has
children, it is a parent node. If node is the first node, it is the root. If a tree has nodes with at most two children, it is a binary tree.

Using Depth First Search, you would search all of the nodes by going ahead in the tree, or by backtracking once you run out of nodes on that path.
This program would use DFS when searching for a specific score in the tree, but I'm not sure how to start about developing and creating the Tree
at this point in time.