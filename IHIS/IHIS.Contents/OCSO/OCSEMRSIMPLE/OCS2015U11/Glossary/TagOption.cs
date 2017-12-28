namespace EmrDocker.Glossary
{
    public enum TagOption
    {
        [StringValue("タグコードの表示")]
        TagCode = 1,
        [StringValue("タグ名の表示")]
        TagDisplay = 2,
        [StringValue("両方表示")]
        Both = 3
    }
}