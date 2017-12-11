using System;

public class Display
{
    private int size;
    private int numOfColors;

    public Display(int size, int numOfColors)
    {
        this.Size = size;
        this.NumOfColors = numOfColors;
    }

    public int Size
    {
        get { return this.size; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Display size is incorrect!");
            }

            this.size = value;
        }
    }

    public int NumOfColors
    {
        get { return this.numOfColors; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Display colors number is incorrect!");
            }

            this.numOfColors = value;
        }
    }

}
