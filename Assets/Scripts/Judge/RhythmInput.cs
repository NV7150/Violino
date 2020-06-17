using ScoreControl;

namespace Judge {
    public interface RhythmInput {
        bool isJudgeTiming();
        bool isJudgeContinue();
        bool getButton(NoteLane lane);
        NoteDirection getDirection();
    }
}
