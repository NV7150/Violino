using ScoreControl;

namespace Judge {
    public interface RhythmInput {
        bool isJudgeTiming(NoteLane lane);
        bool getButton(NoteLane lane);
        NoteDirection getDirection();
    }
}
