using System.Collections.ObjectModel;

namespace iCrt_01.Model
{
    public class FilePathFolder : PathComponent
    {
        public FilePathFolder()
        {
            Children = new ObservableCollection<PathComponent>();
        }

        public ObservableCollection<PathComponent> Children { get; set; }
    }
}
