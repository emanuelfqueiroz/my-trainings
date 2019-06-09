/** 

Uma Tarefa resolvida precisa ser fechada pelo cliente em até 48 horas. Caso contrário, deve ser automaticamente fechada

SOLUCAO : Criar um JOB que verifica as tarefas Resolvidas que estão a 48 horas sem sofrer alteração de estado
FREQUENCIA: 
    Executado meia-noite dos dias "uteis"

SELECT BASE: */
    Select TarefaId, Situacao From Tarefa as T
    Where T.Situacao = 'R' 
        and exists(Select 1  From TarefaHistorico as H 
                    where H.TarefaId = T.TarefaId and Datediff(hour, H.DataRegistro, getDate()) >= 48)


-- UPDATE BASE

Update T Set Situacao = 'F'
From Tarefa as T
Where T.Situacao = 'R' 
    and exists(Select 1  From TarefaHistorico as H 
                where H.TarefaId = T.TarefaId and Datediff(hour, H.DataRegistro, getDate()) >= 48)

/**
JOB SQL e STEPS:
    Criamos o JOB  BlueMIne_Job01
    Possui apenas 1 step (1 subprocesso): StepFechaTarefasResolvidas48Horas
    Mas será possível adicionar outros subprocessos, dependendo da necessidade

*/

