using UnityEngine;

public class Dudu {
    private static GameObject _adam;
    private static GameObject _eve;
    private static GameObject _god;

    public static GameObject Adam {
        get {
            _adam = _adam ?? GameObject.Find("Adam");
            return _adam;
        }
    }

    public static GameObject Eve {
        get {
            _eve = _eve ?? GameObject.Find("Eve");
            return _eve;
        }
    }

    public static GameObject God {
        get {
            _god = _god ?? GameObject.Find("God");
            return _god;
        }
    }
}
