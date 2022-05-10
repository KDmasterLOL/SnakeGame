sealed class MapsInit : StorageInit<MapObject>
{
    public override void Init() => MapsStorage.Set(Items);
}