﻿using Hangfire;
using SqlSugar;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using Yi.Framework.Rbac.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace Yi.Abp.Application.Jobs
{
    /// <summary>
    /// 定时任务
    /// </summary>
    public class TestJob : HangfireBackgroundWorkerBase
    {
        private ISqlSugarRepository<UserAggregateRoot> _repository;
        public TestJob(ISqlSugarRepository<UserAggregateRoot> repository)
        {
            _repository = repository;
            RecurringJobId = "测试";
            //每天一次
            CronExpression = Cron.Daily();
        }
        public override Task DoWorkAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //定时任务，非常简单
            Console.WriteLine("你好，世界");
            return Task.CompletedTask;
        }
    }
}
