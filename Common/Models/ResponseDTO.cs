
namespace Common.Models
{
    public class ResponseDTO<T>
    {
        private HeaderDTO _header;

        public HeaderDTO Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new HeaderDTO();
                }

                return _header;
            }
            set
            {
                _header = value;
            }
        }

        public T Data { get; set; }
    }
}
