namespace IHIS.OCSO
{
    public delegate void InsertToEditor(byte[] imageData);

    public delegate void InsertToEditorEmrc(byte[] imageData, string emrcFilePath);

    public interface IImageEditor
    {
        void Edit(byte[] imageData, InsertToEditor callback);

        void Edit(string emrcFilePath, InsertToEditorEmrc callback);
    }    

    class ImageEditor : IImageEditor
    {
        public void Edit(byte[] imageData, InsertToEditor callback)
        {
            callback(imageData);
        }

        public void Edit(string emrcFilePath, InsertToEditorEmrc callback)
        {
            callback(null, emrcFilePath);
        }
    }
}