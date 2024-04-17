#pragma warning disable IDE0040 // Add accessibility modifiers.

using AccessModifiersInCsharp;

namespace Tests;

class TestShape : Shape
{
    public TestShape(int width, int height)
    {
        Width = width;
        Height = height;
    }
}
