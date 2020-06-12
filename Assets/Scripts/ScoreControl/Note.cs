using Judge;

namespace ScoreControl {
    public delegate void NoteBanished(Note note);
    
    public interface Note {
        NoteType getNoteType();
        NoteDirection getNoteDirection();
        NoteLane getNoteLane();

        void banish(JudgeCode code);

        void registerOnBanished(NoteBanished func);
    }
}
