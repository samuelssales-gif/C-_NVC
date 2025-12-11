using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTorloni.Models;

[Table("publicacao")]
public partial class Publicacao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("descricao")]
    [StringLength(100)]
    public string? Descricao { get; set; }

    [Column("imagem_url")]
    [StringLength(100)]
    public string? ImagemUrl { get; set; }

    [Column("data_publicacao")]
    public DateOnly DataPublicacao { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Publicacao")]
    public virtual TbUsuario? IdUsuarioNavigation { get; set; }
}
