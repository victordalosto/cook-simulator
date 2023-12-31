using UnityEngine;


/// <summary>
/// A static instance is a singleton that updates itself with new instances.
/// It overwrites its self Singleton with the new instances created.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour {

    public static T Instance { get; private set; }

    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}



/// <summary>
/// This transforms the static instance into a basic singleton.
/// This will destroy any new version created, leaving the original instance intact.
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour {

    protected override void Awake() {
        if (Instance != null) {
            Debug.LogWarning($"Duplicated singleton: {gameObject.name}");
            Destroy(gameObject);
            return;
        }
        base.Awake();
    }
}



/// <summary>
/// This transforms the singleton into a persistent singleton. This will destroy any new
/// version created, leaving the original instance intact
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {

    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
