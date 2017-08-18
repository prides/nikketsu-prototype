using UnityEngine;

public class Converter
{
    public static Coordinate Vector3ToCoordinate(Vector3 vector)
    {
        Coordinate result = new Coordinate();
        return result;
    }

    public static Vector3 CoordinateToVector3(Coordinate coordinate)
    {
        Vector3 result = new Vector3();
        float lat = (float)(coordinate.Latitude) * Mathf.Deg2Rad;
        float lon = (float)(coordinate.Longitude) * Mathf.Deg2Rad;
        float alt = (float)coordinate.Altitude;
        result.x = alt * Mathf.Cos(lat) * Mathf.Cos(lon);
        result.z = alt * Mathf.Cos(lat) * Mathf.Sin(lon);
        result.y = alt * Mathf.Sin(lat);
        return result;
    }
}
