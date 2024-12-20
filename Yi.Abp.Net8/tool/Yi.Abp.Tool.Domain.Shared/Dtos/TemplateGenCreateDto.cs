﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Abp.Tool.Domain.Shared.Enums;

namespace Yi.Abp.Tool.Domain.Shared.Dtos
{
    public class TemplateGenCreateDto
    {
        public void SetTemplateGiteeRef(string moduleType)
        {
            this.GiteeRef = moduleType.ToLower();
        }
        
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 模块所属gitee分支
        /// </summary>
        public string GiteeRef { get; set; }

        /// <summary>
        /// 数据库提供者
        /// </summary>
        public DbmsEnum Dbms { get; set; }


        /// <summary>
        /// 需要替换的字符串内容
        /// </summary>
        public Dictionary<string, string> ReplaceStrData { get; set; }
    }
}
