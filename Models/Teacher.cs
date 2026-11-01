using System;
using System.Collections.Generic;
using WestCoastCollege.Classes;


namespace WestCoastCollege.Models;

public record class Teacher : Person

{
    public FieldOfKnowledge[] SubjectFields { get; set; } = [];
    public string TeacherId { get; set; } = string.Empty;
}
