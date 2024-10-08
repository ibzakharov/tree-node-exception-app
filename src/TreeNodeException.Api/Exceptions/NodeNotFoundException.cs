﻿namespace TreeNodeException.Api.Exceptions;

public class NodeNotFoundException : SecureException
{
    public NodeNotFoundException()
    {
    }

    public NodeNotFoundException(string message) : base(message)
    {
    }

    public NodeNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public static NodeNotFoundException Throw(int nodeId)
    {
        throw new NodeNotFoundException($"Node with ID = {nodeId} was not found");
    }
}