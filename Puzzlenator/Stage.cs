using System;

namespace Puzzlenator;

/// <summary>
/// Represents a game map structure.
/// </summary>
public class Stage
{
    public readonly int Height;
    public readonly int Width;
    readonly Tile[] tiles;

    private Stage(int height, int width, Tile[] tiles)
    {
        Width = width;
        Height = height;
        this.tiles = tiles;
    }

    public Tile? this[int i, int j] => 
        i < 0 || i >= Width || j < 0 || j >= Height ?
        tiles[i + Width * j] : null;

    static int ValidateHeight(int width, int tilesCount)
    {
        if (width < 1)
            throw new InvalidOperationException("A stage needs a positive width.");
        
        if (tilesCount < 1)
            throw new InvalidOperationException("A stage needs a positive size.");
        
        if (tilesCount % width != 0)
            throw new InvalidOperationException($"A number of tiles ({tilesCount}) needs be multiple of the width ({width}).");
        
        int height = tilesCount / width;
        return height;
    }
    
    /// <summary>
    /// Create a stage.
    /// </summary>
    public static Stage Create(int width, params TileArchetype[] archetypes)
    {
        ArgumentNullException.ThrowIfNull(archetypes, nameof(archetypes));
        var size = archetypes.Length;
        int height = ValidateHeight(width, size);
        var tiles = new Tile[width * height];

        for (int j = 0, index = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++, index++)
            {
                var archetype = archetypes[index] ??
                    throw new NullReferenceException($"The {index} position on archetypes array is null.");
                tiles[j * width + i] = archetype.Create(i, j);
            }
        }

        return new Stage(height, width, tiles);
    }
    
    /// <summary>
    /// Create a stage rounded by walls.
    /// </summary>
    public static Stage CreateRounded(int width, params TileArchetype[] archetypes)
    {
        ArgumentNullException.ThrowIfNull(archetypes, nameof(archetypes));
        var size = archetypes.Length;
        int height = ValidateHeight(width, size);

        width += 2;
        height += 2;
        var rounded = new TileArchetype[width * height];

        for (int i = 0; i < width; i++)
            rounded[i] = TileArchetype.Wall;

        for (int j = 1, index = 0; j < height - 1; j++)
        {
            rounded[j * width] = TileArchetype.Wall;
            for (int i = 1; i < width - 1; i++, index++)
                rounded[i + j * width] = archetypes[index];
            rounded[width - 1 + j * width] = TileArchetype.Wall;
        }
            
        for (int i = 0; i < width; i++)
            rounded[i + (height - 1) * width] = TileArchetype.Wall;

        return Create(width, archetypes);
    }
}