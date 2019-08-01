using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.WordUtility
{
        public class TableList
        {
            List<Table> List { get; set; }

            public void AddTable(Table table)
            {
                if (this.List == null)
                {
                    this.List = new List<Table>();
                }
                this.List.Add(table);
            }

            public List<Table> GetTableList()
            {
                return this.List;
            }
        }
    }
