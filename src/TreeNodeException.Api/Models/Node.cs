﻿public class Node
{
    public int NodeId { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public Node Parent { get; set; }
    public ICollection<Node> Children { get; set; } = new List<Node>(); // Инициализация коллекции
    public int TreeId { get; set; }
    public Tree Tree { get; set; }
}