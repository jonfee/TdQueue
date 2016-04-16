namespace TDQueue
{
    /// <summary>
    /// 表示双向链接列表节点，该类不能被继承
    /// </summary>
    /// <typeparam name="T">指定双向链接列表节点元素类型</typeparam>
    public  class DoublyNode<T>
    {
        private T data;             //数据域
        private DoublyNode<T> prev; //后驱引用域
        private DoublyNode<T> next; //后驱引用域

        public DoublyNode()
        {
            data = default(T);
            next = null;
        }

        public DoublyNode(T val)
        {
            data = val;
            next = null;
        }

        public DoublyNode(T val, DoublyNode<T> p)
        {
            data = val;
            next = p;
        }

        public DoublyNode(DoublyNode<T> p)
        {
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
        /// 前驱引用域
        /// </summary>
        public DoublyNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        /// <summary>
        /// 后驱引用域属性
        /// </summary>
        public DoublyNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
