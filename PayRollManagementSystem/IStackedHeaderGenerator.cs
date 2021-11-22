using System.Windows.Forms;

namespace StackedHeader
{
    public interface IStackedHeaderGenerator
    {
        Header GenerateStackedHeader(DataGridView objGridView);
    }
}
