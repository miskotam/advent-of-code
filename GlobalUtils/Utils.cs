using TextCopy;

namespace GlobalUtils {
    public class Utils {
        private readonly Clipboard _clipboard;

        public void CopyToClipBoard(object obj) {
            _clipboard.SetText($"{obj}");
        }

        public Utils() => _clipboard = new Clipboard();
    }
}