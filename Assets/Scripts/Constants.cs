using UnityEngine;

public class Constants {
    private static GameObject _adam;
    private static GameObject _eve;
    private static GameObject _god;

    public static GameObject Adam() {
        _adam = _adam ?? GameObject.Find("Adam");
        return _adam;
    }

    public static GameObject Eve() {
        _eve = _eve ?? GameObject.Find("Eve");
        return _eve;
    }

    public static GameObject God() {
        _god = _god ?? GameObject.Find("God");
        return _god;
    }
}
