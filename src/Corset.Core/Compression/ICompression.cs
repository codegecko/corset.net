using System.IO;
using System.Text;

namespace Corset.Core.Compression
{
    public interface ICompression
    {
        string AcceptType { get; }

        string Compress(Stream content, Encoding encoding);
    }
}