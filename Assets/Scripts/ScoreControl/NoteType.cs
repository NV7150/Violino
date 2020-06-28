namespace ScoreControl {
    public enum NoteType {
        SHORT = 1,
        LONG = 2,
        LONG_SECTION = 3,
        BANISHED = 4
    }

    public static class NoteTypeHelper {
        public static bool isJudgeableNote(NoteType type) {
            return type == NoteType.SHORT || type == NoteType.LONG;
        }
    }
}