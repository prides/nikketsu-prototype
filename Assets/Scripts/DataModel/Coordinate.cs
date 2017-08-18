using UnityEngine;

[System.Serializable]
public struct Coordinate
{
    [SerializeField]
    private double latitude;
    public double Latitude
    {
        get { return latitude; }
        set
        {
            latitude = value > -90.0 && value < 90.0 ? value : latitude;
        }
    }

    [SerializeField]
    private double longitude;
    public double Longitude
    {
        get { return longitude; }
        set
        {
            longitude = value < -180.0 ? value + 360.0 : value >= 180.0 ? value - 360.0 : value;
        }
    }

    [SerializeField]
    private double altitude;
    public double Altitude
    {
        get { return altitude; }
        set { altitude = value; }
    }

    public Coordinate(double lat, double lon, double alt) : this()
    {
        Latitude = lat;
        Longitude = lon;
        Altitude = alt;
    }

    public static Coordinate Lerp(Coordinate from, Coordinate to, float time)
    {
        if (time > 1.0f)
        {
            return to;
        }
        else if (time < 0.0f)
        {
            return from;
        }

        return from + ((to - from) * time);
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Coordinate))
        {
            return false;
        }
        else
        {
            return this == (Coordinate)obj;
        }
    }

    public override int GetHashCode()
    {
        int hash = 17;

        hash = hash * 23 + Latitude.GetHashCode();
        hash = hash * 23 + Longitude.GetHashCode();
        hash = hash * 23 + Altitude.GetHashCode();

        return hash;
    }

    #region Operators
    public static bool operator ==(Coordinate value1, Coordinate value2)
    {
        return value1.Latitude  == value2.Latitude
            && value1.Longitude == value2.Longitude
            && value1.Altitude  == value2.Altitude;
    }

    public static bool operator !=(Coordinate value1, Coordinate value2)
    {
        return !(value1 == value2);
    }

    public static Coordinate operator +(Coordinate value1, Coordinate value2)
    {
        value1.Latitude  += value2.Latitude;
        value1.Longitude += value2.Longitude;
        value1.Altitude  += value2.Altitude;
        return value1;
    }

    public static Coordinate operator -(Coordinate value1, Coordinate value2)
    {
        value1.Latitude  -= value2.Latitude;
        value1.Longitude -= value2.Longitude;
        value1.Altitude  -= value2.Altitude;
        return value1;
    }

    public static Coordinate operator *(Coordinate value, float scaleFactor)
    {
        value.Latitude  *= scaleFactor;
        value.Longitude *= scaleFactor;
        value.Altitude  *= scaleFactor;
        return value;
    }
    #endregion
}
