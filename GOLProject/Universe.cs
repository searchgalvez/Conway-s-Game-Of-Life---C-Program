using System;
using System.Drawing;

namespace GOLProject
{
  public class Universe
  {
    private Cell[,] universe;
    private Cell[,] next;
    private int livingCells;
    private int generation;
    private BoundaryType edgeCondition;

    public Universe()
    {
      this.universe = new Cell[25, 25];
      this.next = new Cell[25, 25];
    }

    public Universe(int width, int height)
    {
      this.universe = new Cell[width, height];
      this.next = new Cell[width, height];
    }

    public int LivingCells => this.livingCells;

    public int Generation => this.generation;

    public Size Size
    {
      get => new Size(this.universe.GetLength(0), this.universe.GetLength(1));
      set
      {
        this.universe = new Cell[value.Width, value.Height];
        this.next = new Cell[value.Width, value.Height];
      }
    }

    public int GetNeighborCount(int x, int y)
    {
      int neighborCount = 0;
      switch (this.edgeCondition)
      {
        case BoundaryType.Toroidal:
          neighborCount = this.CountNeighborsAbsolute_Toroidal(x, y);
          break;
        case BoundaryType.Finite:
          neighborCount = this.CountNeighborsAbsolute_EdgeOfTheWorld(x, y);
          break;
      }
      return neighborCount;
    }

    public BoundaryType BoundaryType
    {
      get => this.edgeCondition;
      set => this.edgeCondition = value;
    }

    public Cell this[int x, int y]
    {
      get => this.universe[x, y];
      set
      {
        if (value.Alive & this.universe[x, y].Dead)
          ++this.livingCells;
        else if (value.Dead & this.universe[x, y].Alive)
          --this.livingCells;
        this.universe[x, y] = value;
      }
    }

    public void NextGeneration()
    {
      int length1 = this.universe.GetLength(0);
      int length2 = this.universe.GetLength(1);
      this.livingCells = 0;
      for (int x = 0; x < length1; ++x)
      {
        for (int y = 0; y < length2; ++y)
        {
          this.next[x, y].Dead = true;
          int num = 0;
          switch (this.edgeCondition)
          {
            case BoundaryType.Toroidal:
              num = this.CountNeighborsOptimized_Toroidal(x, y);
              break;
            case BoundaryType.Finite:
              num = this.CountNeighborsOptimized_EdgeOfTheWorld(x, y);
              break;
          }
          if (this.universe[x, y].Alive)
          {
            if (num >= 2 && num <= 3)
            {
              this.next[x, y].Alive = true;
              ++this.livingCells;
            }
          }
          else if (num == 3)
          {
            this.next[x, y].Alive = true;
            ++this.livingCells;
          }
        }
      }
      Cell[,] universe = this.universe;
      this.universe = this.next;
      this.next = universe;
      ++this.generation;
    }

    private int CountNeighborsAbsolute_Toroidal(int x, int y)
    {
      int num = 0;
      int upperBound1 = this.universe.GetUpperBound(0);
      int upperBound2 = this.universe.GetUpperBound(1);
      int index1 = x > 0 ? x - 1 : upperBound1;
      int index2 = y > 0 ? y - 1 : upperBound2;
      if (this.universe[index1, index2].Alive)
        ++num;
      if (this.universe[x, index2].Alive)
        ++num;
      if (this.universe[x < upperBound1 ? x + 1 : 0, index2].Alive)
        ++num;
      int index3 = x > 0 ? x - 1 : upperBound1;
      int index4 = y;
      if (this.universe[index3, index4].Alive)
        ++num;
      if (this.universe[x < upperBound1 ? x + 1 : 0, index4].Alive)
        ++num;
      int index5 = x > 0 ? x - 1 : upperBound1;
      int index6 = y < upperBound2 ? y + 1 : 0;
      if (this.universe[index5, index6].Alive)
        ++num;
      if (this.universe[x, index6].Alive)
        ++num;
      if (this.universe[x < upperBound1 ? x + 1 : 0, index6].Alive)
        ++num;
      return num;
    }

