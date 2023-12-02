namespace GlobalUtils.PathFinding {
    public class Node<T> : IHeapItem<Node<T>> {

        public bool Walkable { get; }
        public int GridX { get; }
        public int GridY { get; }
        public int MovementPenalty { get; }
        public object Value { get; }

        public Node<T> Parent { get; set; }
        public int HeapIndex { get; set; }

#pragma warning disable IDE1006
        public int gCost { get; set; }
        public int hCost { get; set; }
        public int fCost => gCost + hCost;
#pragma warning restore IDE1006

        public Node(bool walkable, int gridX, int gridY, int penalty, T value) {
            Walkable = walkable;
            GridX = gridX;
            GridY = gridY;
            MovementPenalty = penalty;
            Value = value;
        }

        public int CompareTo(Node<T> nodeToCompare) {
            var compare = fCost.CompareTo(nodeToCompare.fCost);
            if (compare == 0) {
                compare = hCost.CompareTo(nodeToCompare.hCost);
            }
            return -compare;
        }
    }
}