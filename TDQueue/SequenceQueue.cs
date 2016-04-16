namespace TDQueue
{
    /// <summary>
    /// 表示顺序队列
    /// </summary>
    /// <typeparam name="T">指定队列元素类型</typeparam>
    public  class SequenceQueue<T> : IQueue<T>
    {
        private int maxsize;    //顺序队列的容量
        private T[] data;       //数组，用于存储顺序队列中的数据元素
        private int front;      //指示最近一个已经离开队列的元素所占有的位置 循环顺序队列的队头
        private int rear;       //指示最近一个进入队列的元素的位置           循环顺序队列的队尾

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        #region  属性

        /// <summary>
        /// 容量属性
        /// </summary>
        public int MaxSize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }

        /// <summary>
        /// 队头指示器
        /// </summary>
        public int Front
        {
            get { return front; }
            set { front = value; }
        }

        /// <summary>
        /// 队尾指示器
        /// </summary>
        public int Rear
        {
            get { return rear; }
            set { front = value; }
        }

        #endregion

        /// <summary>
        /// 初始化指定顺序队列容器大小的<seealso cref="Td.Queue.SequenceQueue<typeparamref name="T"/>"/> 类的新实例。
        /// </summary>
        /// <param name="size">顺序队列容器大小</param>
        public SequenceQueue(int size)
        {
            data = new T[size];
            maxsize = size;
            front = rear = -1;
        }


        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            front = rear = -1;
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

            return data[++front];
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="elem"></param>
        public void EnQueue(T elem)
        {
            if (!IsFull())
            {
                data[++rear] = elem;
            }
        }

        /// <summary>
        /// 获取队头的元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return data[front + 1];
        }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return rear - front;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front == rear;
        }

        /// <summary>
        /// 判断队列是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return front == -1 && rear == maxsize - 1;
        }
    }
}
