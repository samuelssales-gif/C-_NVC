using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTorloni.Models;

[Keyless]
public partial class Usuario
{
    [Column("id")]
    public int Id { get; set; }
}
