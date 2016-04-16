namespace TDQueue
{
    /// <summary>
    /// 表示链接队列
    /// </summary>
    /// <typeparam name="T">指定队列元素类型</typeparam>
    public  class LinkQueue<T> : IQueue<T>
    {
        private SinglyNode<T> front;    //队列头指示器
        private SinglyNode<T> rear;     //队列尾指示器
        private int size;               //队列结点个数

        /// <summary>
        /// 队头指示器
        /// </summary>
        public SinglyNode<T> Front
        {
            get { return front; }
            set { front = value; }
        }

        /// <summary>
        /// 队尾指示器
        /// </summary>
        public SinglyNode<T> Rear
        {
            get { return rear; }
            set { rear = value; }
        }

        /// <summary>
        ///  队列大小
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// 初始化为空的<seealso cref="Td.Queue.CircularSequenceQueue<typeparamref name="T"/>"/> 类的新实例。
        /// </summary>
        public LinkQueue()
        {
            front = rear = null;
            size = 0;
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            front = rear = null;
            size = 0;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            SinglyNode<T> p = front;

            front = front.Next;

            if (front == null)
            {
                rear = null;
            }

            --size;

            return p.Data;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="elem"></param>
        public void EnQueue(T elem)
        {
            SinglyNode<T> temp = new SinglyNode<T>(elem);

            if (IsEmpty())
            {
                front = temp;
                rear = temp;
            }
            else
            {
                rear.Next = temp;
                rear = temp;
            }

            ++size;
        }

        /// <summary>
        /// 获取队头元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return front.Data;
        }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return size;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (front == null) && (rear == null) && (size == 0);
        }

        /// <summary>
        /// 判断队列是否已满（链表无容量限制，返回 false）
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return false;
        }
    }
}
