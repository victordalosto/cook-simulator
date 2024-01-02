

public interface IObjectHolder<T> {

    bool hasObject();

    void placeObject(T obj);

    T obtainObject();

}