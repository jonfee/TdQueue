namespace TDQueue
{
    /// <summary>
    /// 表示单向链接列表节点，该类不能被继承
    /// </summary>
    /// <typeparam name="T">指定单向链接列表节点元素型</typeparam>
    public  class SinglyNode<T>
    {
        private T data;             //数据域
        private SinglyNode<T> next;  //引用域

       /// <summary>
       /// 初始化为空的实例
       /// </summary>
        public SinglyNode()
        {
            data = default(T);
            next = null;
        }

        /// <summary>
        /// 初始化为空的实例
        /// </summary>
        /// <param name="val"></param>
        public SinglyNode(T val)
        {
            data = val;
            next = null;
        }

        /// <summary>
        /// 初始化为空的实例
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public SinglyNode(T val, SinglyNode<T> p)
        {
            data = val;
            next = p;
        }

        /// <summary>
        /// 数据域属性
        /// </summary>
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// 引用域属性
        /// </summary>
        public SinglyNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
