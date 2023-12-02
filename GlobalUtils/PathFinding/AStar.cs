using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalUtils.PathFinding {
    public class AStar<T> {
        public static List<Node<T>> FindPath(Node<T>[,] grid, Node<T> startNode, Node<T> targetNode, Func<Node<T>, Node<T>[,], IEnumerable<Node<T>>> neighborSelector) {
            var pathFound = false;

            startNode.Parent = startNode;

            if (startNode.Walkable && targetNode.Walkable) {
                var openSet = new Heap<Node<T>>(grid.GetLength(0) * grid.GetLength(1));
                var closedSet = new HashSet<Node<T>>();
                openSet.Add(startNode);

                while (openSet.Count > 0) {
                    var currentNode = openSet.RemoveFirst();
                    _ = closedSet.Add(currentNode);

                    if (currentNode == targetNode) {
                        pathFound = true;
                        break;
                    }
                    var neighbors = neighborSelector(currentNode, grid).ToList();
                    foreach (var neighbor in neighbors) {
                        if (!neighbor.Walkable || closedSet.Contains(neighbor)) {
                            continue;
                        }

                        var newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor) + neighbor.MovementPenalty;
                        if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor)) {
                            neighbor.gCost = newMovementCostToNeighbor;
                            neighbor.hCost = GetDistance(neighbor, targetNode);
                            neighbor.Parent = currentNode;

                            if (!openSet.Contains(neighbor))
                                openSet.Add(neighbor);
                            else
                                openSet.UpdateItem(neighbor);
                        }
                    }
                }
            }

            if (pathFound) {
                var nodes = RetracePath(startNode, targetNode);
                return nodes;
            }
            else {
                return null;
            }
        }

        private static List<Node<T>> RetracePath(Node<T> startNode, Node<T> endNode) {
            var path = new List<Node<T>>();
            var currentNode = endNode;

            while (currentNode != startNode) {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            return path;

        }

        private static int GetDistance(Node<T> nodeA, Node<T> nodeB) {
            var dstX = Math.Abs(nodeA.GridX - nodeB.GridX);
            var dstY = Math.Abs(nodeA.GridY - nodeB.GridY);
            var straightCost = 10; // 10 * 1
            var diagonalCost = 14; // 10 * sqrt(2)

            if (dstX > dstY)
                return diagonalCost * dstY + straightCost * (dstX - dstY);
            return diagonalCost * dstX + straightCost * (dstY - dstX);
        }

    }
}