    private int CountNeighborsOptimized_Toroidal(int x, int y)
    {
      int num = 0;
      int upperBound1 = this.universe.GetUpperBound(0);
      int upperBound2 = this.universe.GetUpperBound(1);
      int index1 = x > 0 ? x - 1 : upperBound1;
      int index2 = y > 0 ? y - 1 : upperBound2;
      if (this.universe[index1, index2].Alive)
        ++num;
      if (this.universe[x, index2].Alive)
        ++num;
      if (this.universe[x < upperBound1 ? x + 1 : 0, index2].Alive)
        ++num;
      int index3 = x > 0 ? x - 1 : upperBound1;
      int index4 = y;
      if (this.universe[index3, index4].Alive)
        ++num;
      if (num >= 4)
        return num;
      if (this.universe[x < upperBound1 ? x + 1 : 0, index4].Alive)
        ++num;
      if (num >= 4)
        return num;
      int index5 = x > 0 ? x - 1 : upperBound1;
      int index6 = y < upperBound2 ? y + 1 : 0;
      if (this.universe[index5, index6].Alive)
        ++num;
      if (num >= 4)
        return num;
      if (this.universe[x, index6].Alive)
        ++num;
      if (num >= 4 || !this.universe[x < upperBound1 ? x + 1 : 0, index6].Alive)
        return num;
      ++num;
      return num;
    }

    private int CountNeighborsOptimized_EdgeOfTheWorld(int x, int y)
    {
      int num = 0;
      int length1 = this.universe.GetLength(0);
      int length2 = this.universe.GetLength(1);
      if (x - 1 >= 0 && y - 1 >= 0 && this.universe[x - 1, y - 1].Alive)
        ++num;
      if (y - 1 >= 0 && this.universe[x, y - 1].Alive)
        ++num;
      if (x + 1 < length1 && y - 1 >= 0 && this.universe[x + 1, y - 1].Alive)
        ++num;
      if (x - 1 >= 0 && this.universe[x - 1, y].Alive)
        ++num;
      if (num >= 4)
        return num;
      if (x + 1 < length1 && this.universe[x + 1, y].Alive)
        ++num;
      if (num >= 4)
        return num;
      if (x - 1 >= 0 && y + 1 < length2 && this.universe[x - 1, y + 1].Alive)
        ++num;
      if (num >= 4)
        return num;
      if (y + 1 < length2 && this.universe[x, y + 1].Alive)
        ++num;
      if (num >= 4 || x + 1 >= length1 || y + 1 >= length2 || !this.universe[x + 1, y + 1].Alive)
        return num;
      ++num;
      return num;
    }

    private int CountNeighborsAbsolute_EdgeOfTheWorld(int x, int y)
    {
      int num = 0;
      int length1 = this.universe.GetLength(0);
      int length2 = this.universe.GetLength(1);
      if (x - 1 >= 0 && y - 1 >= 0 && this.universe[x - 1, y - 1].Alive)
        ++num;
      if (y - 1 >= 0 && this.universe[x, y - 1].Alive)
        ++num;
      if (x + 1 < length1 && y - 1 >= 0 && this.universe[x + 1, y - 1].Alive)
        ++num;
      if (x - 1 >= 0 && this.universe[x - 1, y].Alive)
        ++num;
      if (x + 1 < length1 && this.universe[x + 1, y].Alive)
        ++num;
      if (x - 1 >= 0 && y + 1 < length2 && this.universe[x - 1, y + 1].Alive)
        ++num;
      if (y + 1 < length2 && this.universe[x, y + 1].Alive)
        ++num;
      if (x + 1 < length1 && y + 1 < length2 && this.universe[x + 1, y + 1].Alive)
        ++num;
      return num;
    }

    public void Randomize(int seed)
    {
      this.Clear();
      Random random = new Random(seed);
      int length1 = this.universe.GetLength(0);
      int length2 = this.universe.GetLength(1);
      this.livingCells = 0;
      this.generation = 0;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
        {
          if (random.Next(0, 3) == 0)
          {
            this.universe[index1, index2].Alive = true;
            ++this.livingCells;
          }
        }
      }
    }

    public void Clear()
    {
      int length1 = this.universe.GetLength(0);
      int length2 = this.universe.GetLength(1);
      this.livingCells = 0;
      this.generation = 0;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
          this.universe[index1, index2].Dead = true;
      }
    }
  }
}
