

public interface IObjectHolder<T> {

    bool hasObject();

    void placeObject(T kitchenObject);

    T obtainObject();

}