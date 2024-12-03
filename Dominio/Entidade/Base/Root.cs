﻿namespace Dominio.Entidade.Base;


public class EntidadeBase
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
}