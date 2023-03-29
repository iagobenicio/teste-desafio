namespace teste_desafio.domain.entities
{
    public class Matricula
    {
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}