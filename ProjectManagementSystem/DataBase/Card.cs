//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementSystem.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card
    {
        public int idCard { get; set; }
        public int idUser { get; set; }
        public string ThemeProject { get; set; }
        public string TaskForEmployee { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> idEmployee { get; set; }
    
        public virtual StatusProject StatusProject { get; set; }
        public virtual Users Users { get; set; }
    }
}
