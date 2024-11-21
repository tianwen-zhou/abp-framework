﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Domain.Repositories;
using Yi.Framework.Rbac.Domain.Shared.Options;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace Yi.Framework.Rbac.Application.Jobs
{
    public class BackupDataBaseJob: HangfireBackgroundWorkerBase
    {
        private ISqlSugarDbContext _dbContext;
        private IOptions<RbacOptions> _options;
        public BackupDataBaseJob(ISqlSugarDbContext dbContext, IOptions<RbacOptions> options)
        {

            _options = options;
            _dbContext = dbContext;
            
            RecurringJobId = "数据库备份";
            //每天00点与24点进行备份
            CronExpression = "0 0 0,12 * * ? ";
        }
        public override Task DoWorkAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_options.Value.EnableDataBaseBackup)
            {
                var logger = LoggerFactory.CreateLogger<BackupDataBaseJob>();
                logger.LogWarning("正在进行数据库备份");
                _dbContext.BackupDataBase();
                logger.LogWarning("数据库备份已完成");
            }
            return Task.CompletedTask;
        }
    }
}
