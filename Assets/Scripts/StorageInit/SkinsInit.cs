sealed class SkinsInit : StorageInit<SkinObject>
{
    public override void Init() => SkinsStorage.Set(Items);
}