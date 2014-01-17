/// <summary>
/// D j_ point. Class that represents a point.
/// @author - Wyatt Sanders 1/15/2014
/// </summary>
/// 
public class DJ_Point
{
	public DJ_Point(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}

	public int X;
	public int Y;

	public override string ToString ()
	{
		return string.Format ("({0}, {1})", X, Y);
	}

	public override bool Equals (object point)
	{
		return ToString().Equals(point.ToString());
	}

	public override int GetHashCode ()
	{
		return ToString().GetHashCode();
	}
}
