
using System.Collections.ObjectModel;

namespace iCrt_01.Model
{
    public class FilePathItem : PathComponent
    {
        public FilePathItem()
        {
            this.Details = new ObservableCollection<FilePathItemDetails>();
        }

        public ObservableCollection<FilePathItemDetails> Details { get; set; }
    }
}
