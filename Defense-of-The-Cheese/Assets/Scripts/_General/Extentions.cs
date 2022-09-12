using UnityEngine;

public static class Extentions
{
    public static void Look(this GameObject gm, Vector3 obj)
    {
        Vector3 difference = obj - gm.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    public static void Look(this GameObject gm, Vector3 obj, float offset)
    {
        Vector3 difference = obj - gm.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gm.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + offset);
    }


    public static void RandomPosition(this GameObject gm, GameObject instGm, float deviationsX, float deviationsY)
    {
        Object.Instantiate(instGm, new Vector2(Random.Range(gm.transform.position.x - deviationsX, gm.transform.position.x + deviationsX), Random.Range(gm.transform.position.y - deviationsY, gm.transform.position.y + deviationsY)), Quaternion.identity);
    }
}
