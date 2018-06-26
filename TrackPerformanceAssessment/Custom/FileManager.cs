using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using TPA.Framework.Core;

namespace TPA.Custom
{
    // 직렬화/역직렬화로 파일을 저장하는 클래스
    public class FileManager : Singleton<FileManager>
    {
        // 클래스를 직렬화해서 텍스트 파일로 저장한다
        public void WriteFile<T>(T data, string path) where T: class
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
                stream.Close();
            }
        }

        // 텍스트 파일의 정보를 역직렬화해서 데이터로 만들어 반환한다
        public T ReadFile<T>(string path) where T : class
        {
            T ret = null;
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                ret = formatter.Deserialize(stream) as T;
                stream.Close();
            }
            return ret;
        }
    }
}
