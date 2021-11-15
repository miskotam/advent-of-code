using TextCopy;

namespace GlobalUtils {
    public class ClipboardUtils {
        private readonly Clipboard _clipboard;

        public ClipboardUtils() => _clipboard = new Clipboard();

        public void CopyToClipBoard(object obj) {
            _clipboard.SetText($"{obj}");
        }

    }
}