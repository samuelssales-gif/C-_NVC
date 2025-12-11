using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTorloni.Models;

[Table("curtida")]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__curtida__F0961F6F969FEB97", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__curtida__F0961F6F9A77ECC2", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__curtida__F0961F6F9FBF15C1", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__curtida__F0961F6FACA55A36", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__curtida__F0961F6FC7918978", IsUnique = true)]
public partial class Curtida
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_publicacao")]
    public int IdPublicacao { get; set; }

    [ForeignKey("IdPublicacao")]
    [InverseProperty("Curtida")]
    public virtual TbPublicacao IdPublicacaoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Curtida")]
    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
