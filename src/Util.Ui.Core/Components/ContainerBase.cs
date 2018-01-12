﻿using System;
using System.IO;
using Util.Ui.Components.Internal;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 容器
    /// </summary>
    /// <typeparam name="TWrapper">容器包装器类型</typeparam>
    public abstract class ContainerBase<TWrapper> : OptionBase, IContainer<TWrapper>, IRenderEnd
        where TWrapper : IDisposable {
        /// <summary>
        /// 流写入器
        /// </summary>
        private readonly TextWriter _writer;
        /// <summary>
        /// 渲染器
        /// </summary>
        private IContainerRender _render;

        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="writer">流写入器</param>
        protected ContainerBase( TextWriter writer ) {
            writer.CheckNull( nameof( writer ) );
            _writer = writer;
        }

        /// <summary>
        /// 渲染器
        /// </summary>
        private IContainerRender Render => _render ?? ( _render = GetRender() );

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected abstract IContainerRender GetRender();

        /// <summary>
        /// 准备渲染容器
        /// </summary>
        public TWrapper Begin() {
            Render.RenderStartTag( _writer );
            WriteLog( "渲染容器" );
            return GetWrapper();
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected abstract TWrapper GetWrapper();

        /// <summary>
        /// 容器渲染结束
        /// </summary>
        public void End() {
            Render.RenderEndTag( _writer );
        }

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToString() {
            return Render.ToString();
        }
    }
}
