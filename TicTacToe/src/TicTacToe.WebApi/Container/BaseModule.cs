using System.Collections.Generic;
using Autofac;
using MediatR;
using TicTacToe.WebApi.Boundary;
using TicTacToe.WebApi.Handlers;
using TicTacToe.WebApi.Models;
using TicTacToe.WebApi.Repositories;
using TicTacToe.WebApi.Repositories.Abstract;
using TicTacToe.WebApi.Requests;
using TicTacToe.WebApi.Services;

namespace TicTacToe.WebApi.Container
{
    public class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request handlers
            builder
                .Register<SingleInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => { object o; return c.TryResolve(t, out o) ? o : null; };
                })
                .InstancePerLifetimeScope();

            // notification handlers
            builder
                .Register<MultiInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateBoardHandler>().As<IRequestHandler<CreateBoardRequest, GameStateResponse>>();
            builder.RegisterType<MakeMoveHandler>().As<IRequestHandler<MakeMoveRequest, GameStateResponse>>();

            builder.RegisterType<Umpire>().As<IUmpire>().SingleInstance();

            builder.RegisterType<BoardRepository>().As<IBoardRepository>().SingleInstance();
        }
    }
}