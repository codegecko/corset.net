using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Corset.Core.Compression
{
    #region Stream filter

    public class HtmlWhitespaceStream : Stream
    {

        public HtmlWhitespaceStream(Stream sink) { _sink = sink; }

        private Stream _sink;
        private static Regex reg = new Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}");

        #region Properites

        public override bool CanRead { get { return true; } }

        public override bool CanSeek { get { return true; } }

        public override bool CanWrite { get { return true; } }

        public override void Flush() { _sink.Flush(); }

        public override long Length { get { return 0; } }

        private long _position;
        public override long Position
        {
            get { return _position; }
            set { _position = value; }
        }

        #endregion

        #region Methods

        public override int Read(byte[] buffer, int offset, int count) {
            return _sink.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin) {
            return _sink.Seek(offset, origin);
        }

        public override void SetLength(long value) { _sink.SetLength(value); }

        #if DOTNET4
        public override void Close() { _sink.Close(); }
        #endif

        public override void Write(byte[] buffer, int offset, int count)
        {
            byte[] data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            #if DOTNET5
            string html = System.Text.Encoding.UTF8.GetString(buffer);
            #elif DOTNET4
            string html = System.Text.Encoding.Default.GetString(buffer);
            #endif

            html = reg.Replace(html, string.Empty);
            #if DOTNET5
            byte[] outdata = System.Text.Encoding.UTF8.GetBytes(html);
            #elif DOTNET4
            byte[] outdata = System.Text.Encoding.Default.GetBytes(html);
            #endif
            _sink.Write(outdata, 0, outdata.GetLength(0));
        }

#endregion

    }

#endregion
}
